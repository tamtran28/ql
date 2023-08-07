using hocvien.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;
//using BCrypt.Net;
namespace hocvien.Controllers
{
    public class DangnhapController : Controller
    {
        private centerContext db = new centerContext();
        //[HttpPost]
        //public IActionResult Login(string username, string password, string role)
        //{
        //    //string hashedPassword = GetMd5Hash(password);
        //    if (ModelState.IsValid)
        //    {
        //        if (role == "giáo viên")
        //        {
        //            var giaovien = db.Giaoviens.FirstOrDefault(x => x.Email == username && x.Matkhau == password && x.Nhom == GetNhom(role));
        //            if (giaovien != null)
        //            {
        //                if (giaoVienNghiLam(giaovien))
        //                {
        //                    TempData["ErrorMessageTuChoi"] = "Tài khoản bị vô hiệu hóa";
        //                    return View();
        //                }

        //                var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, username),
        //            new Claim(ClaimTypes.Role, GetRoleName(role))
        //        };
        //                var userIdentity = new ClaimsIdentity(claims, "login");
        //                var principal = new ClaimsPrincipal(userIdentity);

        //                HttpContext.Session.SetString("Username", username);
        //                HttpContext.Session.SetString("Manv", giaovien.Magv);
        //                HttpContext.SignInAsync(principal).Wait();

        //                return RedirectToAction("Index", GetControllerName(role));
        //            }
        //        }
        //        else
        //        {
        //            var nhanvien = db.Nhanviens.FirstOrDefault(x => x.Email == username && x.Matkhau == password && x.Nhom == GetNhom(role));
        //            if (nhanvien != null)
        //            {
        //                if (nhanVienNghiLam(nhanvien))
        //                {
        //                    TempData["ErrorMessageTuChoi"] = "Tài khoản bị vô hiệu hóa";
        //                    return View();
        //                }

        //                var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, username),
        //            new Claim(ClaimTypes.Role, GetRoleName(role))
        //        };
        //                var userIdentity = new ClaimsIdentity(claims, "login");
        //                var principal = new ClaimsPrincipal(userIdentity);

        //                HttpContext.Session.SetString("Username", username);
        //                HttpContext.Session.SetString("Manv", nhanvien.Manv);
        //                HttpContext.SignInAsync(principal).Wait();

        //                return RedirectToAction("Index", GetControllerName(role));
        //            }
        //        }

        //        TempData["ErrorMessageDN"] = "Thông tin đăng nhập không hợp lệ.";
        //    }

        //    return View();
        //}
        [HttpPost]
        public IActionResult Login(string username, string password, string role)
        {
            string hashedPassword = GetMd5Hash(password);

            if (ModelState.IsValid)
            {
                if (role == "giáo viên")
                {
                    var giaovien = db.Giaoviens.FirstOrDefault(x => x.Email == username && x.Matkhau == hashedPassword && x.Nhom == GetNhom(role));
                    if (giaovien != null)
                    {
                        if (giaoVienNghiLam(giaovien))
                        {
                            TempData["ErrorMessageTuChoi"] = "Tài khoản bị vô hiệu hóa";
                            return View();
                        }

                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, GetRoleName(role))
                };
                        var userIdentity = new ClaimsIdentity(claims, "login");
                        var principal = new ClaimsPrincipal(userIdentity);

                        HttpContext.Session.SetString("Username", username);
                        HttpContext.Session.SetString("Manv", giaovien.Magv);
                        HttpContext.SignInAsync(principal).Wait();

                        return RedirectToAction("Index", GetControllerName(role));
                    }
                }
                else
                {
                    var nhanvien = db.Nhanviens.FirstOrDefault(x => x.Email == username && x.Matkhau == hashedPassword && x.Nhom == GetNhom(role));
                    if (nhanvien != null)
                    {
                        if (nhanVienNghiLam(nhanvien))
                        {
                            TempData["ErrorMessageTuChoi"] = "Tài khoản bị vô hiệu hóa";
                            return View();
                        }

                       
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, GetRoleName(role))
                };
                        var userIdentity = new ClaimsIdentity(claims, "login");
                        var principal = new ClaimsPrincipal(userIdentity);

                        HttpContext.Session.SetString("Username", username);
                        HttpContext.Session.SetString("Manv", nhanvien.Manv);
                        HttpContext.SignInAsync(principal).Wait();

                        return RedirectToAction("Index", GetControllerName(role));
                    }
                }

                TempData["ErrorMessageDN"] = "Thông tin đăng nhập không hợp lệ.";
            }

            return View();
        }

        private string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Chuyển đổi input thành mảng byte
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Tạo StringBuilder để lưu trữ chuỗi MD5
                StringBuilder sBuilder = new StringBuilder();

                // Định dạng byte sang dạng hexa và thêm vào StringBuilder
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Trả về chuỗi MD5
                return sBuilder.ToString();
            }
        }
            private string GetRoleName(string role)
        {
            switch (role)
            {
                case "giáo viên":
                    return "giaovien";
                case "quản lý":
                    return "quanly";
                case "tuyển sinh":
                    return "tuyensinh";
                case "học vụ":
                    return "hocvu";
                default:
                    return string.Empty;
            }
        }

        private string GetControllerName(string role)
        {
            switch (role)
            {
                case "giáo viên":
                    return "Hocvien";
                case "quản lý":
                    return "Monhoc";
                case "tuyển sinh":
                    return "Hoadon";
                case "học vụ":
                    return "Hocvien";
                default:
                    return "Dangnhap";
            }
        }

        private int GetNhom(string role)
        {
            switch (role)
            {
               
                case "quản lý":
                    return 1;
                case "tuyển sinh":
                    return 2;
                case "học vụ":
                    return 3;
                case "giáo viên":
                    return 4;
                default:
                    return -1;
            }
        }

        private bool nhanVienNghiLam(Nhanvien nhanvien)
        {

            return nhanvien.Trangthai == "Nghỉ";
          
        }
        private bool giaoVienNghiLam(Giaovien giaovien)
        {

            return giaovien.Trangthai == "Nghỉ";

        }
        public async Task<IActionResult> Logout()
        {
            // Xóa thông tin đăng nhập khỏi session hoặc cookie
            await HttpContext.SignOutAsync();

            // Chuyển hướng đến trang đăng nhập hoặc trang chủ
            return RedirectToAction("Login", "Dangnhap");
        }


        public IActionResult Denied()
        {
            return View();
        }
        public IActionResult Login()
        {
            if (TempData.ContainsKey("ErrorMessageDN"))
            {
                ViewBag.SuaSuccessMessage = TempData["ErrorMessageDN"];
            }
            if (TempData.ContainsKey("ErrorMessageTuChoi"))
            {
                ViewBag.Tuchoi = TempData["ErrorMessageTuChoi"];
            }
           
            return View();
        }
      
     
    }

}
