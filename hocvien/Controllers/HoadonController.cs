//using hocvien.Model;
using hocvien.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace hocvien.Controllers
{
    [Authorize(Roles = "tuyensinh")]
    public class HoadonController : Controller
    {
        centerContext db = new centerContext();
        public IActionResult Index()
        {
           // return View(db.Hoadons.ToList());
            return View(db.Hoadons.ToList());
        }
        //public IActionResult formLapHD(string id)
        //{

        //    ViewBag.Id = id;
        //    var courseFee = db.LopDangkyhocs
        //           .Join(
        //               db.Loptuyensinhs,
        //               r => r.Maloptuyensinh,
        //               a => a.Maloptuyensinh,
        //               (r, a) => new { Phieudangkyhoc = r, Loptuyensinh = a }
        //           )
        //           .Join(
        //               db.Monhocs,
        //               a => a.Loptuyensinh.Mamh,
        //               s => s.Mamh,
        //               (a, s) => s.Hocphi
        //           )
        //           .FirstOrDefault();
        //    ViewBag.fee = courseFee;
        //    return View();
        //}
        //public IActionResult formLapHD(string id, List<string> selectedClasses)
        //{

        //    ViewBag.Id = id;
        //   var  courseFee = CalculateTotalPayment(selectedClasses);
        //    ViewBag.fee = courseFee;
        //    return View();
        //}
        //private decimal CalculateTotalPayment(List<string> selectedClasses)
        //{
        //    decimal totalPayment = 0;

        //    foreach (var selectedClass in selectedClasses)
        //    {
        //        var courseFee = db.LopDangkyhocs
        //            .Join(
        //                db.Loptuyensinhs,
        //                r => r.Maloptuyensinh,
        //                a => a.Maloptuyensinh,
        //                (r, a) => new { Phieudangkyhoc = r, Loptuyensinh = a }
        //            )
        //            .Join(
        //                db.Monhocs,
        //                a => a.Loptuyensinh.Mamh,
        //                s => s.Mamh,
        //                (a, s) => s.Hocphi
        //            )
        //            .FirstOrDefault(c => c.Phieudangkyhoc.Maphieu == selectedClass);

        //        if (courseFee != null)
        //        {
        //            totalPayment += courseFee;
        //        }
        //    }

        //    return totalPayment;
        //}

        
        //2806
        public IActionResult search()
        {
            return View();
        }
        //[HttpGet]
        //public IActionResult timKiem(string id)
        //{
        //    List<LopDangkyhoc> dsLopDangKy = db.LopDangkyhocs
        //        .Include(ldk => ldk.MaloptuyensinhNavigation)
        //        .Where(ldk => ldk.MaphieuNavigation.Maphieu.Contains(id) || ldk.MaphieuNavigation.MahvNavigation.Hoten.Contains(id))
        //        .ToList();

        //    return PartialView(dsLopDangKy);
        //}

        //[HttpGet]
        //public IActionResult timKiem1(string id)
        //{
        //    List<LopDangkyhoc> dsLopDangKy = db.LopDangkyhocs
        //        .Include(ldk => ldk.MaloptuyensinhNavigation)
        //        .Where(ldk => (ldk.MaphieuNavigation.Maphieu.Contains(id) || ldk.MaphieuNavigation.MahvNavigation.Hoten.Contains(id)) && ldk.Trangthai == 0)
        //        .ToList();

        //    return PartialView(dsLopDangKy);
        //}
        [HttpGet]
        public IActionResult timKiem(string id)
        {
            List<Phieudangkyhoc> dsPhieuDangKy = db.Phieudangkyhocs
                .Where(pdk => pdk.Maphieu.Contains(id) || pdk.MahvNavigation.Hoten.Contains(id))
                .ToList();

            return PartialView(dsPhieuDangKy);
        }

        //[HttpPost]
        //public IActionResult formLapHD(List<string> selectedClasses, string maphieu)
        //{

        //    //28/6
        //    var hoadon = db.Phieudangkyhocs.Find(maphieu);


        //    if (hoadon != null)
        //    {
        //        // Lấy thông tin học viên từ bảng Phieudangkyhoc
        //        var phieudangkyhoc = db.Phieudangkyhocs
        //            .Include(pdk => pdk.MahvNavigation)
        //            .FirstOrDefault(pdk => pdk.Maphieu == hoadon.Maphieu);


        //        // Tính toán số tiền đã đóng
        //        //   decimal sotienDaDong = hoadon.Tongtienthanhtoan - hoadon.Conlai;
        //        decimal totalCourseFee = 0;
        //        foreach (var classId in selectedClasses)
        //        {
        //            var TongTien = db.LopDangkyhocs
        //           .Join(
        //               db.Loptuyensinhs,
        //               r => r.Maloptuyensinh,
        //               a => a.Maloptuyensinh,
        //               (r, a) => new { Phieudangkyhoc = r, Loptuyensinh = a }
        //           )
        //           .Join(
        //               db.Monhocs,
        //               a => a.Loptuyensinh.Mamh,
        //               s => s.Mamh,
        //               (a, s) => s.Hocphi
        //           )
        //           .FirstOrDefault();

        //            if (TongTien != null)
        //            {
        //                totalCourseFee += TongTien;
        //            }
        //            // Truyền thông tin hóa đơn, học viên, danh sách lớp đăng ký, tổng tiền, số tiền đã trả, số tiền còn lại và số tiền đã đóng vào view
        //            ViewBag.Hoadon = hoadon;
        //            ViewBag.Hocvien = phieudangkyhoc?.MahvNavigation;
        //            ViewBag.LopDangkyhocs = selectedClasses;
        //            ViewBag.TongTien = totalCourseFee;
        //            //ViewBag.SoTienDaTra = sotienDaDong;
        //            //ViewBag.SoTienConLai = hoadon.Conlai;
        //            //ViewBag.SoTienDaDong = sotienDaDong;

        //            return View();
        //        }
        //    }

        //    return RedirectToAction("Index"); // Hoặc tr

        //}


        //[HttpPost]
        //public IActionResult formLapHD(List<string> selectedClasses, string maphieu)
        //{
        //    var hoadon = db.Phieudangkyhocs.Find(maphieu);

        //    if (hoadon != null)
        //    {
        //        var phieudangkyhoc = db.Phieudangkyhocs
        //            .Include(pdk => pdk.MahvNavigation)
        //            .FirstOrDefault(pdk => pdk.Maphieu == hoadon.Maphieu);

        //        decimal totalCourseFee = 0;

        //        foreach (var classId in selectedClasses)
        //        {
        //            var TongTien = db.LopDangkyhocs
        //                .Join(
        //                    db.Loptuyensinhs,
        //                    r => r.Maloptuyensinh,
        //                    a => a.Maloptuyensinh,
        //                    (r, a) => new { LopDangkyhoc = r, Loptuyensinh = a }
        //                )
        //                .Join(
        //                    db.Monhocs,
        //                    a => a.Loptuyensinh.Mamh,
        //                    s => s.Mamh,
        //                    (a, s) => new { LopDangkyhoc = a.LopDangkyhoc, Hocphi = s.Hocphi }
        //                )
        //                .FirstOrDefault(a => a.LopDangkyhoc.Maloptuyensinh == classId);

        //            if (TongTien != null)
        //            {
        //                totalCourseFee += TongTien.Hocphi;
        //            }
        //        }
        //        ViewBag.maphieu = maphieu;
        //        ViewBag.Hoadon = hoadon;
        //        ViewBag.Hocvien = phieudangkyhoc?.MahvNavigation;
        //        ViewBag.LopDangkyhocs = selectedClasses;
        //        ViewBag.TongTien = totalCourseFee;
        //        //ViewBag.SoTienDaTra = sotienDaDong;
        //        //ViewBag.SoTienConLai = hoadon.Conlai;
        //        return View();
        //    }

        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public IActionResult formLapHD(string maphieu)
        {
            var hoadon = db.Phieudangkyhocs.Find(maphieu);

            if (hoadon != null)
            {
                var lopDangKyHocs = db.LopDangkyhocs
                    .Where(ldk => ldk.Maphieu == maphieu)
                    .ToList();

                var malopTuyenSinhs = lopDangKyHocs.Select(ldk => ldk.Maloptuyensinh).ToList();
                //var hocvien = hoadon.MahvNavigation;
                ViewBag.maphieu = maphieu;
                //ViewBag.Hocvien =hocvien.Hoten ;
                ViewBag.LopDangkyhocs = malopTuyenSinhs;
                ViewBag.TongTien = hoadon.tongtien; 
                if (decimal.Equals(hoadon.Sotienconlai, decimal.Zero))
                {
                    // Redirect to the detailed invoice page
                    return RedirectToAction("chiTiethoadon","Hoadon", new { maphieu = maphieu });
                }
                ViewBag.SoTienDaTra = hoadon.Sotiendatra;
                ViewBag.SoTienConLai = hoadon.Sotienconlai;
               

                return View();
            }

            return RedirectToAction("Index");
        }



        
        [HttpPost]
        public IActionResult hoaDon(Hoadon hd, string maphieu, int sotien)
        {
            string manv = HttpContext.Session.GetString("Manv");

            // Tạo mã hóa đơn
            hd.Mahd = taoMaHD();
            hd.Ngaythu = DateTime.Now;
            hd.Manv = manv;
            hd.Trangthaithanhtoan = "Thanh toán";
            hd.Maphieu = maphieu;

            // Lưu số tiền đã đóng
            hd.Sotiendatra = sotien;

            // Tính tổng tiền cần thanh toán lấy ở phieudangky
            var phieudangkyhoc = db.Phieudangkyhocs.FirstOrDefault(p => p.Maphieu == maphieu);
            if (phieudangkyhoc != null)
            {
                hd.Tongtienthanhtoan = phieudangkyhoc.tongtien;
                hd.Sotienconlai = phieudangkyhoc.tongtien - hd.Sotiendatra.Value;

                // Check if sotienconlai is equal to 0
                if (decimal.Equals(phieudangkyhoc.Sotienconlai, decimal.Zero))
                {
                    // Redirect to the detailed invoice page without creating a new invoice or updating the remaining amount
                    return RedirectToAction("chiTiethoadon", new { mahd = hd.Mahd });
                }

                // Lưu hóa đơn vào cơ sở dữ liệu
                db.Hoadons.Add(hd);
                db.SaveChanges();

                // Update the remaining amount and amount paid in Phieudangkyhoc table
                phieudangkyhoc.Sotiendatra += sotien;
                phieudangkyhoc.Sotienconlai = phieudangkyhoc.tongtien - phieudangkyhoc.Sotiendatra.Value;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult chiTiethoadon()
        {

            return View();
        }


        // Hàm tính tổng tiền cần thanh toán dựa trên mã phiếu đăng ký
        //private decimal TinhTongTienThanhToan(string maphieu)
        //{
        //    var tongtien = db.LopDangkyhocs
        //        .Where(ldk => ldk.Maphieu == maphieu ) // Chỉ tính tổng tiền cho những lớp chưa được thanh toán
        //        .Join(
        //            db.Loptuyensinhs,
        //            ldk => ldk.Maloptuyensinh,
        //            lt => lt.Maloptuyensinh,
        //            (ldk, lt) => new { LopDangkyhoc = ldk, Loptuyensinh = lt }
        //        )
        //        .Join(
        //            db.Monhocs,
        //            a => a.Loptuyensinh.Mamh,
        //            s => s.Mamh,
        //            (a, s) => s.Hocphi
        //        )
        //        .Sum();

        //    return tongtien;
        //}



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
        public IActionResult formXoahoadon(string id)
        {
            Model.Hoadon x = db.Hoadons.Find(id);
            return View(x);
        }
        [HttpPost]
        public IActionResult xoaHoadon(string mahd)
        {

            Model.Hoadon x = db.Hoadons.Find(mahd);
            if (x != null)
            {
                db.Hoadons.Remove(x);
                db.SaveChanges();
            }


            db.SaveChanges();

            // Return a success response
            return RedirectToAction("Index");
        }
        public IActionResult formSuahoadon(string id)
        {
            ViewBag.ten = User.Identity.Name;
            Model.Hocvien x = db.Hocviens.Find(id);

            return View(x);
        }
        [HttpPost]
        public IActionResult suaHoadon(Model.Hoadon x)
        {

            if (ModelState.IsValid)
            {
                Model.Hoadon hd = db.Hoadons.Find(x.Mahd);
                if (hd != null)
                {
                    hd.Ngaythu = x.Ngaythu;
                    hd.Tongtienthanhtoan = x.Tongtienthanhtoan;
                    hd.Ghichu = x.Ghichu;
                    hd.Hinhthuc = x.Hinhthuc;
                    hd.Trangthaithanhtoan = x.Trangthaithanhtoan;
                    hd.Manv = x.Manv;
                    // hd.Maphieu = x.Maphieu;
                }
                TempData["SuaSuccessMessage"] = "Sửa thành công";
                return RedirectToAction("Index");
            }

            return View("formSuahoadon");
        }

    }
}
