using hocvien.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace hocvien.Controllers
{
  //  [Authorize(Roles = "học vụ")]
    public class XeplopController : Controller
    {
        private centerContext db = new centerContext();

       
        public IActionResult formTaolophoc(string id)
        {
            ViewBag.s = id;
            return View();
        }
        [HttpPost]
        public IActionResult themLophoc(Lophoc h)
        {
           
            db.Lophocs.Add(h);
            db.SaveChanges();
            ViewBag.SuccessMessage = "Thêm học viên thành công!";
            return RedirectToAction("Index");

        }
       

       
        public IActionResult formThemLop()
        {
            ViewBag.DSlop = new SelectList(db.Khoahocs.ToList(), "Makh", "Tenkh");
            return View();
        }

        public IActionResult danhSach(string malophoc, string maloptuyensinh)
        {
            //ViewBag.Maloptuyensinh = maloptuyensinh;
            //// Lấy danh sách học viên dựa trên mã tuyển sinh
            //var danhSachHocVien = db.Phieudangkyhocs
            //    .Where(p => p.LopDangkyhocs.Any(ldh => ldh.Maloptuyensinh == maloptuyensinh))
            //    .Select(p => p.MahvNavigation)
            //    .ToList();


            //ViewBag.Malophoc = malophoc;
            //return View(danhSachHocVien);
            ViewBag.Maloptuyensinh = maloptuyensinh;

            // Lấy danh sách học viên dựa trên mã tuyển sinh
            var danhSachHocVien = db.Phieudangkyhocs
                .Where(p => p.LopDangkyhocs.Any(ldh => ldh.Maloptuyensinh == maloptuyensinh))
                .Select(p => p.MahvNavigation)
                .ToList();

            // Lấy danh sách các học viên đã được xếp lớp
            var hocvienDaXepLop = db.Hocviens
                .Where(h => db.Phieudiems.Any(p => p.Mahv == h.Mahv && p.Malophoc == malophoc))
                .ToList();

            // Loại bỏ các học viên đã được xếp lớp khỏi danh sách chưa xếp lớp
            var hocvienChuaXepLop = danhSachHocVien.Except(hocvienDaXepLop).ToList();

            ViewBag.Malophoc = malophoc;
            return View(hocvienChuaXepLop);
        }
        [HttpPost]
        public IActionResult XepLop( string malophoc, List<string> hocvienIds)
        {
            foreach (var hocvienId in hocvienIds)
            {
                // Kiểm tra trùng lặp trước khi thêm
                var existingPhieuDiem = db.Phieudiems.FirstOrDefault(p => p.Malophoc == malophoc && p.Mahv == hocvienId);
                if (existingPhieuDiem == null)
                {
                    var phieuDiem = new Phieudiem
                    {
                        Malophoc = malophoc,
                        Mahv = hocvienId,
                        Trangthai = 1,
                        // Các thông tin khác về điểm
                    };

                    db.Phieudiems.Add(phieuDiem);
                }
            }

            db.SaveChanges();
         
            
            return RedirectToAction("DanhSachHocVien", new { malophoc = malophoc });
            // return RedirectToAction("Index");
        }
        public IActionResult DanhSachHocVien(string malophoc)
        {
            ViewBag.malophoc = malophoc;
            var hocvien = db.Phieudiems
                .Where(p => p.Malophoc == malophoc)
                .Select(p => p.MahvNavigation)
                .ToList();

            return PartialView(hocvien);
        }

        

        public IActionResult Index1()
        {

            //ViewBag.DSlop = new SelectList(db.Khoahocs.ToList(), "Makh", "Tenkh");
            return View(db.Lophocs.ToList());

        }
        public IActionResult Index()
        {

            var lophocs = db.Lophocs.Include(l => l.LophocGiaoviens).ToList();
            return View(lophocs);

        }
        public IActionResult xemDSLop(string id)
        {
            List<Loptuyensinh> ds = db.Loptuyensinhs.Where(p => p.Maloptuyensinh == id).ToList();
            return PartialView(ds);
        }

        //public IActionResult xemDSLop(string id)
        //{
        //   // List<Phieudangkyhoc> ds = db.Phieudangkyhocs.Join(db.Hocviens, x => x.Mahv, y => y.Mahv, (x, y) => new { Phieudangkyhoc = x, Hocvien = y }).Where(x => x.Phieudangkyhoc.Maloptuyensinh == id).ToList();
        //   // db.Hocviens.Join(db.Phieudiems, x => x.Mahv, y => y.Mahv,
        //    //(x, y) => new { HocVien = x, PhieuDiem = y }
        //    //     ).Where(x => x.HocVien.Mahv == id)

        //   // return PartialView(ds);
        //}
        

       


      
        [HttpPost]
        public IActionResult ChuyenLop(string maHocVien, string maLopHoc)
        {
            // Tìm phiếu điểm hiện tại có Malophoc và Mahv tương ứng
            Phieudiem phieuDiemHienTai = db.Phieudiems.FirstOrDefault(pd => pd.Mahv == maHocVien && pd.Malophoc == maLopHoc);

            if (phieuDiemHienTai != null)
            {
                // Xóa phiếu điểm hiện tại
                db.Phieudiems.Remove(phieuDiemHienTai);
                db.SaveChanges();


            }

            // Redirect về action "DanhSachHocVien" và truyền lại mã lớp học
            return RedirectToAction("DanhSachHocVien", new { malophoc = maLopHoc });
        }



    }
}
        
       