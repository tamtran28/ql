using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hocvien.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hocvien.Controllers
{
    public class NhanvienController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {
            return View(db.Nhanviens.ToList());
        }
        private string taoManhanvien()
        {
            // Lấy mã học viên cuối cùng từ CSDL
            var maNV = db.Nhanviens.OrderByDescending(hv => hv.Manv).FirstOrDefault();
            int lastId = maNV != null ? int.Parse(maNV.Manv.Substring(2)) : 0;

            // Tạo mã học viên mới
            string newId = (lastId + 1).ToString("D3");
            string maHocVien = "NV" + newId;

            return maHocVien;
        }
        public IActionResult formThemnhanvien()
        {
            ViewBag.ten = User.Identity.Name;
            return View();
        }

        [HttpPost]
        public IActionResult themNhanvien(Nhanvien kh)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    kh.Manv = taoManhanvien();
                    db.Nhanviens.Add(kh);
                    db.SaveChanges();
                    TempData["ThemSuccessMessage"] = "Thêm nhân viên thành công";
                    return RedirectToAction("Index");
                }

                return View("formThemnhanvien", kh);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Đã xảy ra lỗi trong quá trình thêm nhân viên.";
                // Log ex or do something with the exception
                return View("formThemnhanvien", kh);
            }
        }

        public IActionResult formDoimatkhau(string id)
        {
            //ViewBag.manv = 

            return View();
        }
        [HttpPost]
        public IActionResult doiMatkhau(string oldPassword, string newPassword)
        {
            string username = HttpContext.Session.GetString("Manv");
            // ViewBag.ten = manv;
            // string username = User.Identity.Name; // Retrieve the username from the logged-in user's identity

            // Example logic to retrieve the employee from the database using the username
            var employee = db.Nhanviens.FirstOrDefault(nv => nv.Manv == username);
            if (employee == null)
            {
                // Handle case when the employee is not found
                return NotFound();
            }

            string manv = employee.Manv; // Retrieve the Manv value from the employee object

            // TODO: Implement logic to change the password for the employee with the given manv (employee ID).

            // Example logic to update the password in the database:
            var employee1 = db.Nhanviens.FirstOrDefault(nv => nv.Manv == manv);
            if (employee1 == null)
            {
                // Handle case when the employee is not found
                return NotFound();
            }

            // Check if the old password matches the stored password
            if (employee.Matkhau != oldPassword)
            {
                // Handle case when the old password is incorrect
                return BadRequest("password cũ khong dung");
            }

            // Update the password with the new value
            employee.Matkhau = newPassword;

            // Save the changes to the database
            db.SaveChanges();

            // Return e success response
            return RedirectToAction("Index");
        }
        public IActionResult formSuaNhanvien(string id)
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;
            Model.Nhanvien x = db.Nhanviens.Find(id);

            return View(x);
        }
        [HttpPost]
        public IActionResult suaNhanvien(Model.Nhanvien x)
        {

            if (ModelState.IsValid)
            {
                Model.Nhanvien hv = db.Nhanviens.Find(x.Manv);
                if (hv != null)
                {
                    hv.Hoten = x.Hoten;
                    hv.Ngaysinh = x.Ngaysinh;
                    //if (x.Ngaysinh.Year >= DateTime.Now.Year || (DateTime.Now.Year - x.Ngaysinh.Year) <= 18)
                    //{
                    //    ModelState.AddModelError("Ngaysinh", "Ngày sinh không hợp lệ.");
                    //    return -1;
                    //}
                    hv.Gioitinh = x.Gioitinh;
                    hv.Trangthai = x.Trangthai;
                    hv.Diachi = x.Diachi;
                    hv.Email   = x.Email;
                    hv.Nhom = x.Nhom;
                    hv.Sdt = x.Sdt;
                    db.SaveChanges();
                }
                TempData["SuaSuccessMessage"] = "Sửa nhân viên thành công";
                return RedirectToAction("Index");
            }

            return View("formSuaNhanvien");
        }

        public IActionResult formXoaNhanVien(String id)
        {
            int dem = db.Nhanviens.Where(a => a.Manv == id).ToList().Count();
            Model.Nhanvien x = db.Nhanviens.Find(id);
            ViewBag.flag = dem;

            return View(x);
        }
        public IActionResult xoaHocVien(String id)
        {
            Model.Nhanvien x = db.Nhanviens.Find(id);
            if (x != null)
            {
                db.Nhanviens.Remove(x);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }
    }
}