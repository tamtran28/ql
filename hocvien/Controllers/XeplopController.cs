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
    [Authorize(Roles = "hocvu,giaovien")]
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
            if (TempData.ContainsKey("SuccessMessagePhanCong"))
            {
                ViewBag.SuccessMessagePhanCong = TempData["SuccessMessagePhanCong"];
            }
            if (TempData.ContainsKey("xoaLH"))
            {
                ViewBag.SuccessMessageXoaLH = TempData["xoaLH"];
            }
            var lophocs = db.Lophocs
                .Include(l => l.LophocGiaoviens)
                .ThenInclude(lg => lg.MagvNavigation)
                .ToList();

            return View(lophocs);
        }
        [Authorize(Roles = "hocvu")]
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


        [Authorize(Roles = "hocvu")]
        public IActionResult formThemLop()
        {
            var khoaHocDangMo = db.Khoahocs.Where(kh => kh.Trangthai == "Đang mở").ToList();
            ViewBag.DSlop = new SelectList(khoaHocDangMo, "Makh", "Tenkh");
          
            return View();
        }
        [Authorize(Roles = "hocvu")]
        public IActionResult danhSach(string malophoc, string maloptuyensinh)
        {
            ViewBag.Maloptuyensinh = maloptuyensinh;
            ViewBag.Malophoc = malophoc;

           //lấy danh sách đăng ký
            var danhSachHocVien = db.Phieudangkyhocs
                .Where(p => p.LopDangkyhocs.Any(ldh => ldh.Maloptuyensinh == maloptuyensinh))
                .Select(p => p.MahvNavigation)
                .ToList();

            var hocvienChuaXepLop = new List<Hocvien>();
            foreach (var hocvien in danhSachHocVien)
            {
                var phieuDiemKhac = db.Phieudiems.FirstOrDefault(p => p.Mahv == hocvien.Mahv && p.Malophoc != malophoc && p.MalophocNavigation.Maloptuyensinh == maloptuyensinh);
                if (phieuDiemKhac == null)
                {
                   
                    var PhieuDiem = db.Phieudiems.FirstOrDefault(p => p.Malophoc == malophoc && p.Mahv == hocvien.Mahv);
                    if (PhieuDiem == null)
                    {
                        hocvienChuaXepLop.Add(hocvien);
                    }
                }
            }

            return View(hocvienChuaXepLop);
        }

        [Authorize(Roles = "hocvu")]
        [HttpPost]
        public IActionResult XepLop(string malophoc, List<string> hocvienIds)
        {
            try
            {
                foreach (var hocvienId in hocvienIds)
                {
                    // Kiểm tra trùng lặp trước khi thêm
                    var PhieuDiem = db.Phieudiems.FirstOrDefault(p => p.Malophoc == malophoc && p.Mahv == hocvienId);
                    if (PhieuDiem == null)
                    {
                        var phieuDiem = new Phieudiem
                        {
                            Malophoc = malophoc,
                            Mahv = hocvienId,
                            Trangthai = 1,
                           
                        };

                        db.Phieudiems.Add(phieuDiem);
                    }
                }

                db.SaveChanges();
                TempData["SuccessMessageXepLop"] = "Xếp lớp thành công";
                return RedirectToAction("DanhSachHocVien", new { malophoc = malophoc });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Đã xảy ra lỗi khi xếp lớp";
                return RedirectToAction("ErrorAction");
            }
        }


        public IActionResult DanhSachHocVien(string malophoc)
{
            if (TempData.ContainsKey("SuccessMessageXepLop"))
            {
                ViewBag.MessageXepLop = TempData["SuccessMessageXepLop"];
            }
            if (TempData.ContainsKey("ErrorMessageChuyenLop"))
            {
                ViewBag.ErrorMessageChuyenLop = TempData["ErrorMessageChuyenLop"];
            }
            if (TempData.ContainsKey("MessageChuyenLop"))
            {
                ViewBag.MessageChuyenLop = TempData["MessageChuyenLop"];
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
        [Authorize(Roles = "hocvu")]
        [HttpPost]
        public IActionResult ChuyenLop(string maHocVien, string maLopHoc)
        {
           
            Phieudiem phieuDiemHienTai = db.Phieudiems.FirstOrDefault(pd => pd.Mahv == maHocVien && pd.Malophoc == maLopHoc);

            if (phieuDiemHienTai != null)
            {
               
                if (HasScore(phieuDiemHienTai))
                {
                   
                    TempData["ErrorMessageChuyenLop"] = "Không thể chuyển lớp vì học viên đã có điểm trong lớp này.";
                    return RedirectToAction("DanhSachHocVien", new { malophoc = maLopHoc });
                }

               
                db.Phieudiems.Remove(phieuDiemHienTai);
                db.SaveChanges();
            }

          
            TempData["MessageChuyenLop"] = "Chuyển lớp thành công";
            return RedirectToAction("DanhSachHocVien", new { malophoc = maLopHoc });
        }

        private bool HasScore(Phieudiem phieuDiem)
        {
            
            return phieuDiem.Diemdoc.HasValue || phieuDiem.Diemviet.HasValue || phieuDiem.Diemnoi.HasValue || phieuDiem.Diemnghe.HasValue;
        }

        [Authorize(Roles = "hocvu")]
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
                    return View("formSuaLopHoc",x);
                }
            }

            return View("formSuaLopHoc");
        }
        [Authorize(Roles = "hocvu")]
        public IActionResult formXoaLopHoc(String id)
        {
            int dem = db.Phieudiems.Where(a => a.Malophoc == id).ToList().Count();
            Model.Lophoc x = db.Lophocs.Find(id);
            ViewBag.flag = dem;

            return View(x);
        }
        //public IActionResult xoaLopHoc(String id)
        //{
        //    Model.Lophoc x = db.Lophocs.Find(id);
        //    if (x != null)
        //    {
        //        db.Lophocs.Remove(x);
        //        db.SaveChanges();
        //    }
        //    TempData["xoaLH"] = "Xóa lớp học thành công";
        //    return RedirectToAction("Index");
        //}
        public IActionResult xoaLopHoc(string id)
        {
            try
            {
                // Find the Lophoc record to delete
                Model.Lophoc lophoc = db.Lophocs.Find(id);
                if (lophoc == null)
                {
                    TempData["xoaLH"] = "Không tìm thấy lớp học để xóa.";
                    return RedirectToAction("Index");
                }

              
                List<Model.LophocGiaovien> lophocGiaovienList = db.LophocGiaoviens.Where(x => x.Malophoc == id).ToList();
                db.LophocGiaoviens.RemoveRange(lophocGiaovienList);

           
                db.Lophocs.Remove(lophoc);
                db.SaveChanges();

                TempData["xoaLH"] = "Xóa lớp học thành công";
            }
            catch (Exception ex)
            {
                TempData["xoaLH"] = "Đã xảy ra lỗi trong quá trình xóa lớp học";
            }

            return RedirectToAction("Index");
        }


    }
}
        
       