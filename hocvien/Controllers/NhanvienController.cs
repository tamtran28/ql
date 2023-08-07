using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hocvien.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Security.Cryptography;
using System.Text;
namespace hocvien.Controllers
{
    public class NhanvienController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {
            if (TempData.ContainsKey("ThemSuccessMessageNV"))
            {
                ViewBag.ThemSuccessMessageNV = TempData["ThemSuccessMessageNV"];
            }
            if (TempData.ContainsKey("SuaSuccessMessageNV"))
            {
                ViewBag.SuccessMessageNV = TempData["SuaSuccessMessageNV"];
            }
            if (TempData.ContainsKey("SuccessMatKhau"))
            {
                ViewBag.SuccessMatKhauNV = TempData["SuccessMatKhau"];
            }
            var danhSachNhanVienDangLam = db.Nhanviens.Where(nv => nv.Trangthai =="Đang làm").ToList();
            return View(danhSachNhanVienDangLam);
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
            if (TempData.ContainsKey("ErrorMessageTNV"))
            {
                ViewBag.loi = TempData["ErrorMessageTNV"];
            }
            ViewBag.ten = User.Identity.Name;
            return View();
        }
        [HttpPost]
        public IActionResult themNhanvien(Nhanvien kh)
        {
            try
            {
                if (kh.Ngaysinh.Year >= DateTime.Now.Year || (DateTime.Now.Year - kh.Ngaysinh.Year) < 18)
                {
                    ModelState.AddModelError("Ngaysinh", "Ngày sinh không hợp lệ.");
                    return View("formThemnhanvien", kh);
                }
                kh.Manv = taoManhanvien();
                kh.Trangthai = "Đang làm";
                kh.Matkhau= GetMd5Hash(kh.Matkhau);
                db.Nhanviens.Add(kh);
                db.SaveChanges();

                TempData["ThemSuccessMessageNV"] = "Thêm nhân viên thành công";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessageTNV"] = "Đã xảy ra lỗi trong quá trình thêm nhân viên.";
                return View("formThemnhanvien", kh);
            }
        }
        public string GetMd5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        public IActionResult formDoimatkhau(string id)
        {
            //ViewBag.manv = 
            if (TempData.ContainsKey("ErrorMatKhau"))
            {
                ViewBag.ErrorMatKhau = TempData["ErrorMatKhau"];
            }
            return View();
        }
        //[HttpPost]
        //public IActionResult doiMatkhau(string oldPassword, string newPassword)
        //{
        //    string username = HttpContext.Session.GetString("Manv");
        //    var employee = db.Nhanviens.FirstOrDefault(nv => nv.Manv == username);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    string manv = employee.Manv;
        //    var employee1 = db.Nhanviens.FirstOrDefault(nv => nv.Manv == manv);
        //    if (employee1 == null)
        //    {
        //        return NotFound();
        //    }

        //    // Kiểm tra mật khẩu cũ
        //    if (employee.Matkhau != GetMd5Hash(oldPassword))
        //    {
        //        return BadRequest("Mật khẩu cũ không đúng");
        //    }

        //    // Mã hóa mật khẩu mới
        //    string hashedNewPassword = GetMd5Hash(newPassword);

        //    // Cập nhật mật khẩu mới vào cơ sở dữ liệu
        //    employee.Matkhau = hashedNewPassword;
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public IActionResult doiMatkhau(string oldPassword, string newPassword)
        {
            string username = HttpContext.Session.GetString("Manv");

            // Check if the user is an employee
            var employee = db.Nhanviens.FirstOrDefault(nv => nv.Manv == username);
            if (employee != null)
            {
                // Kiểm tra mật khẩu cũ cho nhân viên
                if (employee.Matkhau != GetMd5Hash(oldPassword))
                {
                    TempData["ErrorMatKhau"] = "Mật khẩu cũ không đúng";
                    return RedirectToAction("formDoimatkhau");
                }

              
                string hashedNewPassword = GetMd5Hash(newPassword);

               
                employee.Matkhau = hashedNewPassword;
                db.SaveChanges();
                TempData["SuccessMatKhau"] = "Thay đổi mật khẩu thành công";

               
                if (User.IsInRole("quanly"))
           
                {
                    
                    return RedirectToAction("Index","Khoahoc");
                }

                
                return RedirectToAction("Index", "Hocvien");
            }

            var teacher = db.Giaoviens.FirstOrDefault(gv => gv.Magv == username);
            if (teacher != null)
            {
                // Kiểm tra mật khẩu cũ cho giáo viên
                if (teacher.Matkhau != GetMd5Hash(oldPassword))
                {
                    TempData["ErrorMatKhau"] = "Mật khẩu cũ không đúng";
                    return RedirectToAction("formDoimatkhau");
                }

               
                string hashedNewPassword = GetMd5Hash(newPassword);

                
                teacher.Matkhau = hashedNewPassword;
                db.SaveChanges();
                TempData["SuccessMatKhau"] = "Thay đổi mật khẩu thành công";

              
                return RedirectToAction("Index", "Hocvien");
            }

            
            return NotFound();
        }


        public IActionResult formSuaNhanvien(string id)
        {
            if (TempData.ContainsKey("ErrorMessageSNV"))
            {
                ViewBag.loi = TempData["ErrorMessageSNV"];
            }
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;
            Model.Nhanvien x = db.Nhanviens.Find(id);

            return View(x);
        }
        [HttpPost]
        public IActionResult suaNhanvien(Model.Nhanvien x)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Model.Nhanvien hv = db.Nhanviens.Find(x.Manv);
                    if (hv != null)
                    {
                        hv.Hoten = x.Hoten;
                        hv.Ngaysinh = x.Ngaysinh;
                        if (x.Ngaysinh.Year >= DateTime.Now.Year || (DateTime.Now.Year - x.Ngaysinh.Year) < 18)
                        {
                            ModelState.AddModelError("Ngaysinh", "Ngày sinh không hợp lệ.");
                            return View("formSuaNhanvien", x);
                        }
                        hv.Gioitinh = x.Gioitinh;
                        hv.Trangthai = x.Trangthai;
                        hv.Diachi = x.Diachi;
                        hv.Email = x.Email;
                        hv.Nhom = x.Nhom;
                        hv.Sdt = x.Sdt;
                        db.SaveChanges();
                    }
                    TempData["SuaSuccessMessageNV"] = "Sửa nhân viên thành công";
                    return RedirectToAction("Index");
                }
                return View("formSuaNhanvien", x);
            }
            catch (Exception e)
            {
                TempData["ErrorMessageSNV"] = "Đã xảy ra lỗi trong quá trình sửa nhân viên.";
                return View("formSuaNhanvien",x);
            }
        }

        public IActionResult formXoaNhanVien(String id)
        {
            int dem = db.Nhanviens.Where(a => a.Manv == id).ToList().Count();
            Model.Nhanvien x = db.Nhanviens.Find(id);
            ViewBag.flag = dem;

            return View(x);
        }
        public IActionResult xoaNhanvien(String Manv)
        {
            var nhanvien = db.Nhanviens.Find(Manv);

            if (nhanvien != null)
            {
                // Thay đổi trạng thái của nhân viên thành "nghỉ"
                nhanvien.Trangthai = "Nghỉ";

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }
    }
}