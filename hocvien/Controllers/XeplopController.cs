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
using Microsoft.AspNetCore.Http;

namespace hocvien.Controllers
{
    [Authorize(Roles = "hocvu")]
    public class XeplopController : Controller
    {
        private centerContext db = new centerContext();

        public IActionResult Index()
        {
            if (TempData.ContainsKey("SuccessMessageThemLopHoc"))
            {
                ViewBag.SuccessMessageThemLopHoc = TempData["SuccessMessageThemLopHoc"];
            }
            if (TempData.ContainsKey("SuccessMessageSuaLopHoc"))
            {
                ViewBag.SuccessMessageSuaLopHoc = TempData["SuccessMessageSuaLopHoc"];
            }
            if (TempData.ContainsKey("ErrorMessageSua"))
            {
                ViewBag.ErrorMessageSua = TempData["ErrorMessageSua"];
            }
            var lophocs = db.Lophocs
                .Include(l => l.LophocGiaoviens)
                .ThenInclude(lg => lg.MagvNavigation)
                .ToList();

            return View(lophocs);
        }
        public IActionResult formTaolophoc(string id)
        {

            ViewBag.s = id;
            return View();
        }
        [HttpPost]
        public IActionResult themLophoc(Lophoc h)
        {
            try
            {
                string maloptuyensinh = h.Maloptuyensinh;
                string malop = Request.Form[$"malophoc"];
                //cap nhâp lại database
                string manv = HttpContext.Session.GetString("Manv");
                //ViewBag.ten = manv;
                h.Malophoc = maloptuyensinh + malop;
                h.Nguoitao = manv;
                h.Ngaytao = DateTime.Now;
                db.Lophocs.Add(h);
                db.SaveChanges();
                TempData["SuccessMessageThemLopHoc"] = "Thêm lớp học thành công!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessageThemLopHoc"] = "Đã xảy ra lỗi khi thêm lớp học";

            }
            return View("formTaolophoc");

        }
       

       
        public IActionResult formThemLop()
        {
            var khoaHocDangMo = db.Khoahocs.Where(kh => kh.Trangthai == "Đang mở").ToList();
            ViewBag.DSlop = new SelectList(khoaHocDangMo, "Makh", "Tenkh");
          
            return View();
        }

        public IActionResult danhSach(string malophoc, string maloptuyensinh)
        {
            ViewBag.Maloptuyensinh = maloptuyensinh;
            ViewBag.Malophoc = malophoc;

            // Get the list of students who have registered for the specified course (Loptuyensinh)
            var danhSachHocVien = db.Phieudangkyhocs
                .Where(p => p.LopDangkyhocs.Any(ldh => ldh.Maloptuyensinh == maloptuyensinh))
                .Select(p => p.MahvNavigation)
                .ToList();

            var hocvienChuaXepLop = new List<Hocvien>();

            // Check if any student is already assigned to another class with the same maloptuyensinh
            foreach (var hocvien in danhSachHocVien)
            {
                var existingPhieuDiemKhac = db.Phieudiems.FirstOrDefault(p => p.Mahv == hocvien.Mahv && p.Malophoc != malophoc && p.MalophocNavigation.Maloptuyensinh == maloptuyensinh);
                if (existingPhieuDiemKhac == null)
                {
                    // Check if the student is not already assigned to the current class (malophoc)
                    var existingPhieuDiem = db.Phieudiems.FirstOrDefault(p => p.Malophoc == malophoc && p.Mahv == hocvien.Mahv);
                    if (existingPhieuDiem == null)
                    {
                        hocvienChuaXepLop.Add(hocvien);
                    }
                }
            }

            return View(hocvienChuaXepLop);
        }

        [HttpPost]
public IActionResult XepLop(string malophoc, List<string> hocvienIds)
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
}

public IActionResult DanhSachHocVien(string malophoc)
{
            if (TempData.ContainsKey("ErrorMessageChuyenLop"))
            {
                ViewBag.ErrorMessageChuyenLop = TempData["ErrorMessageChuyenLop"];
            }
            ViewBag.malophoc = malophoc;

    var hocvien = db.Phieudiems
        .Where(p => p.Malophoc == malophoc)
        .Select(p => p.MahvNavigation)
        .ToList();

    return PartialView(hocvien);

}
        public IActionResult xemDSLop(string id)
        {
            List<Loptuyensinh> ds = db.Loptuyensinhs.Where(p => p.Maloptuyensinh == id).ToList();
            return PartialView(ds);
        }

        [HttpPost]
        public IActionResult ChuyenLop(string maHocVien, string maLopHoc)
        {
            // Tìm phiếu điểm hiện tại có Malophoc và Mahv tương ứng
            Phieudiem phieuDiemHienTai = db.Phieudiems.FirstOrDefault(pd => pd.Mahv == maHocVien && pd.Malophoc == maLopHoc);

            if (phieuDiemHienTai != null)
            {
                // Check if the student has a score in the current class
                if (HasScore(phieuDiemHienTai))
                {
                    // Handle the case when the student has a score
                    TempData["ErrorMessageChuyenLop"] = "Không thể chuyển lớp vì học viên đã có điểm trong lớp này.";
                    return RedirectToAction("DanhSachHocVien", new { malophoc = maLopHoc });
                }

                // If the student doesn't have a score, remove the Phieudiem record
                db.Phieudiems.Remove(phieuDiemHienTai);
                db.SaveChanges();
            }

            // Redirect về action "DanhSachHocVien" và truyền lại mã lớp học
            return RedirectToAction("DanhSachHocVien", new { malophoc = maLopHoc });
        }

        private bool HasScore(Phieudiem phieuDiem)
        {
            
            return phieuDiem.Diemdoc.HasValue || phieuDiem.Diemviet.HasValue || phieuDiem.Diemnoi.HasValue || phieuDiem.Diemnghe.HasValue;
        }


        public IActionResult formSuaLopHoc(string id)
        {
            ViewBag.ten = User.Identity.Name;
            Model.Lophoc x = db.Lophocs.Find(id);
            return View(x);
        }
        [HttpPost]
        public IActionResult suaLopHoc(Model.Lophoc x)
        {
            string manv = HttpContext.Session.GetString("Manv");
            if (ModelState.IsValid)
            {
                try
                {
                    Model.Lophoc kh = db.Lophocs.Find(x.Malophoc);
                    if (kh != null)
                    {
                        kh.Phonghoc = x.Phonghoc;
                        kh.Ngaytao = DateTime.Now;
                        kh.Nguoitao = manv;

                        db.SaveChanges();
                    }
                    TempData["SuccessMessageSuaLopHoc"] = "Thêm lớp học thành công";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    TempData["ErrorMessageSua"] = "Đã xảy ra lỗi khi sửa lớp học";
                    return View("formSuaLopHoc");
                }
            }

            return View("formSuaLopHoc");
        }

    }
}
        
       