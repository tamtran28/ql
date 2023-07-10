using hocvien.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hocvien.Controllers
{
    public class LoptuyensinhController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
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

        public IActionResult Create()
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

        // Action để xử lý khi người dùng nhấn nút Lưu
        [HttpPost]
        public IActionResult Create(CreateClassViewModel model)
        {
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
                        Maloptuyensinh = String.Concat(model.Makh, "-", mamh, thangNamHienTai).Replace(" ", ""), // Hàm để tạo mã lớp tuyển sinh duy nhất
                                                                                                                 //Maloptuyensinh ="KH",
                        Tenloptuyensinh = String.Concat(model.Makh, "-", mamh, thangNamHienTai).Replace(" ", ""),
                        Trangthai = "Trạng thái",
                        Nguoitao = "Người tạo",
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

                // Chuyển hướng đến trang thành công hoặc trang thông báo
                TempData["SuccessMessage"] = "Thêm lớp tuyển sinh thành công";
                return RedirectToAction("Index", "Loptuyensinh");
            }

            // Nếu dữ liệu không hợp lệ, hiển thị lại trang tạo lớp tuyển sinh với thông báo lỗi
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

        public IActionResult formXoaloptuyensinh(String id)
        {
            int dem = db.Lophocs.Where(a => a.Maloptuyensinh == id).ToList().Count();
            Model.Loptuyensinh x = db.Loptuyensinhs.Find(id);
            ViewBag.flag = dem;

            return View(x);
        }
        public IActionResult xoaLoptuyensinh(String id)
        {
            Model.Khoahoc x = db.Khoahocs.Find(id);
            if (x != null)
            {
                db.Khoahocs.Remove(x);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult formSualoptuyensinh(string id)
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;
           // Model.Loptuyensinh x = db.Loptuyensinhs.Find(id);

            return View();
        }
        [HttpPost]
        public IActionResult suaKhoahoc(Model.Loptuyensinh x)
        {
            if (ModelState.IsValid)
            {
                Model.Loptuyensinh kh = db.Loptuyensinhs.Find(x.Maloptuyensinh);
                if (kh != null)
                {
                    kh.Tenloptuyensinh = x.Tenloptuyensinh;
                    kh.Trangthai = x.Trangthai ;
                   // kh.Macahoc = x.Macahoc;


                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View("formSuakhoahoc");
        }

    }
}
