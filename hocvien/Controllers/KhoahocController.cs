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
   
    //[Authorize(Roles = "học vụ")]
    public class KhoahocController : Controller
    {
        private centerContext db = new centerContext();
        [Authorize(Roles = "quanly,tuyensinh")]
        public IActionResult Index()
        {
            
            if (TempData.ContainsKey("them"))
            {
                ViewBag.SuccessMessage = TempData["them"];
            }
            if (TempData.ContainsKey("sua"))
            {
                ViewBag.sua = TempData["xoaKH"];
            }
            if (TempData.ContainsKey("xoaKH"))
            {
                ViewBag.xoa = TempData["xoaKH"];
            }
            return View(db.Khoahocs.ToList());
        }
        [Authorize(Roles = "quanly")]
        public IActionResult formthemKhoahoc()
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;
            return View();
        }

        [HttpPost]
        public IActionResult themKhoahoc(Khoahoc kh)
        {
            try
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
                return View("formthemKhoahoc",kh);
            }

            catch (Exception ex)
            {
                TempData["ErrorMessageThemKhoaHoc"] = "Đã xảy ra lỗi";
                return View("formthemKhoahoc", kh);
            }
           
            
           // return View("formthemKhoahoc");


        }
        private string taoMaHocVien()
        {
            
            string thangNamHienTai = DateTime.Now.ToString("MMyyyy");
            string maHocVien = "KH" + thangNamHienTai ;

            return maHocVien;
        }
        [Authorize(Roles = "quanly")]
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
            TempData["xoaKH"] = "Xóa khóa học thành công";
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "quanly")]
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
            try
            {
                if (ModelState.IsValid)
                {
                    Model.Khoahoc kh = db.Khoahocs.Find(x.Makh);
                    if (kh != null)
                    {
                        kh.Tenkh = x.Tenkh;
                         kh.Trangthai = x.Trangthai;
                        kh.Motakh = x.Motakh;
                        db.SaveChanges();
                    }
                    TempData["sua"] = "Sửa khóa học thành công";
                    return RedirectToAction("Index");
                }

                return View("formSuakhoahoc");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in a way suitable for your application
                TempData["ErrorMessageSuaKhoaHoc"] = "Đã xảy ra lỗi";
                return View("formSuakhoahoc", x); // Or return to the appropriate error view
            }
        }

    }
}
