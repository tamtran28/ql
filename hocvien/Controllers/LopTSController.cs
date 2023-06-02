using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hocvien.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hocvien.Controllers
{
    public class LopTSController : Controller
    {
        private trungtamContext db = new trungtamContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            // Lấy danh sách khóa học và môn học từ cơ sở dữ liệu
            var khoahocs = db.Khoahocs.ToList();
            var monhocs = db.Monhocs.ToList();

            // Tạo SelectList cho combobox khóa học
            var khoahocSelectList = new SelectList(khoahocs, "Makh", "Tenkh");

            ViewBag.DSKhoahoc = khoahocSelectList;
            ViewBag.DSMonhoc = monhocs;

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
                    var loptuyensinh = new Loptuyensinh
                    {
                       Maloptuyensinh = String.Concat(model.Makh, "-", mamh,thangNamHienTai).Replace(" ", ""), // Hàm để tạo mã lớp tuyển sinh duy nhất
                                                                                                //Maloptuyensinh ="KH",
                        Tenloptuyensinh = String.Concat(model.Makh, "-", mamh, thangNamHienTai).Replace(" ", ""),
                        Trangthai = "Trạng thái",
                        Nguoitao = "Người tạo",
                        Ngaytao = DateTime.Now,
                        Ngaybatdau = model.Ngaybatdau,
                        Ngayketthuc = model.Ngayketthuc,
                        Thuhoc = "Thứ học",
                        Giohoc = model.Giohoc,
                        Makh = model.Makh,
                        Mamh = mamh
                    };

                    db.Loptuyensinhs.Add(loptuyensinh);
                }

                db.SaveChanges();

                // Chuyển hướng đến trang thành công hoặc trang thông báo
                return RedirectToAction("Index","PhieuDangky");
            }

            // Nếu dữ liệu không hợp lệ, hiển thị lại trang tạo lớp tuyển sinh với thông báo lỗi
            var khoahocs = db.Khoahocs.ToList();
            var monhocs = db.Monhocs.ToList();

            var khoahocSelectList = new SelectList(khoahocs, "Makh", "Tenkh");

            ViewBag.DSKhoahoc = khoahocSelectList;
            ViewBag.DSMonhoc = monhocs;

            return View(model);
        }

        // Hàm để tạo mã lớp tuyển sinh duy nhất
        private string GenerateUniqueCode()
        {
            // Thực hiện tạo mã lớp tuyển sinh duy nhất
            // Có thể sử dụng thuật toán để tạo mã duy nhất hoặc logic phù hợp với yêu cầu của bạn
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            string code = new string(Enumerable.Repeat(characters, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return code; // Trả về mã lớp tuyển sinh duy nhất đã tạo
        }
    }
}


