using hocvien.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace hocvien.Controllers
{
    //[Authorize(Roles = "quanly,tuyensinh")]
   // [Authorize(Roles = "học vụ")]
    public class KhoahocController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {
            
            if (TempData.ContainsKey("them"))
            {
                ViewBag.SuccessMessage = TempData["them"];
            }
            if (TempData.ContainsKey("sua"))
            {
                ViewBag.sua = TempData["sua"];
            }
            return View(db.Khoahocs.ToList());
        }
      
        public IActionResult formthemKhoahoc()
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;
            return View();
        }

        [HttpPost]
        public IActionResult themKhoahoc(Khoahoc kh)
        {
            if (ModelState.IsValid)
            {
                //kh.Makh = taoMaHocVien();
                //ma kh se la IEMMYYYY IE052023
                db.Khoahocs.Add(kh);
                db.SaveChanges();
                TempData["them"] = "Thêm khóa học thành công";
                return RedirectToAction("Index");
            }
            
            return View("formthemKhoahoc");


        }
        private string taoMaHocVien()
        {
            // Lấy mã học viên cuối cùng từ CSDL
            //var lastkh = db.Khoahocs.OrderByDescending(kh => kh.Makh).FirstOrDefault();
            //int lastId = lastkh != null ? int.Parse(lastkh.Makh.Substring(2)) : 0;

            // Tạo mã học viên mới
            // string newId = (lastId + 1).ToString("D3");
            string thangNamHienTai = DateTime.Now.ToString("MMyyyy");
            string maHocVien = "KH" + thangNamHienTai ;

            return maHocVien;
        }

        public IActionResult formXoakhoahoc(String id)
        {
            int dem = db.Loptuyensinhs.Where(a => a.Makh == id).ToList().Count();
            Model.Khoahoc x = db.Khoahocs.Find(id);
            ViewBag.flag = dem;

            return View(x);
        }
        public IActionResult xoaKhoahoc(String id)
        {
            Model.Khoahoc x = db.Khoahocs.Find(id);
            if (x != null)
            {
                db.Khoahocs.Remove(x);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult formSuakhoahoc(string id)
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;
            Model.Khoahoc x = db.Khoahocs.Find(id);
            return View(x);
        }
        [HttpPost]
        public IActionResult suaKhoahoc(Model.Khoahoc x)
        {
           
            if (ModelState.IsValid)
            {
                Model.Khoahoc kh = db.Khoahocs.Find(x.Makh);
                if (kh != null)
                {
                    kh.Tenkh = x.Tenkh;
                   // kh.Thoiluong = x.Thoiluong;
                    kh.Motakh = x.Motakh;
                    db.SaveChanges();
                }
                TempData["sua"] = "Sửa khóa học thành công";
                return RedirectToAction("Index");
            }

            return View("formSuakhoahoc");
        }
    }
}
