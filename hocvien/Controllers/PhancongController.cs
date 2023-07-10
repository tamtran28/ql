using hocvien.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace hocvien.Controllers
{
    public class PhancongController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ChonGiaoVien(string malophoc)
        {
            // Lấy danh sách giáo viên từ cơ sở dữ liệu
            var danhSachGiaoVien = db.Giaoviens.ToList();

            ViewBag.MaLopHoc = malophoc;
            ViewBag.DanhSachGiaoVien = danhSachGiaoVien;

            return View();
        }
        //[HttpPost]
        //public IActionResult PhanCongGiaoVien(string malophoc, string magv)
        //{
        //    var lopHoc = db.Lophocs.FirstOrDefault(l => l.Malophoc == malophoc);
        //    if (lopHoc == null)
        //    {
        //        // Xử lý lỗi hoặc thông báo lớp học không tồn tại
        //        return RedirectToAction("DanhSachLopHoc");
        //    }

        //    lopHoc.Magv = magv;

        //    db.SaveChanges();

        //    return RedirectToAction("Index","Xeplop");
        //}
        [HttpPost]
        public IActionResult PhanCongGiaoVien(string malophoc, string magv)
        {
            var lopHoc = db.Lophocs.FirstOrDefault(l => l.Malophoc == malophoc);
            if (lopHoc == null)
            {
                // Handle the error or display a message that the class does not exist
                return RedirectToAction("DanhSachLopHoc");
            }

            // Update the Magv property of the Lophoc entity
            //lopHoc.Magv = magv;

            // Save the changes to the database
            db.SaveChanges();

            // Create a new LophocGiaovien entity and add it to the lophoc_giaovien table
            var lophocGiaovien = new LophocGiaovien
            {
                Malophoc = malophoc,
                Magv = magv
            };

            db.LophocGiaoviens.Add(lophocGiaovien);
            db.SaveChanges();

            return RedirectToAction("Index", "Xeplop");
        }


    }
}
