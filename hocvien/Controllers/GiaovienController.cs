using hocvien.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace hocvien.Controllers
{
    public class GiaovienController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {
            return View(db.Giaoviens.ToList());
        }

        public IActionResult formthemGiaovien()
        {
            return View();
        }

        [HttpPost]
        public IActionResult themGiaovien(Giaovien kh)
        {
            if (ModelState.IsValid)
            {
                kh.Magv = taoMagiaovien();
                db.Giaoviens.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("formthemGiaovien");


        }
        private string taoMagiaovien()
        {
            // Lấy mã học viên cuối cùng từ CSDL
            var lastgv = db.Giaoviens.OrderByDescending(gv => gv.Magv).FirstOrDefault();
            int lastId = lastgv != null ? int.Parse(lastgv.Magv.Substring(2)) : 0;

            // Tạo mã học viên mới
            string newId = (lastId + 1).ToString("D3");
            string maHocVien = "GV" + newId;

            return maHocVien;
        }
        public IActionResult formXoaGiaoVien(String id)
        {
            int dem = db.Lophocs.Where(a => a.Magv == id).ToList().Count();
            Model.Giaovien x = db.Giaoviens.Find(id);
            ViewBag.flag = dem;

            return View(x);
        }
        public IActionResult xoaHocVien(String id)
        {
            Model.Giaovien x = db.Giaoviens.Find(id);
            if (x != null)
            {
                db.Giaoviens.Remove(x);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}
