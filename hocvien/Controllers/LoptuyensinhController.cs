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
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hocvien.Controllers
{
    [Authorize(Roles = "tuyensinh,hocvu")]
    public class LoptuyensinhController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessageTS = TempData["SuccessMessage"];
            }
            if (TempData.ContainsKey("SuccessMessageSuaTS"))
            {
                ViewBag.SuaSuccessMessageTS = TempData["SuccessMessageSuaTS"];
            }
            if (TempData.ContainsKey("XoaTS"))
            {
                ViewBag.xoa = TempData["XoaTS"];
            }
            var ds = db.Loptuyensinhs
            .Join(db.Cahocs,
                r => r.Macahoc,
                s => s.Macahoc,
                (r, s) =>
            //    new { Loptuyensinh = r, Cahoc = s })
            //.Join(db.LopDangkyhocs, s => s.Phieudangkyhoc.Maphieu, n => n.Maphieu, (s, n) => new { Phieudangkyhoc = s, LopDangkyhoc = n })
            //.Join(db.Loptuyensinhs,
            //s => s.LopDangkyhoc.Maloptuyensinh,
            //j => j.Maloptuyensinh,
            new CLopTS
            {
               // Maphieu = s.Phieudangkyhoc.Phieudangkyhoc.Maphieu,
                //Mahv = s.Phieudangkyhoc.Hocvien.Mahv,
                //Hoten = s.Phieudangkyhoc.Hocvien.Hoten,
                Ngaybatdau = (DateTime)r.Ngaybatdau,
                Ngayketthuc = (DateTime)r.Ngayketthuc,
                Maloptuyensinh = r.Maloptuyensinh,
                Tenloptuyensinh = r.Tenloptuyensinh,
                Thuhoc = s.Thuhoc,
                Giohoc = s.Giohoc,
            });
            return View(ds);
        }
        [Authorize(Roles = "tuyensinh")]
        public IActionResult themLoptuyensinh()
        {
           
            // Lấy danh sách khóa học và môn học từ cơ sở dữ liệu
            var khoahocs = db.Khoahocs.Where(kh => kh.Trangthai == "Đang mở").ToList();
            var monhocs = db.Monhocs.ToList();
            var cahoc = db.Cahocs.ToList();
            // Tạo SelectList cho combobox khóa học
            var khoahocSelectList = new SelectList(khoahocs, "Makh", "Tenkh");

            ViewBag.DSKhoahoc = khoahocSelectList;
            ViewBag.DSMonhoc = monhocs;
            ViewBag.Cahocs = cahoc;
            
            return View();
        }

      
        [HttpPost]
        public IActionResult themLoptuyensinh(CreateClassViewModel model)
        {
            try
            {
                string manv = HttpContext.Session.GetString("Manv");
                string thangNamHienTai = DateTime.Now.ToString("MMyyyy");

                if (ModelState.IsValid)
                {
                    // Tạo các đối tượng Loptuyensinh và lưu vào cơ sở dữ liệu
                    foreach (var mamh in model.MamhList)
                    {
                        var macahoc = Request.Form[$"Macahoc_{mamh}"];
                        var ngaybatdau = DateTime.Parse(Request.Form[$"NgaybatdauList[{mamh}]"]);
                        var ngayketthuc = DateTime.Parse(Request.Form[$"NgayketthucList[{mamh}]"]);

                        var loptuyensinh = new Loptuyensinh
                        {
                            Maloptuyensinh = String.Concat(model.Makh, "-", mamh, thangNamHienTai).Replace(" ", ""),
                            Tenloptuyensinh = String.Concat(model.Makh, "-", mamh, thangNamHienTai).Replace(" ", ""),
                            Trangthai = "đang mở",
                            Nguoitao = manv,
                            Ngaytao = DateTime.Now,
                            Ngaybatdau = ngaybatdau,
                            Ngayketthuc = ngayketthuc,
                            Macahoc = macahoc,
                            Makh = model.Makh,
                            Mamh = mamh
                        };

                        db.Loptuyensinhs.Add(loptuyensinh);
                    }

                    db.SaveChanges();

                    TempData["SuccessMessage"] = "Thêm lớp tuyển sinh thành công";
                    return RedirectToAction("Index", "Loptuyensinh");
                }
            }
            catch (Exception ex)
            {
                
                TempData["ErrorMessageTS"] = "Đã xảy ra lỗi khi tạo lớp tuyển sinh";
            }

            // Nếu dữ liệu không hợp lệ hoặc xảy ra lỗi, hiển thị lại trang tạo lớp tuyển sinh
            var khoahocs = db.Khoahocs.ToList();
            var monhocs = db.Monhocs.ToList();
            var cahoc = db.Cahocs.ToList();
            var khoahocSelectList = new SelectList(khoahocs, "Makh", "Tenkh");

            ViewBag.DSKhoahoc = khoahocSelectList;
            ViewBag.DSMonhoc = monhocs;
            ViewBag.Cahocs = cahoc;

            return View(model);
        }

        public IActionResult xemKhoahoc(string id)
        {
            Khoahoc x = db.Khoahocs.Find(id);
            return PartialView(x);
        }
        public IActionResult xemMonhoc(string id)
        {
            Monhoc x = db.Monhocs.Find(id);
            return PartialView(x);
        }
        [Authorize(Roles = "tuyensinh")]
        public IActionResult formXoaloptuyensinh(String id)
        {
            int dem = db.Lophocs.Where(a => a.Maloptuyensinh == id).ToList().Count();
            Model.Loptuyensinh x = db.Loptuyensinhs.Find(id);
            ViewBag.flag = dem;
           
            return View(x);
        }
        public IActionResult xoaLoptuyensinh(string id)
        {
            try
            {
                Model.Loptuyensinh x = db.Loptuyensinhs.Find(id);
                if (x != null)
                {
                    // Xóa tất cả các bản ghi liên quan trong bảng "lop_dangkyhoc"
                    var lopDangKyHocList = db.LopDangkyhocs.Where(ldk => ldk.Maloptuyensinh == id).ToList();
                    db.LopDangkyhocs.RemoveRange(lopDangKyHocList);

                    db.Loptuyensinhs.Remove(x);
                    db.SaveChanges();
                }
                TempData["XoaTS"] = "Xóa lớp tuyển sinh thành công";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
              

                TempData["ErrorMessageXoaTS"] = "Đã xảy ra lỗi khi xóa lớp tuyển sinh. Vui lòng thử lại sau.";
                return View("formXoaloptuyensinh");
            }
        }

        public IActionResult formSualoptuyensinh(string id)
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;

            var lopTuyenSinh = db.Loptuyensinhs
                .Include(x => x.MacahocNavigation)
                .FirstOrDefault(x => x.Maloptuyensinh == id);

            if (lopTuyenSinh == null)
            {
                return NotFound();
            }

            var cahoc = db.Cahocs.ToList();
            ViewBag.Cahocs = cahoc;

            return View(lopTuyenSinh);
        }

        [HttpPost]
        public IActionResult suaLoptuyensinh(Loptuyensinh x)
        {
            string manv = HttpContext.Session.GetString("Manv");
            try
            {
                if (ModelState.IsValid)
                {
                    Loptuyensinh kh = db.Loptuyensinhs
                        .Include(l => l.MacahocNavigation)
                        .FirstOrDefault(l => l.Maloptuyensinh == x.Maloptuyensinh);

                    if (kh != null)
                    {
                        kh.Ngaybatdau = x.Ngaybatdau;
                        kh.Ngayketthuc = x.Ngayketthuc;
                        kh.Tenloptuyensinh = x.Tenloptuyensinh;
                        kh.Nguoitao = manv;
                        kh.Ngaytao = DateTime.Now;
                        kh.Trangthai = x.Trangthai;
                        kh.Macahoc = x.Macahoc;

                        db.SaveChanges();
                    }
                    TempData["SuccessMessageSuaTS"] = "Sửa lớp tuyển sinh thành công";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và ghi log nếu cần thiết
                // logger.LogError(ex, "Error while updating Loptuyensinh");

                TempData["ErrorMessageSua"]= "Đã xảy ra lỗi khi cập nhật lớp tuyển sinh";
            }

            // Load danh sách Cahoc để hiển thị lựa chọn cho dropdown
            var cahoc = db.Cahocs.ToList();
            ViewBag.Cahocs = cahoc;

            return View("formSualoptuyensinh", x);
        }



    }
}
