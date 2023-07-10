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
//using BCrypt.Net;
namespace hocvien.Controllers
{
    public class DangnhapController : Controller
    {
        private centerContext db = new centerContext();

        //[HttpPost]
        //public IActionResult Login(string username, string password, string role)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (role == "giáo viên")
        //        {
        //            //var giaovien = db.Nhanviens.Where(x => x.Email == username);
        //            if (db.Giaoviens.Any(x => x.Email == username && x.Matkhau == EncryptPassword(password)))
        //            {
        //                // Đăng nhập thành công cho giáo viên
        //                // Lưu thông tin đăng nhập vào session hoặc cookie
        //                return RedirectToAction("Index", "Hocvien");
        //            }
        //        }
        //        else if (role == "nhân viên")
        //        {
        //            // var nhanvien = db.Nhanviens.FirstOrDefault(nv => nv.Email == username);
        //            if (db.Nhanviens.Any(x => x.Email == username && x.Matkhau == EncryptPassword(password)))
        //            {
        //                // Đăng nhập thành công cho nhân viên
        //                // Lưu thông tin đăng nhập vào session hoặc cookie
        //                return RedirectToAction("Index", "Hocvien");
        //            }
        //        }
        //    }

        //    // Xử lý lỗi đăng nhập không thành công
        //    ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không hợp lệ.");
        //    return View();
        //}



        //[HttpPost]
        //public IActionResult Login(string username, string password, string role)
        //{

        //    //2806
        //    if (ModelState.IsValid)
        //    {
        //        if (role == "giáo viên")
        //        {
        //            var giaovien = db.Giaoviens.FirstOrDefault(x => x.Email == username && x.Matkhau == EncryptPassword(password));
        //            if (giaovien != null)
        //            {
        //                string manv = giaovien.Magv;

        //                // Lưu thông tin đăng nhập vào session
        //                HttpContext.Session.SetString("Username", username);
        //                HttpContext.Session.SetString("Manv", manv);

        //                // Đặt vai trò của người dùng
        //                var claims = new List<Claim>
        //                {
        //                    new Claim(ClaimTypes.Name, username),
        //                    new Claim(ClaimTypes.Role, "giaovien")
        //                };
        //                var userIdentity = new ClaimsIdentity(claims, "login");
        //                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //                HttpContext.SignInAsync(principal);

        //                return RedirectToAction("Index", "Khoahoc");
        //            }
        //        }
        //        else if (role == "quản lý")
        //        {
        //            var nhanvien = db.Nhanviens.FirstOrDefault(x => x.Email == username && x.Matkhau == EncryptPassword(password) && x.Nhom == 1);
        //            if (nhanvien != null)
        //            {
        //                string manv = nhanvien.Manv;

        //                // Lưu thông tin đăng nhập vào session
        //                HttpContext.Session.SetString("Username", username);
        //                HttpContext.Session.SetString("Manv", manv);

        //                // Đặt vai trò của người dùng
        //                var claims = new List<Claim>
        //                {
        //                    new Claim(ClaimTypes.Name, username),
        //                    new Claim(ClaimTypes.Role, "quanly")
        //                };
        //                var userIdentity = new ClaimsIdentity(claims, "login");
        //                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //                HttpContext.SignInAsync(principal);

        //                return RedirectToAction("Index", "Hocvien");
        //            }
        //        }
        //        else if (role == "tuyển sinh")
        //        {
        //            var nhanvien = db.Nhanviens.FirstOrDefault(x => x.Email == username && x.Matkhau == EncryptPassword(password) && x.Nhom == 2);
        //            if (nhanvien != null)
        //            {
        //                string manv = nhanvien.Manv;

        //                // Lưu thông tin đăng nhập vào session
        //                HttpContext.Session.SetString("Username", username);
        //                HttpContext.Session.SetString("Manv", manv);

        //                var claims = new List<Claim>
        //                {
        //                    new Claim(ClaimTypes.Name, username),
        //                    new Claim(ClaimTypes.Role, "tuyensinh")
        //                };
        //                var userIdentity = new ClaimsIdentity(claims, "login");
        //                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //                HttpContext.SignInAsync(principal);

        //                return RedirectToAction("Index", "Hoadon");
        //            }
        //        }
        //        else if (role == "học vụ")
        //        {
        //            var nhanvien = db.Nhanviens.FirstOrDefault(x => x.Email == username && x.Matkhau == EncryptPassword(password) && x.Nhom == 3);
        //            if (nhanvien != null)
        //            {
        //                string manv = nhanvien.Manv;

        //                // Lưu thông tin đăng nhập vào session
        //                HttpContext.Session.SetString("Username", username);
        //                HttpContext.Session.SetString("Manv", manv);

        //                var claims = new List<Claim>
        //                {
        //                    new Claim(ClaimTypes.Name, username),
        //                    new Claim(ClaimTypes.Role, "hocvu")
        //                };
        //                var userIdentity = new ClaimsIdentity(claims, "login");
        //                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //                HttpContext.SignInAsync(principal);

        //                return RedirectToAction("Index", "Hocvien");
        //            }
        //        }
        //        return RedirectToAction("Denied", "Dangnhap");
        //    }

