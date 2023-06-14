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
//using BCrypt.Net;
namespace hocvien.Controllers
{
    public class DangnhapController : Controller
    {
        private centerContext db = new centerContext();

        //[HttpPost]
        //public IActionResult Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model.Role == "giáo viên")
        //        {
        //            var giaovien = db.Giaoviens.FirstOrDefault(gv => gv.Email == model.Email);
        //            if (giaovien != null && giaovien.Matkhau == EncryptPassword(model.Password))
        //            {
        //                // Đăng nhập thành công cho giáo viên
        //                // Lưu thông tin đăng nhập vào session hoặc cookie
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        else if (model.Role == "nhân viên")
        //        {
        //            var nhanvien = db.Nhanviens.FirstOrDefault(nv => nv.Email == model.Email);
        //            if (nhanvien != null && nhanvien.Matkhau == EncryptPassword(model.Password))
        //            {
        //                // Đăng nhập thành công cho nhân viên
        //                // Lưu thông tin đăng nhập vào session hoặc cookie
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //    }

        //    // Xử lý lỗi đăng nhập không thành công
        //    ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không hợp lệ.");
        //    return View(model);
        //}
        //private string EncryptPassword(string password)
        //{
        //    // Sử dụng BCrypt để mã hóa mật khẩu
        //    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        //    // Trả về mật khẩu đã được mã hóa
        //    return hashedPassword;
        //}

        //// Kiểm tra mật khẩu
        //private bool VerifyPassword(string password, string hashedPassword)
        //{
        //    // Sử dụng BCrypt để kiểm tra tính hợp lệ của mật khẩu
        //    bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

        //    // Trả về kết quả kiểm tra
        //    return isValidPassword;
        //}



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
        [HttpPost]
        public async Task<IActionResult> Login(Nhanvien model)
        {
            // Xác thực người dùng
            if (model.Email == "advisor" && model.Matkhau == "advisor123")
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "Advisor"),
            new Claim(ClaimTypes.Role, "Advisor")
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                    IsPersistent = false
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("AdvisorPage");
            }
            else if (model.Email == "academic" && model.Matkhau == "academic123")
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "Academic"),
            new Claim(ClaimTypes.Role, "Academic")
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                    IsPersistent = false
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("AcademicPage");
            }
            else if (model.Email == "manager" && model.Email == "manager123")
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "Manager"),
            new Claim(ClaimTypes.Role, "Manager")
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                    IsPersistent = false
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("ManagerPage");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }
        }


        //public void ghinhotaikhoan(string username, string password)
        //{
        //    HttpCookie us = new HttpCookie("email");
        //    HttpCookie pas = new HttpCookie("password");

        //    us.Value = username;
        //    pas.Value = password;

        //    us.Expires = DateTime.Now.AddDays(1);
        //    pas.Expires = DateTime.Now.AddDays(1);
        //    Response.Cookies.Add(us);
        //    Response.Cookies.Add(pas);

        //}
    }

}
