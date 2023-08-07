using hocvien.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace hocvien.Controllers
{
    [Authorize(Roles = "hocvu")]
    public class PhancongController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult ChonGiaoVien(string malophoc)
        {
           
            // Lấy danh sách giáo viên từ cơ sở dữ liệu
            var danhSachGiaoVien = db.Giaoviens.ToList();

            ViewBag.MaLopHoc = malophoc;
            ViewBag.DanhSachGiaoVien = danhSachGiaoVien;
            var danhSachLopGiaoVien = db.LophocGiaoviens
           .Include(l => l.MagvNavigation)
           .Where(l => l.Malophoc == malophoc)
           .ToList();

            ViewBag.DanhSachLopGiaoVien = danhSachLopGiaoVien;
            return View();
        }

        //[HttpPost]
        //public IActionResult PhanCongGiaoVien(string malophoc, string[] magv)
        //{
        //    var lopHoc = db.Lophocs.FirstOrDefault(l => l.Malophoc == malophoc);
        //    if (lopHoc == null)
        //    {
        //        // Handle the error or display a message that the class does not exist
        //        return RedirectToAction("DanhSachLopHoc");
        //    }
        //    foreach (var gv in magv)
        //    {
        //        var giaovien = db.Giaoviens.FirstOrDefault(g => g.Magv == gv);
        //        if (giaovien != null)
        //        {
        //            var lophocGiaovien = new LophocGiaovien
        //            {
        //                Malophoc = malophoc,
        //                Magv = gv
        //            };
        //            lopHoc.LophocGiaoviens.Add(lophocGiaovien);
        //        }
        //    }
        //    db.SaveChanges();

        //    return RedirectToAction("Index", "Xeplop");
        //}

        [HttpPost]
        public IActionResult PhanCongGiaoVien(string malophoc, string[] magv)
        {
            try
            {
                var lopHoc = db.Lophocs
                    .Include(l => l.LophocGiaoviens)
                    .ThenInclude(lg => lg.MagvNavigation)
                    .FirstOrDefault(l => l.Malophoc == malophoc);

                if (lopHoc == null)
                {
                   
                    return RedirectToAction("Index");
                }

                foreach (var gv in magv)
                {
                    var giaovien = db.Giaoviens.FirstOrDefault(g => g.Magv == gv);

                    if (giaovien != null)
                    {
                       
                        bool daXep = lopHoc.LophocGiaoviens.Any(lg =>
                            lg.MagvNavigation.Magv == gv &&
                            lg.MalophocNavigation.MaloptuyensinhNavigation.Macahoc == lopHoc.MaloptuyensinhNavigation.Macahoc &&
                            lg.MalophocNavigation.Ngaytao.Date == lopHoc.Ngaytao.Date);

                        if (!daXep)
                        {
                            var lophocGiaovien = new LophocGiaovien
                            {
                                Malophoc = malophoc,
                                Magv = gv
                            };
                            lopHoc.LophocGiaoviens.Add(lophocGiaovien);
                        }
                    }
                }
                db.SaveChanges();
                TempData["SuccessMessagePhanCong"] = "Phân công giáo viên thành công";
                return RedirectToAction("Index", "Xeplop");
            }
            catch (Exception ex)
            {
                TempData["ErrorPC"] = "Đã xảy ra lỗi khi phân công giáo viên";
            }
            return RedirectToAction("ChonGiaoVien");
        }


        public IActionResult formSuaPhanCongGiaoVien(string malophoc, string magv)
        {
          
            var lopHoc = db.Lophocs.FirstOrDefault(l => l.Malophoc == malophoc);
            var giaovien = db.Giaoviens.FirstOrDefault(g => g.Magv == magv);

            if (lopHoc == null || giaovien == null)
            {
               
                return RedirectToAction("Index", "Xeplop");
            }

     
            ViewBag.Malophoc = malophoc;
            ViewBag.Magv = magv;
            ViewBag.TeacherName = giaovien.Hoten; 

            return View();
        }


    }
}
