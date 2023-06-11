using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using hocvien.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hocvien.Controllers
{
    public class LopTSController : Controller
    {
        private centerContext db = new centerContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
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

                    //var ngaybatdau = model.Ngaybatdau[mamh];
                    //var ngayketthuc = model.Ngayketthuc[mamh];
                    //DateTime ngaybatdau = DateTime.ParseExact(ngaybatdauS, "ddd MMM dd HH:mm:ss K yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                    //DateTime ngayketthuc = DateTime.ParseExact(ngayketthucS, "ddd MMM dd HH:mm:ss K yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                    var loptuyensinh = new Loptuyensinh
                    {
                        Maloptuyensinh = String.Concat(model.Makh, "-", mamh, thangNamHienTai).Replace(" ", ""), // Hàm để tạo mã lớp tuyển sinh duy nhất
                                                                                                                 //Maloptuyensinh ="KH",
                        Tenloptuyensinh = String.Concat(model.Makh, "-", mamh, thangNamHienTai).Replace(" ", ""),
                        Trangthai = "Trạng thái",
                        Nguoitao = "Người tạo",
                        Ngaytao = DateTime.Now,
                        Ngaybatdau = model.Ngaybatdau,
                        Ngayketthuc = model.Ngayketthuc,
                        Macahoc = macahoc,
                        Makh = model.Makh,
                        Mamh = mamh
                    };

                    db.Loptuyensinhs.Add(loptuyensinh);
                }

                db.SaveChanges();

                // Chuyển hướng đến trang thành công hoặc trang thông báo
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
       
    }
}


