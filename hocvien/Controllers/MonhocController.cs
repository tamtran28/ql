using hocvien.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace hocvien.Controllers
{
    public class MonhocController : Controller
    {
        private trungtamContext db = new trungtamContext();
        public IActionResult Index()
        {
            return View(db.Monhocs.ToList());
        }
        public IActionResult formthemMonhoc()
        {
            return View();
        }

        [HttpPost]
        public IActionResult themMonhoc(Monhoc ts)
        {
            //if (hocVien.Ngaysinh.Value.Year >= DateTime.Now.Year || (DateTime.Now.Year - hocVien.Ngaysinh.Value.Year) < 4)
            //{
            //    ModelState.AddModelError("Ngaysinh", "Ngày sinh không hợp lệ.");
            //    return View(hocVien);
            //}

            //ts.Ma = taoMaHocVien();
            db.Monhocs.Add(ts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
