
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
            });
            return View(danhSachPhieuDangKy);
        }
    
    public IActionResult formThemphieudangky(string id)
        {
            // Retrieve the selected classes from the session
            List<string> selectedClasses = MySessions.GetList<string>(HttpContext.Session, "selectedClasses");

            return View();
        }

       
        public IActionResult SearchCourse(string maLopHoc)
        {
            ViewBag.DSLop = new SelectList(db.Khoahocs.ToList(), "Makh", "Tenkh");
            // HttpContext.Session.SetString("Maloptuyensinh", maLopHoc);

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
           // ViewBag.Kh = kh;
            return View();
        }


       



        

        public IActionResult registration(string id)
        {
            //List<string> sessionSelectedClasses = MySessions.GetList<string>(HttpContext.Session, "SelectedClasses");
            //ViewBag.kh = sessionSelectedClasses;
            ViewBag.s = id;
            List<string> selectedClasses = MySessions.GetList<string>(HttpContext.Session, "selectedClasses");

            // Set the selected classes in ViewBag
            ViewBag.SelectedClasses = selectedClasses;

            return View();
        }


        //[HttpPost]
        //public IActionResult CreateRegistration(Phieudangkyhoc p)
        //{
        //     p.Maphieu = taoMaphieu();

        //    List<string> sessionSelectedClasses = MySessions.GetList<string>(HttpContext.Session, "selectedClasses");

        //    p.Maphieu = taoMaphieu();
        //    p.Ngaydk = DateTime.Now; // Lấy ngày hiện tại

        //    // Lưu phiếu đăng ký vào cơ sở dữ liệu
        //    db.Phieudangkyhocs.Add(p);
        //    db.SaveChanges();

        //    // Lưu danh sách lớp tuyển sinh đã chọn vào bảng 'LopDangkyhoc' với mã phiếu đăng ký tương ứng
        //    if (sessionSelectedClasses != null && sessionSelectedClasses.Count > 0)
        //    {
        //        foreach (var malop in sessionSelectedClasses)
        //        {
        //            var lopDangKyHoc = new LopDangkyhoc
        //            {
        //                Maphieu = p.Maphieu,
        //                Maloptuyensinh = malop
        //            };

        //            db.LopDangkyhocs.Add(lopDangKyHoc);
        //        }

        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}

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
                p.tongtien = totalCourseFee;
                p.Sotiendatra = 0; // Ban đầu số tiền đã trả là 0
                p.Sotienconlai = totalCourseFee;
            }

            // Lưu phiếu đăng ký vào cơ sở dữ liệu
            db.Phieudangkyhocs.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //private decimal TinhTongTienThanhToan(string maphieu)
        //{
        //    var tongtien = db.LopDangkyhocs
        //        .Where(ldk => ldk.Maphieu == maphieu) // Chỉ tính tổng tiền cho những lớp chưa được thanh toán
        //        .Join(
        //            db.Loptuyensinhs,
        //            ldk => ldk.Maloptuyensinh,
        //            lt => lt.Maloptuyensinh,
        //            (ldk, lt) => new { LopDangkyhoc = ldk, Loptuyensinh = lt }
        //        )
        //        .Join(
        //            db.Monhocs,
        //            a => a.Loptuyensinh.Mamh,
        //            s => s.Mamh,
        //            (a, s) => s.Hocphi
        //        )
        //        .Sum();

        //    return tongtien;
        //}

        //[HttpPost]
        //public IActionResult themPhieudangky(Phieudangkyhoc p)
        //{
        //    p.Maphieu = taoMaphieu();
        //    db.Phieudangkyhocs.Add(p);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        private string taoMaphieu()
        {
            // Lấy mã học viên cuối cùng từ CSDL
            var lastphieu = db.Phieudangkyhocs.OrderByDescending(x => x.Maphieu).FirstOrDefault();
            int lastId = lastphieu != null ? int.Parse(lastphieu.Maphieu.Substring(2)) : 0;
           // Lấy phần số của mã phiếu cuối cùng(trừ đi 2 ký tự đầu tiên) và gán vào biến lastId.
   // Nếu không có phiếu nào trong CSDL, lastId sẽ được gán giá trị 0.

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
                ViewBag.Message = "Chưa có phiếu đăng ký";
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
            //List<Monhoc> dsMH = xulyhv.getDSMonhoc();
            List<Loptuyensinh> ds = db.Loptuyensinhs.Where(p => p.Makh == id).ToList();
            //Loptuyensinh x = db.Loptuyensinhs.Find(id);
            if (ds.Count == 0)
            {
                ViewBag.Message = "Chưa có lớp tuyển sinh";
            }
            return PartialView(ds);
        }
        public IActionResult formXoaphieudangky(string id)
        {
            Model.Hoadon x = db.Hoadons.Find(id);
            int dem = db.LopDangkyhocs.Where(a => a.Maphieu == id).ToList().Count();
            return View(x);
        }
        [HttpPost]
        public IActionResult xoaPhieudangky(string id)
        {

            Model.Phieudangkyhoc x = db.Phieudangkyhocs.Find(id);
            if (x != null)
            {
                db.Phieudangkyhocs.Remove(x);
                db.SaveChanges();
            }


            db.SaveChanges();

            // Return a success response
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
                TempData["SuaSuccessMessage"] = "Sửa thành công";
                return RedirectToAction("Index");
            }

            return View("formSuaphieudangky");
        }

    }
}
