using hocvien.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hocvien.Controllers
{
    public class KhoahocController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {
            //List<Models.Khoahoc> ds = db.Khoahocs.Select(a => new Models.Khoahoc
            //{
            //    Makh = a.Makh,
            //    Tenkh = a.Tenkh,
            //    Ngaytao = a.Ngaytao.Value.ToShortDateString(),
            //    //Gioitinh = (a.Gioitinh == 1 ? "Nam" : "Nữ"),
            //    Motakh = a.Motakh,
            //    Nguoitao = a.Nguoitao,
            //    Thoiluong = a.Thoiluong,
            //   // Trungtamhoc = a.Trungtamhoc


            //}).ToList();
            return View(db.Khoahocs.ToList());
        }
      
        public IActionResult formthemKhoahoc()
        {
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
                    kh.Thoiluong = x.Thoiluong;
                    kh.Motakh = x.Motakh;
                   

                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View("formSuakhoahoc");
        }
    }
}