        //    // Xử lý lỗi đăng nhập không thành công
        //    ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không hợp lệ.");
        //    return View();
        //}
        [HttpPost]
        public IActionResult Login(string username, string password, string role)
        {
            if (ModelState.IsValid)
            {
                if (role == "giáo viên")
                {
                    var giaovien = db.Giaoviens.FirstOrDefault(x => x.Email == username && x.Matkhau == EncryptPassword(password));
                    if (giaovien != null)
                    {
                        string manv = giaovien.Magv;

                        // Lưu thông tin đăng nhập vào session
                        HttpContext.Session.SetString("Username", username);
                        HttpContext.Session.SetString("Manv", manv);

                        // Đặt vai trò của người dùng
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "giaovien")
                };
                        var userIdentity = new ClaimsIdentity(claims, "login");
                        var principal = new ClaimsPrincipal(userIdentity);

                        HttpContext.SignInAsync(principal).Wait();

                        return RedirectToAction("Index", "Khoahoc");
                    }
                }
                else if (role == "quản lý")
                {
                    var nhanvien = db.Nhanviens.FirstOrDefault(x => x.Email == username && x.Matkhau == EncryptPassword(password) && x.Nhom == 1);
                    if (nhanvien != null)
                    {
                        string manv = nhanvien.Manv;

                        // Lưu thông tin đăng nhập vào session
                        HttpContext.Session.SetString("Username", username);
                        HttpContext.Session.SetString("Manv", manv);

                        // Đặt vai trò của người dùng
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "quanly")
                };
                        var userIdentity = new ClaimsIdentity(claims, "login");
                        var principal = new ClaimsPrincipal(userIdentity);

                        HttpContext.SignInAsync(principal).Wait();

                        return RedirectToAction("Index", "Hocvien");
                    }
                }
                else if (role == "tuyển sinh")
                {
                    var nhanvien = db.Nhanviens.FirstOrDefault(x => x.Email == username && x.Matkhau == EncryptPassword(password) && x.Nhom == 2);
                    if (nhanvien != null)
                    {
                        string manv = nhanvien.Manv;

                        // Lưu thông tin đăng nhập vào session
                        HttpContext.Session.SetString("Username", username);
                        HttpContext.Session.SetString("Manv", manv);

                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "tuyensinh")
                };
                        var userIdentity = new ClaimsIdentity(claims, "login");
                        var principal = new ClaimsPrincipal(userIdentity);

                        HttpContext.SignInAsync(principal).Wait();

                        return RedirectToAction("Index", "Hoadon");
                    }
                }
                else if (role == "học vụ")
                {
                    var nhanvien = db.Nhanviens.FirstOrDefault(x => x.Email == username && x.Matkhau == EncryptPassword(password) && x.Nhom == 3);
                    if (nhanvien != null)
                    {
                        string manv = nhanvien.Manv;

                        // Lưu thông tin đăng nhập vào session
                        HttpContext.Session.SetString("Username", username);
                        HttpContext.Session.SetString("Manv", manv);

                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "hocvu")
                };
                        var userIdentity = new ClaimsIdentity(claims, "login");
                        var principal = new ClaimsPrincipal(userIdentity);

                        HttpContext.SignInAsync(principal).Wait();

                        return RedirectToAction("Index", "Hocvien");
                    }
                }
                return RedirectToAction("Denied", "Dangnhap");
            }

            // Xử lý lỗi đăng nhập không thành công
            ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không hợp lệ.");
            return View();
        }

        public IActionResult tuVanVien()
        {
            return View();
        }
       
        private string EncryptPassword(string password)
        {
            // Thực hiện mã hóa mật khẩu ở đây (ví dụ: sử dụng BCrypt, SHA256, ...)
            // Trả về mật khẩu đã được mã hóa
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return password;
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
            //if (Request.Cookies["email"] != null && Request.Cookies["password"] != null)
            //{
            //    ViewBag.email = Request.Cookies["email"].ToString();
            //    ViewBag.password = Request.Cookies["password"].ToString();
            //}
            return View();
        }
        public IActionResult Index()
        {
            if (Request.Cookies["email"] != null && Request.Cookies["password"] != null)
            {
                ViewBag.email = Request.Cookies["email"].ToString();
                ViewBag.password = Request.Cookies["password"].ToString();
            }
            return View();
        }
        [HttpPost]
        public ActionResult kiemtradangnhap(string username, string password, string ghinho)
        {
            if (Request.Cookies["email"] != null && Request.Cookies["email"] != null)
            {
                username = Request.Cookies["email"].ToString();
                password = Request.Cookies["password"].ToString();
               
            }

            if (checkpassword(username, password))
            {
                var userSession = new Nhanvien();
                userSession.Email = username;
                userSession.Matkhau = password;
                //    //var listGroups = GetListGroupID(username);//Có thể viết dòng lệnh lấy các GroupID từ CSDL, ví dụ gán ="ADMIN", dùng List<string>

                //    //Session.Add("SESSION_GROUP", listGroups);
                //    //Session.Add("USER_SESSION", userSession);

                //    //if (ghinho == "on")//Ghi nhớ
                //    //    ghinhotaikhoan(username, password);
                //    return Redirect("~/Home");
                return RedirectToAction("Index", "Hocvien");
            }
            //}
            return RedirectToAction("Index");
        }
        public bool checkpassword(string username, string password)
        {
            if (db.Nhanviens.Where(x => x.Email == username && x.Matkhau == password).Count() > 0)

                return true;
            else
                return false;


        }
     
    }

}
