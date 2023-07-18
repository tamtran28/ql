using hocvien.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace hocvien.Controllers
{
    public class ThongkeController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult thongKepdk(int month)
        {
            int numberOfStudents = db.Phieudangkyhocs
          .Where(p => p.Ngaydk.HasValue && p.Ngaydk.Value.Month == month)
          .Count();


            ViewBag.NumberOfStudents = numberOfStudents;

            return View();
        }

    }
}
