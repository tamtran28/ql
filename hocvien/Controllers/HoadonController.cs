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
            var hoadons = db.Hoadons.OrderByDescending(hd => hd.Ngaythu).ToList();

            return View(hoadons);
        }
        public IActionResult search()
        {
            return View();
        }


        [HttpGet]
        public IActionResult timKiem(string id)
        {
            List<Phieudangkyhoc> dsPhieuDangKy = db.Phieudangkyhocs
                .Include(pdk => pdk.MahvNavigation)
                .Include(pdk => pdk.LopDangkyhocs)
                    .ThenInclude(ldk => ldk.MaloptuyensinhNavigation)
                        .ThenInclude(lt => lt.MakhNavigation)
                .Where(pdk => pdk.Maphieu.Contains(id) || pdk.MahvNavigation.Hoten.Contains(id))
                .ToList();

            if (dsPhieuDangKy.Count == 0)
            {
                ViewBag.Message = "Chưa có phiếu đăng ký";
            }

            return PartialView(dsPhieuDangKy);
        }
        [HttpPost]
        public IActionResult formLapHD(string maphieu, string mahv)
        {
            var hoadon = db.Phieudangkyhocs.Find(maphieu);

            if (hoadon != null)
            {
                var lopDangKyHocs = db.LopDangkyhocs
                    .Where(a => a.Maphieu == maphieu)
                    .Join(db.Loptuyensinhs,
                        a => a.Maloptuyensinh,
                        b => b.Maloptuyensinh,
                        (a, b) => new
                        {
                            a.Maloptuyensinh,
                            b.Ngaybatdau,
                            b.Ngayketthuc,
                            b.Macahoc
                        })
                    .Join(db.Cahocs,
                        b   => b.Macahoc,
                        c => c.Macahoc,
                        (b, c) => new
                        {
                            b.Maloptuyensinh,
                            b.Ngaybatdau,
                            b.Ngayketthuc,
                            c.Macahoc,
                            c.Thuhoc,
                            c.Giohoc
                        })
                    .ToList();

                var malopTuyenSinhs = lopDangKyHocs.Select(ldk => ldk.Maloptuyensinh).ToList();
                var ngayBatDauList = lopDangKyHocs.Select(ldk => ldk.Ngaybatdau).ToList();
                var ngayKetThucList = lopDangKyHocs.Select(ldk => ldk.Ngayketthuc).ToList();
                var caHocList = lopDangKyHocs.Select(ldk => ldk.Macahoc).ToList();
                var thuHocList = lopDangKyHocs.Select(ldk => ldk.Thuhoc).ToList();
                var gioHocList = lopDangKyHocs.Select(ldk => ldk.Giohoc).ToList();

                var hocvien = db.Hocviens.FirstOrDefault(hv => hv.Mahv == mahv);
                if (hocvien != null)
                {
                    ViewBag.Hocvien = hocvien.Hoten;
                    ViewBag.NgaySinh = hocvien.Ngaysinh;
                    ViewBag.GioiTinh = hocvien.Gioitinh == 1 ? "Nam" : "Nữ";
                    ViewBag.SDT = hocvien.Sdt;
                }
                ViewBag.maphieu = maphieu;
                ViewBag.LopDangkyhocs = malopTuyenSinhs;
                ViewBag.NgayBatDauList = ngayBatDauList;
                ViewBag.NgayKetThucList = ngayKetThucList;
                ViewBag.CaHocList = caHocList;
                ViewBag.ThuHocList = thuHocList;
                ViewBag.GioHocList = gioHocList;
                ViewBag.TongTien = hoadon.tongtien;

                var nearestInvoice = db.Hoadons
               .Where(h => h.Maphieu == maphieu && h.Sotienconlai == decimal.Zero)
               .OrderByDescending(h => h.Ngaythu)
               .FirstOrDefault();

                if (nearestInvoice != null)
                {
                    return RedirectToAction("chiTiethoadon", "Hoadon", new { mahd = nearestInvoice.Mahd });
                }
                ViewBag.SoTienDaTra = hoadon.Sotiendatra;
                ViewBag.SoTienConLai = hoadon.Sotienconlai;

                return View();
            }

            return View();
        }



        [HttpPost]
        public IActionResult hoaDon(Hoadon hd, string maphieu, int sotien)
        {
            string manv = HttpContext.Session.GetString("Manv");
            // Tạo mã hóa đơn
            hd.Mahd = taoMaHD();
            hd.Ngaythu = DateTime.Now;
            hd.Manv = manv;
            //  hd.Trangthaithanhtoan = "Thanh toán";
            hd.Maphieu = maphieu;
            decimal sotiendatra = decimal.Parse(Request.Form["sotiendatra"]);
            // decimal soTienDaTra = sotiendatra;

            // Tính số tiền đã trả mới
            decimal soTienDaTraMoi = sotiendatra + sotien;
            // Lưu số tiền đã đóng
            hd.Sotiendatra = soTienDaTraMoi;

            var phieudangkyhoc = db.Phieudangkyhocs.FirstOrDefault(p => p.Maphieu == maphieu);
            if (phieudangkyhoc != null)
            {
                hd.Tongtienthanhtoan = phieudangkyhoc.tongtien;
                hd.Sotienconlai = phieudangkyhoc.tongtien - hd.Sotiendatra.Value;

                if (decimal.Equals(phieudangkyhoc.Sotienconlai, decimal.Zero))
                {
                    hd.Trangthaithanhtoan = "Đã thanh toán";
                }
                else
                {
                    hd.Trangthaithanhtoan = "Còn thiếu: " + hd.Sotienconlai;
                }
                // Lưu hóa đơn vào cơ sở dữ liệu
                db.Hoadons.Add(hd);
                db.SaveChanges();


                phieudangkyhoc.Sotiendatra = soTienDaTraMoi;
                phieudangkyhoc.Sotienconlai = hd.Tongtienthanhtoan - phieudangkyhoc.Sotiendatra.Value;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult chiTiethoadon(string mahd)
        {
            var hoadon = db.Hoadons.Find(mahd);
            var phieudangky = db.Phieudangkyhocs.FirstOrDefault(p => p.Hoadons.Any(h => h.Mahd == mahd));

            if (phieudangky != null)
            {
                var lopDangKyHocs = db.LopDangkyhocs
                    .Where(a => a.Maphieu == phieudangky.Maphieu)
                    .Join(db.Loptuyensinhs,
                        a => a.Maloptuyensinh,
                        b => b.Maloptuyensinh,
                        (a, b) => new
                        {
                            a.Maloptuyensinh,
                            b.Ngaybatdau,
                            b.Ngayketthuc,
                            b.Macahoc
                        })
                    .Join(db.Cahocs,
                        b => b.Macahoc,
                        c => c.Macahoc,
                        (b, c) => new
                        {
                            b.Maloptuyensinh,
                            b.Ngaybatdau,
                            b.Ngayketthuc,
                            c.Macahoc,
                            c.Thuhoc,
                            c.Giohoc
                        })
                    .ToList();

                var malopTuyenSinhs = lopDangKyHocs.Select(ldk => ldk.Maloptuyensinh).ToList();
                var ngayBatDauList = lopDangKyHocs.Select(ldk => ldk.Ngaybatdau).ToList();
                var ngayKetThucList = lopDangKyHocs.Select(ldk => ldk.Ngayketthuc).ToList();
                var caHocList = lopDangKyHocs.Select(ldk => ldk.Macahoc).ToList();
                var thuHocList = lopDangKyHocs.Select(ldk => ldk.Thuhoc).ToList();
                var gioHocList = lopDangKyHocs.Select(ldk => ldk.Giohoc).ToList();

                var hocvien = db.Hocviens.FirstOrDefault(hv => hv.Mahv == phieudangky.Mahv);
                if (hocvien != null)
                {
                    ViewBag.Hocvien = hocvien.Hoten;
                    ViewBag.NgaySinh = hocvien.Ngaysinh;
                    ViewBag.GioiTinh = hocvien.Gioitinh == 1 ? "Nam" : "Nữ";
                    ViewBag.SDT = hocvien.Sdt;
                }
                ViewBag.maphieu = phieudangky.Maphieu;
                ViewBag.LopDangkyhocs = malopTuyenSinhs;
                ViewBag.NgayBatDauList = ngayBatDauList;
                ViewBag.NgayKetThucList = ngayKetThucList;
                ViewBag.CaHocList = caHocList;
                ViewBag.ThuHocList = thuHocList;
                ViewBag.GioHocList = gioHocList;
                ViewBag.TongTien = hoadon.Tongtienthanhtoan;
                //if (decimal.Equals(hoadon.Sotienconlai, decimal.Zero))
                //{
                //    // Redirect to the detailed invoice page
                //    return RedirectToAction("chiTiethoadon", "Hoadon", new { maphieu = phieudangky.Maphieu });
                //}
                ViewBag.SoTienDaTra = hoadon.Sotiendatra;
                ViewBag.SoTienConLai = hoadon.Sotienconlai;

                return View();
            }

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
