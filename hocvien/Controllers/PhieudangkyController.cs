﻿
using hocvien.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace hocvien.Controllers
{
    //[Authorize(Roles = "tuyển sinh")]
    public class PhieudangkyController : Controller
    {
        private centerContext db = new centerContext();

        public IActionResult Index()
        {


            //dung
            var danhSachPhieuDangKy = db.Hocviens
            .Join(db.Phieudangkyhocs,
                r => r.Mahv,
                s => s.Mahv,
                (r, s) => new { Hocvien = r, Phieudangkyhoc = s })
            .Join(db.LopDangkyhocs, s => s.Phieudangkyhoc.Maphieu, n => n.Maphieu, (s, n) => new { Phieudangkyhoc = s, LopDangkyhoc = n })
            .Join(db.Loptuyensinhs,
            s => s.LopDangkyhoc.Maloptuyensinh,
            j => j.Maloptuyensinh,
            (s, j) => new CPhieuDangKy
            {
                Maphieu = s.Phieudangkyhoc.Phieudangkyhoc.Maphieu,
                Mahv = s.Phieudangkyhoc.Hocvien.Mahv,
                Hoten = s.Phieudangkyhoc.Hocvien.Hoten,
                Ngaydk = s.Phieudangkyhoc.Phieudangkyhoc.Ngaydk,
                Maloptuyensinh = s.LopDangkyhoc.Maloptuyensinh,
                Tenloptuyensinh = j.Tenloptuyensinh,
            });
            return View(danhSachPhieuDangKy);
        }
    
    public IActionResult formThemphieudangky(string id)
        {
            // Retrieve the selected classes from the session
            List<string> selectedClasses = MySessions.GetList<string>(HttpContext.Session, "selectedClasses");

            return View();
        }


        public IActionResult SearchCourse()
        {
            ViewBag.DSLop = new SelectList(db.Khoahocs.ToList(), "Makh", "Tenkh");
            // HttpContext.Session.SetString("Maloptuyensinh", maLopHoc);

            return View();
            // return RedirectToAction("formThemphieudangky", "Phieudangky");
        }

        [HttpPost]
        public IActionResult SelectCourse(string[] selectedClasses)
        {
            //MySessions.SetList<string>(HttpContext.Session, "selectedClasses", selectedClasses.ToList());

            List<string> selectedClassesList = selectedClasses?.ToList();
            MySessions.SetList<string>(HttpContext.Session, "selectedClasses", selectedClassesList);
            return RedirectToAction("formThemphieudangky", "Phieudangky");
        }
        public IActionResult SearchStudent(String kh)
        {
           // ViewBag.Kh = kh;
            return View();
        }








        //public IActionResult registration(string id)
        //{
        //    decimal totalCourseFee = 0;
        //    ViewBag.s = id;
        //    List<string> selectedClasses = MySessions.GetList<string>(HttpContext.Session, "selectedClasses");
        //    ViewBag.SelectedClasses = selectedClasses;

        //    var phieudangky = db.Phieudangkyhocs.FirstOrDefault(p => p.Mahv == id);

        //    if (phieudangky != null)
        //    {
        //        var lopDangKyHocs = db.LopDangkyhocs
        //            .Where(a => a.Maphieu == phieudangky.Maphieu)
        //            .Join(db.Loptuyensinhs,
        //                a => a.Maloptuyensinh,
        //                b => b.Maloptuyensinh,
        //                (a, b) => new
        //                {
        //                    a.Maloptuyensinh,
        //                    b.Ngaybatdau,
        //                    b.Makh,
        //                    b.Mamh,
        //                    b.Ngayketthuc,
        //                    b.Macahoc
        //                })
        //            .Join(db.Cahocs,
        //                b => b.Macahoc,
        //                c => c.Macahoc,
        //                (b, c) => new
        //                {
        //                    b.Maloptuyensinh,
        //                    b.Ngaybatdau,
        //                    b.Ngayketthuc,
        //                    b.Makh,
        //                    b.Mamh,
        //                    c.Macahoc,
        //                    c.Thuhoc,
        //                    c.Giohoc
        //                })
        //            .ToList();

        //        var malopTuyenSinhs = lopDangKyHocs.Select(ldk => ldk.Maloptuyensinh).ToList();
        //        var ngayBatDauList = lopDangKyHocs.Where(ldk => malopTuyenSinhs.Contains(ldk.Maloptuyensinh))
        //                                          .Select(ldk => ldk.Ngaybatdau)
        //                                          .ToList();
        //        var ngayKetThucList = lopDangKyHocs.Select(ldk => ldk.Ngayketthuc).ToList();
        //        var caHocList = lopDangKyHocs.Select(ldk => ldk.Macahoc).ToList();
        //        var thuHocList = lopDangKyHocs.Select(ldk => ldk.Thuhoc).ToList();
        //        var gioHocList = lopDangKyHocs.Select(ldk => ldk.Giohoc).ToList();

        //        var mamh = lopDangKyHocs.Select(ldk => ldk.Mamh).ToList();
        //        var makh = lopDangKyHocs.Select(ldk => ldk.Makh).ToList();
        //        var hocvien = db.Hocviens.FirstOrDefault(hv => hv.Mahv == phieudangky.Mahv);
        //        if (hocvien != null)
        //        {
        //            ViewBag.Hocvien = hocvien.Hoten;
        //            ViewBag.NgaySinh = hocvien.Ngaysinh;
        //            ViewBag.GioiTinh = hocvien.Gioitinh == 1 ? "Nam" : "Nữ";
        //            ViewBag.SDT = hocvien.Sdt;
        //        }
        //        foreach (var malop in selectedClasses)
        //        {
        //            var TongTien = db.Loptuyensinhs
        //                .Where(ldk => ldk.Maloptuyensinh == malop)
        //                .Join(
        //                    db.Monhocs,
        //                    ldk => ldk.Mamh,
        //                    mh => mh.Mamh,
        //                    (ldk, mh) => mh.Hocphi
        //                )
        //                .FirstOrDefault();

        //            if (TongTien != null)
        //            {
        //                totalCourseFee += TongTien;
        //            }
        //        }
        //        ViewBag.maphieu = phieudangky.Maphieu;
        //        ViewBag.LopDangkyhocs = malopTuyenSinhs;
        //        ViewBag.NgayBatDauList = ngayBatDauList;
        //        ViewBag.NgayKetThucList = ngayKetThucList;
        //        ViewBag.CaHocList = caHocList;
        //        ViewBag.ThuHocList = thuHocList;
        //        ViewBag.GioHocList = gioHocList;
        //        ViewBag.Tongtien = totalCourseFee;
        //        ViewBag.makh = makh;
        //        ViewBag.mamh = mamh;
        //        return View();
        //    }

        //    return View("Error"); // Xử lý khi không tìm thấy phiếu đăng ký
        //}

        public IActionResult registration(string id)
{
    ViewBag.s = id;
    List<string> selectedClasses = MySessions.GetList<string>(HttpContext.Session, "selectedClasses");
    ViewBag.SelectedClasses = selectedClasses;

    var hocvien = db.Hocviens.FirstOrDefault(hv => hv.Mahv == id);
    if (hocvien != null)
    {
        ViewBag.Hocvien = hocvien.Hoten;
        ViewBag.NgaySinh = hocvien.Ngaysinh;
        ViewBag.GioiTinh = hocvien.Gioitinh == 1 ? "Nam" : "Nữ";
        ViewBag.SDT = hocvien.Sdt;
    }

    var lopTuyenSinhs = db.Loptuyensinhs
        .Where(lts => selectedClasses.Contains(lts.Maloptuyensinh))
        .ToList();

    ViewBag.LopTuyenSinhs = lopTuyenSinhs;

    return View();
}


        // Handle the case when the "maphieu" does not exist




        [HttpPost]
        public IActionResult CreateRegistration(Phieudangkyhoc p)
        {
            p.Maphieu = taoMaphieu();
            p.Ngaydk = DateTime.Now; // Lấy ngày hiện tại

            // Lưu danh sách lớp tuyển sinh đã chọn vào bảng 'LopDangkyhoc' với mã phiếu đăng ký tương ứng
            List<string> sessionSelectedClasses = MySessions.GetList<string>(HttpContext.Session, "selectedClasses");
            if (sessionSelectedClasses != null && sessionSelectedClasses.Count > 0)
            {
                decimal totalCourseFee = 0;
                foreach (var malop in sessionSelectedClasses)
                {
                    // Kiểm tra xem học viên đã đăng ký lớp tuyển sinh này trước đó hay chưa
                    if (db.LopDangkyhocs.Any(ldk => ldk.Maloptuyensinh == malop && ldk.MaphieuNavigation.Mahv == p.Mahv))
                    {
                        //ModelState.AddModelError("Mahv", "Học viên đã đăng ký lớp tuyển sinh này trước đó.");
                        return View("loi");
                    }

                    var lopDangKyHoc = new LopDangkyhoc
                    {
                        Maphieu = p.Maphieu,
                        Maloptuyensinh = malop
                    };

                    db.LopDangkyhocs.Add(lopDangKyHoc);

                    // Lấy thông tin về môn học và tính tổng tiền dựa trên giá học phí của mỗi môn học
                    var TongTien = db.Loptuyensinhs
                        .Where(ldk => ldk.Maloptuyensinh == malop)
                        .Join(
                            db.Monhocs,
                            ldk => ldk.Mamh,
                            mh => mh.Mamh,
                            (ldk, mh) => mh.Hocphi
                        )
                        .FirstOrDefault();

                    if (TongTien != null)
                    {
                        totalCourseFee += TongTien;
                    }
                }

                // Cập nhật thông tin tổng tiền, số tiền đã trả và số tiền còn lại trong phiếu đăng ký
                p.tongtien = totalCourseFee;
                p.Sotiendatra = 0; // Ban đầu số tiền đã trả là 0
                p.Sotienconlai = totalCourseFee;
            }

            // Lưu phiếu đăng ký vào cơ sở dữ liệu
            db.Phieudangkyhocs.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        private string taoMaphieu()
        {
            // Lấy mã học viên cuối cùng từ CSDL
            var lastphieu = db.Phieudangkyhocs.OrderByDescending(x => x.Maphieu).FirstOrDefault();
            int lastId = lastphieu != null ? int.Parse(lastphieu.Maphieu.Substring(2)) : 0;
           // Lấy phần số của mã phiếu cuối cùng(trừ đi 2 ký tự đầu tiên) và gán vào biến lastId.
   // Nếu không có phiếu nào trong CSDL, lastId sẽ được gán giá trị 0.

            // Tạo mã học viên mới
            string newId = (lastId + 1).ToString("D3");
            string maPhieu = "PH" + newId;

            return maPhieu;
        }
        [HttpGet]
        public IActionResult timHocvien(string id)
        {

            List<Hocvien> ds = db.Hocviens.Where(x => x.Hoten.Contains(id) || x.Sdt == (id)).ToList()
;
            // List<Hocvien> ds = db.Hocviens.Where(x => x.Hoten.Contains(id)).ToList();
            if (ds.Count == 0)
            {
                ViewBag.Message = "Chưa có học viên này";
            }

            return PartialView(ds);


        }

        public IActionResult timMotHocvien(string id)
        {
            Hocvien x = db.Hocviens.Find(id);
            return PartialView(x);
        }
        public IActionResult timLop(string id)
        {
            //List<Monhoc> dsMH = xulyhv.getDSMonhoc();
            List<Loptuyensinh> ds = db.Loptuyensinhs.Where(p => p.Makh == id).ToList();
            //Loptuyensinh x = db.Loptuyensinhs.Find(id);
            if (ds.Count == 0)
            {
                ViewBag.Message = "Chưa có lớp tuyển sinh này";
            }
            return PartialView(ds);
        }
        public IActionResult formXoaphieudangky(string id)
        {
            Model.Phieudangkyhoc x = db.Phieudangkyhocs.Find(id);
            int dem = db.LopDangkyhocs.Where(a => a.Maphieu == id).ToList().Count();
            ViewBag.flag = dem;
            return View(x);
        }
        [HttpPost]
        public IActionResult xoaPhieudangky(string id)
        {

            Model.Phieudangkyhoc x = db.Phieudangkyhocs.Find(id);
            if (x != null)
            {
                db.Phieudangkyhocs.Remove(x);
                db.SaveChanges();
            }


            db.SaveChanges();

            // Return a success response
            return RedirectToAction("Index");
        }
        public IActionResult formSuaphieudangky(string id)
        {
            ViewBag.ten = User.Identity.Name;
            Model.Phieudangkyhoc x = db.Phieudangkyhocs.Find(id);

            return View(x);
        }
        [HttpPost]
        public IActionResult suaPhieudangky(Model.Phieudangkyhoc x)
        {

            if (ModelState.IsValid)
            {
                Model.Phieudangkyhoc p = db.Phieudangkyhocs.Find(x.Maphieu);
                if (p != null)
                {
                    p.Ngaydk = x.Ngaydk;
                    p.Ghichu = x.Ghichu;
                   
                }
                TempData["SuaSuccessMessage"] = "Sửa thành công";
                return RedirectToAction("Index");
            }

            return View("formSuaphieudangky");
        }

    }
}
