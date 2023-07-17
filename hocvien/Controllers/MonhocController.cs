using hocvien.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;

namespace hocvien.Controllers
{
    [Authorize(Roles = "quanly,tuyensinh")]
    public class MonhocController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {

            return View(db.Monhocs.ToList());
        }
        public IActionResult formthemMonhoc()
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;
            return View();
        }

        [HttpPost]
        public IActionResult themMonhoc(Monhoc ts)
        {
            //ViewBag.ten = User.Identity.Name;
            db.Monhocs.Add(ts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult formXoamonhoc(String id)
        {
            int dem = db.Loptuyensinhs.Where(a => a.Makh == id).ToList().Count();
            Model.Monhoc x = db.Monhocs.Find(id);
            ViewBag.flag = dem;

            return View(x);
        }
        public IActionResult xoaMonhoc(String id)
        {
            Model.Monhoc x = db.Monhocs.Find(id);
            if (x != null)
            {
                db.Monhocs.Remove(x);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult formSuamonhoc(string id)
        {
            ViewBag.ten = User.Identity.Name;
            Model.Monhoc x = db.Monhocs.Find(id);
            return View(x);
        }
        [HttpPost]
        public IActionResult suaMonhoc(Model.Monhoc x)
        {
            if (ModelState.IsValid)
            {
                Model.Monhoc kh = db.Monhocs.Find(x.Mamh);
                if (kh != null)
                {
                    kh.Tenmh = x.Tenmh;
                    kh.Hocphi = x.Hocphi;
                    kh.Trangthai = x.Trangthai;


                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View("formSuamonhoc");
        }
    }
}
