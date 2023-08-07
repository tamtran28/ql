
using hocvien.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace hocvien.Controllers
{
    //[Authorize(Roles = "tuyển sinh")]
    public class PhieudangkyController : Controller
    {
        private centerContext db = new centerContext();

        public IActionResult Index()
        {

            if (TempData.ContainsKey("SuccessMessageDK"))
            {
                ViewBag.SuccessMessageThem = TempData["SuccessMessageDK"];
            }
            if (TempData.ContainsKey("SuaSuccessMessageDK"))
            {
                ViewBag.SuccessMessageSua = TempData["SuaSuccessMessageDK"];
            }
            if (TempData.ContainsKey("XoaSuccessMessageDK"))
            {
                ViewBag.SuccessMessageXoa = TempData["XoaSuccessMessageDK"];
            }
            
            //dung
            var danhSachPhieuDangKy = db.Hocviens
            .Join(db.Phieudangkyhocs,
                r => r.Mahv,
                s => s.Mahv,
                (r, s) => new { Hocvien = r, Phieudangkyhoc = s })
            .Join(db.LopDangkyhocs, s => s.Phieudangkyhoc.Maphieu, n => n.Maphieu, (s, n) => new { Phieudangkyhoc = s, LopDangkyhoc = n })
            .Join(db.Loptuyensinhs,
            s => s.LopDangkyhoc.Maloptuyensinh,
            j => j.Maloptuyensinh,
            (s, j) => new CPhieuDangKy
            {
                Maphieu = s.Phieudangkyhoc.Phieudangkyhoc.Maphieu,
                Mahv = s.Phieudangkyhoc.Hocvien.Mahv,
                Hoten = s.Phieudangkyhoc.Hocvien.Hoten,
                Ngaydk = s.Phieudangkyhoc.Phieudangkyhoc.Ngaydk,
                Maloptuyensinh = s.LopDangkyhoc.Maloptuyensinh,
                Tenloptuyensinh = j.Tenloptuyensinh,
            })
             .OrderByDescending(item => item.Ngaydk);
            return View(danhSachPhieuDangKy);
        }
    
    public IActionResult formThemphieudangky(string id)
        {
            // Retrieve the selected classes from the session
            List<string> selectedClasses = MySessions.GetList<string>(HttpContext.Session, "selectedClasses");

            return View();
        }


        public IActionResult SearchCourse()
        {
            var khoaHocDangMo = db.Khoahocs.Where(kh => kh.Trangthai == "đang mở").ToList();

            // Create a SelectList using the filtered list of Khoahoc objects
            ViewBag.DSlop = new SelectList(khoaHocDangMo, "Makh", "Tenkh");

            return View();
            // return RedirectToAction("formThemphieudangky", "Phieudangky");
        }

        [HttpPost]
        public IActionResult SelectCourse(string[] selectedClasses)
        {
            //MySessions.SetList<string>(HttpContext.Session, "selectedClasses", selectedClasses.ToList());

            List<string> selectedClassesList = selectedClasses?.ToList();
            MySessions.SetList<string>(HttpContext.Session, "selectedClasses", selectedClassesList);
            return RedirectToAction("formThemphieudangky", "Phieudangky");
        }
        public IActionResult SearchStudent(String kh)
        {
            return View();
        }
        public IActionResult registration(string id)
        {
            ViewBag.s = id;
             List<string> selectedClasses = MySessions.GetList<string>(HttpContext.Session, "selectedClasses");
             ViewBag.SelectedClasses = selectedClasses;

             var hocvien = db.Hocviens.FirstOrDefault(hv => hv.Mahv == id);
             if (hocvien != null)
             {
                  ViewBag.Hocvien = hocvien.Hoten;
                  ViewBag.NgaySinh = hocvien.Ngaysinh;
                  ViewBag.GioiTinh = hocvien.Gioitinh == 1 ? "Nam" : "Nữ";
                  ViewBag.SDT = hocvien.Sdt;
             }

          var lopTuyenSinhs = db.Loptuyensinhs
          .Where(lts => selectedClasses.Contains(lts.Maloptuyensinh))
          .ToList();

          ViewBag.LopTuyenSinhs = lopTuyenSinhs;

         return View();
        }
        [HttpPost]
        public IActionResult CreateRegistration(Phieudangkyhoc p)
        {
            p.Maphieu = taoMaphieu();
            p.Ngaydk = DateTime.Now; // Lấy ngày hiện tại

            // Lưu danh sách lớp tuyển sinh đã chọn vào bảng 'LopDangkyhoc' với mã phiếu đăng ký tương ứng
            List<string> sessionSelectedClasses = MySessions.GetList<string>(HttpContext.Session, "selectedClasses");
            if (sessionSelectedClasses != null && sessionSelectedClasses.Count > 0)
            {
                decimal totalCourseFee = 0;
                foreach (var malop in sessionSelectedClasses)
                {
                    // Kiểm tra xem học viên đã đăng ký lớp tuyển sinh này trước đó hay chưa
                    if (db.LopDangkyhocs.Any(ldk => ldk.Maloptuyensinh == malop && ldk.MaphieuNavigation.Mahv == p.Mahv))
                    {
                        return View("loi");
                    }

                    var lopDangKyHoc = new LopDangkyhoc
                    {
                        Maphieu = p.Maphieu,
                        Maloptuyensinh = malop
                    };

                    db.LopDangkyhocs.Add(lopDangKyHoc);

                    // Lấy thông tin về môn học và tính tổng tiền dựa trên giá học phí của mỗi môn học
                    var TongTien = db.Loptuyensinhs
                        .Where(ldk => ldk.Maloptuyensinh == malop)
                        .Join(
                            db.Monhocs,
                            ldk => ldk.Mamh,
                            mh => mh.Mamh,
                            (ldk, mh) => mh.Hocphi
                        )
                        .FirstOrDefault();

                    if (TongTien != null)
                    {
                        totalCourseFee += TongTien;
                    }
                }

                // Cập nhật thông tin tổng tiền, số tiền đã trả và số tiền còn lại trong phiếu đăng ký
                
                p.Sotiendatra = 0; // Ban đầu số tiền đã trả là 0
                p.Sotienconlai = totalCourseFee;
                p.tongtien = totalCourseFee;
            }

            // Lưu phiếu đăng ký vào cơ sở dữ liệu
            db.Phieudangkyhocs.Add(p);
            db.SaveChanges();
            TempData["SuccessMessageDK"] = "Tạo phiếu đăng ký thành công";
            return RedirectToAction("Index");
        }


        private string taoMaphieu()
        {
            // Lấy mã học viên cuối cùng từ CSDL
            var lastphieu = db.Phieudangkyhocs.OrderByDescending(x => x.Maphieu).FirstOrDefault();
            int lastId = lastphieu != null ? int.Parse(lastphieu.Maphieu.Substring(2)) : 0;
           // Lấy phần số của mã phiếu cuối cùng(trừ đi 2 ký tự đầu tiên) và gán vào biến lastId.
            // Tạo mã học viên mới
            string newId = (lastId + 1).ToString("D3");
            string maPhieu = "PH" + newId;

            return maPhieu;
        }
        [HttpGet]
        public IActionResult timHocvien(string id)
        {

            List<Hocvien> ds = db.Hocviens.Where(x => x.Hoten.Contains(id) || x.Sdt == (id)).ToList()
;
            // List<Hocvien> ds = db.Hocviens.Where(x => x.Hoten.Contains(id)).ToList();
            if (ds.Count == 0)
            {
                ViewBag.Message = "Chưa có học viên này";
            }

            return PartialView(ds);


        }

        public IActionResult timMotHocvien(string id)
        {
            Hocvien x = db.Hocviens.Find(id);
            return PartialView(x);
        }
        public IActionResult timLop(string id)
        {
            
           // List<Loptuyensinh> ds = db.Loptuyensinhs.Where(p => p.Makh == id).ToList();
            List<Loptuyensinh> ds = db.Loptuyensinhs.Where(p => p.Makh == id && p.Trangthai == "đang mở").ToList();
            if (ds.Count == 0)
            {
                ViewBag.Message = "Chưa có lớp tuyển sinh này";
            }
            return PartialView(ds);
        }
        public IActionResult formXoaphieudangky(string id)
        {
           
            Model.Phieudangkyhoc x = db.Phieudangkyhocs.Find(id);
            var hocVien = db.Hocviens.FirstOrDefault(hv => hv.Mahv == x.Mahv);
            var lopDangKy = db.LopDangkyhocs.FirstOrDefault(ldk => ldk.Maphieu == id);
            int dem = db.Hoadons.Where(a => a.Maphieu == id).ToList().Count();
            var loptuyensinh = db.Loptuyensinhs.FirstOrDefault(lts => lts.Maloptuyensinh == lopDangKy.Maloptuyensinh);
            if (loptuyensinh != null)
            {
                ViewBag.MaKh = loptuyensinh.Makh;
                ViewBag.MaMh = loptuyensinh.Mamh;
                ViewBag.NgayBatDau = loptuyensinh.Ngaybatdau;
                ViewBag.NgayKetThuc = loptuyensinh.Ngayketthuc;
            }
            ViewBag.flag = dem;
            ViewBag.HocVien = hocVien;
            ViewBag.LopDangKy = lopDangKy;
            return View(x);
        }
        [HttpPost]
        public IActionResult xoaPhieudangky(string id)
        {
            // Kiểm tra xem có lớp đăng ký nào liên quan không
            var lopDangKyHocList = db.LopDangkyhocs.Where(ldk => ldk.Maphieu == id).ToList();
            if (lopDangKyHocList.Count > 0)
            {
                // Nếu có lớp đăng ký liên quan, hãy xóa chúng trước
                db.LopDangkyhocs.RemoveRange(lopDangKyHocList);
            }

            // Tiến hành xóa phiếu đăng ký
            Model.Phieudangkyhoc x = db.Phieudangkyhocs.Find(id);
            if (x != null)
            {
                db.Phieudangkyhocs.Remove(x);
                db.SaveChanges();
            }

            // Trả về thông báo thành công
            TempData["XoaSuccessMessageDK"] = "Xóa thành công";
            return RedirectToAction("Index");
        }

        public IActionResult formSuaphieudangky(string id)
        {
            ViewBag.ten = User.Identity.Name;
            Model.Phieudangkyhoc x = db.Phieudangkyhocs.Find(id);

            return View(x);
        }
        [HttpPost]
        public IActionResult suaPhieudangky(Model.Phieudangkyhoc x)
        {

            if (ModelState.IsValid)
            {
                Model.Phieudangkyhoc p = db.Phieudangkyhocs.Find(x.Maphieu);
                if (p != null)
                {
                    p.Ngaydk = x.Ngaydk;
                    p.Ghichu = x.Ghichu;
                   
                }
                TempData["SuaSuccessMessageDK"] = "Sửa thành công";
                return RedirectToAction("Index");
            }

            return View("formSuaphieudangky");
        }

    }
}
