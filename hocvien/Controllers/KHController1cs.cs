using hocvien.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace hocvien.Controllers
{
    public class KHController1cs : Controller
    {
        private trungtamContext db = new trungtamContext();
        public IActionResult Index()
        {
            DateTime currentDate = DateTime.Now;
            int currentMonth = currentDate.Month;
            int currentYear = currentDate.Year;
            var openCourses = db.Khoahocs.Where(kh => kh.Ngaytao.Month == currentMonth && kh.Ngaytao.Year == currentYear).ToList();

            return View(openCourses);
        }
    }
}
