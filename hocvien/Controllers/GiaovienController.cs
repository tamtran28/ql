using hocvien.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace hocvien.Controllers
{
    //[Authorize(Roles = "học vụ")]
    public class GiaovienController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {
            return View(db.Giaoviens.ToList());
        }

        public IActionResult formthemGiaovien()
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;
            return View();
        }

        //[HttpPost]
        //public IActionResult themGiaovien(Giaovien kh)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        kh.Magv = taoMagiaovien();
        //        db.Giaoviens.Add(kh);
        //        db.SaveChanges();
        //        TempData["SuccessMessage"] = "Thêm gi viên thành công";
        //        return RedirectToAction("Index");
        //    }
        //    return View("formthemGiaovien");


        //}
        [HttpPost]
        public IActionResult themGiaovien(Giaovien gv)
        {
            if (gv.Ngaysinh.Year >= DateTime.Now.Year || (DateTime.Now.Year - gv.Ngaysinh.Year) < 18)
            {
                ModelState.AddModelError("Ngaysinh", "Ngày sinh không hợp lệ.");
                return RedirectToAction("formthemGiaovien");
            }

            gv.Magv = taoMagiaovien();
            db.Giaoviens.Add(gv);
            db.SaveChanges();

            TempData["SuccessMessage"] = "Thêm học viên thành công";
            return RedirectToAction("Index");


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
            int dem = db.LophocGiaoviens.Where(a => a.Magv == id).ToList().Count();
            Model.Giaovien x = db.Giaoviens.Find(id);
            ViewBag.flag = dem;

            return View(x);
        }
        public IActionResult xoaGiaoVien(String id)
        {
            Model.Giaovien x = db.Giaoviens.Find(id);
            if (x != null)
            {
                db.Giaoviens.Remove(x);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult formSuaGiaovien(string id)
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;
            Model.Hocvien x = db.Hocviens.Find(id);

            return View(x);
        }
        [HttpPost]
        public IActionResult suaGiaovien(Model.Giaovien x)
        {

            if (ModelState.IsValid)
            {
                Model.Giaovien hv = db.Giaoviens.Find(x.Magv);
                if (hv != null)
                {
                    hv.Hoten = x.Hoten;
                    hv.Ngaysinh = x.Ngaysinh;
                    if (x.Ngaysinh.Year >= DateTime.Now.Year || (DateTime.Now.Year - x.Ngaysinh.Year) < 18)
                    {
                        ModelState.AddModelError("Ngaysinh", "Ngày sinh không hợp lệ.");
                        return View("formSuaHocvien", x);
                    }
                    hv.Gioitinh = x.Gioitinh;
                    hv.Sdt = x.Sdt;
                    
                    hv.Diachi = x.Diachi;
                    hv.Capdoday = x.Capdoday;
                    hv.Trinhdo = x.Trinhdo;
                    hv.Ngaytao = x.Ngaytao;
                    hv.Nguoitao = x.Nguoitao;
                    db.SaveChanges();
                }
                TempData["SuaSuccessMessage"] = "Sửa giáo viên thành công";
                return RedirectToAction("Index");
            }

            return View("formSuaHocvien");
        }
    }
}
