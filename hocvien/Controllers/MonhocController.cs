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
            if (TempData.ContainsKey("themMH"))
            {
                ViewBag.SuccessMessageMonHoc = TempData["themMH"];
            }
            if (TempData.ContainsKey("suaMH"))
            {
                ViewBag.suaMH = TempData["suaMH"];
            }
            if (TempData.ContainsKey("xoaMH"))
            {
                ViewBag.xoaMH = TempData["xoaMH"];
            }
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
            try
            {
                if (ModelState.IsValid)
                {
                    //kh.Makh = taoMaHocVien();
                    //ma kh se la IEMMYYYY IE052023
                    db.Monhocs.Add(ts);
                    db.SaveChanges();
                    TempData["themMH"] = "Thêm Môn học thành công";
                    return RedirectToAction("Index");
                }
                return View("formthemMonhoc", ts);
            }

            catch (Exception ex)
            {
                TempData["ErrorMessageThemKhoaHoc"] = "Đã xảy ra lỗi";
                return View("formthemMonhoc", ts);
            }

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
            TempData["xoaMH"] = "Xóa môn học thành công";
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
            try
            {
                if (ModelState.IsValid)
                {
                    Model.Monhoc kh = db.Monhocs.Find(x.Mamh);
                    if (kh != null)
                    {
                        kh.Tenmh = x.Tenmh;
                        kh.Hocphi = x.Hocphi;
                        kh.Trangthai = x.Trangthai;
                        kh.Mota = x.Mota;
                        db.SaveChanges();
                    }
                    TempData["suaMH"] = "Sửa môn học thành công";
                    return RedirectToAction("Index");
                }

                return View("formSuamonhoc", x);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessageSuaMonHoc"] = "Đã xảy ra lỗi";
                return View("formSuamonhoc", x);
            }
        }
    }
}
