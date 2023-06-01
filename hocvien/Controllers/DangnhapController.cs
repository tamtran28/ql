using hocvien.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace hocvien.Controllers
{
    public class DangnhapController : Controller
    {
        private trungtamContext db = new trungtamContext();
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
