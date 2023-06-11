using hocvien.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hocvien.Controllers
{
    public class HoadonController : Controller
    {
        centerContext db = new centerContext();
        public IActionResult Index()
        {
           // return View(db.Hoadons.ToList());
            return View(db.Hoadons.ToList());
        }
        public IActionResult formLapHD(string id)
        {
        
            ViewBag.Id = id;
            var courseFee = db.LopDangkyhocs
                   .Join(
                       db.Loptuyensinhs,
                       r => r.Maloptuyensinh,
                       a => a.Maloptuyensinh,
                       (r, a) => new { Phieudangkyhoc = r, Loptuyensinh = a }
                   )
                   .Join(
                       db.Monhocs,
                       a => a.Loptuyensinh.Mamh,
                       s => s.Mamh,
                       (a, s) => s.Hocphi
                   )
                   .FirstOrDefault();
            ViewBag.fee = courseFee;
            return View();
        }

        [HttpPost]
        public IActionResult hoaDon(Hoadon hd)
            {
               

            var existingInvoice = db.Hoadons.FirstOrDefault(x => x.Maphieu == hd.Maphieu);
            if (existingInvoice != null)
            {
                // Phiếu đăng ký đã được thanh toán
                ModelState.AddModelError("", "Phiếu đăng ký đã được thanh toán.");
                return RedirectToAction("formLapHD");
            }

            // Tạo hóa đơn cho phiếu đăng ký này
            
            hd.Mahd = taoMaHD();
          
            hd.Ngaythu = DateTime.Now;
               
            db.Hoadons.Add(hd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private string taoMaHD()
        {
            // Lấy mã học viên cuối cùng từ CSDL
            var lastHoaDOn = db.Hoadons.OrderByDescending(hv => hv.Mahd).FirstOrDefault();
            int lastId = lastHoaDOn != null ? int.Parse(lastHoaDOn.Mahd.Substring(2)) : 0;

            // Tạo mã học viên mới
            string newId = (lastId + 1).ToString("D4");
            string maHocVien = "HD" + newId;

            return maHocVien;
        }
    }
}
