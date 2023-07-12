using hocvien.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hocvien.Controllers
{
    public class DiemController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {
            return View(db.Phieudiems.ToList());
        }
        public IActionResult xemDiem(string maLopHoc)
        {
            // Lấy danh sách phiếu điểm của lớp
            var phieuDiemList = db.Phieudiems
                .Where(p => p.Malophoc == maLopHoc)
                .Include(p => p.MahvNavigation) // Nạp dữ liệu học viên liên quan
                .ToList();
            return View(phieuDiemList);
        }

            public IActionResult NhapDiem(string maLopHoc)
        {
            // Truy vấn danh sách học viên trong lớp học từ cơ sở dữ liệu
            var hocVienList = db.Phieudiems
                          .Include(p => p.MahvNavigation)
                          .Where(p => p.Malophoc == maLopHoc)
                          .ToList();


            // Gửi danh sách học viên và mã lớp học vào view
            ViewBag.MaLopHoc = maLopHoc;
            return View(hocVienList);
        }

        [HttpPost]
        public IActionResult LuuDiem(List<Phieudiem> model, string maLopHoc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var phieudiem in model)
                    {
                        string mahv = phieudiem.Mahv;
                        // Lấy đối tượng Phieudiem từ cơ sở dữ liệu dựa trên mã học viên và mã lớp học
                        var existingPhieudiem = db.Phieudiems
                      .FirstOrDefault(p => p.Mahv == phieudiem.Mahv && p.Malophoc == maLopHoc);
                        if (existingPhieudiem != null)
                        {
                            // Cập nhật điểm
                            existingPhieudiem.Diemdoc = phieudiem.Diemdoc;
                            existingPhieudiem.Diemviet = phieudiem.Diemviet;
                            existingPhieudiem.Diemnoi = phieudiem.Diemnoi;
                            existingPhieudiem.Diemnghe = phieudiem.Diemnghe;
                        }
                    }

                    // Lưu các đối tượng Phieudiem vào cơ sở dữ liệu
                    db.SaveChanges();

                    return RedirectToAction("Index","Xeplop");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Đã xảy ra lỗi trong quá trình lưu dữ liệu: " + ex.Message);
                }
            }

            // Nếu có lỗi, trả về View với model để người dùng có thể sửa lỗi và gửi lại form
            return View(model);
        }

        //        [HttpPost]
        //public IActionResult NhapDiem(List<Phieudiem> phieuDiemList)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        foreach (var phieuDiem in phieuDiemList)
        //        {
        //            // Lấy phiếu điểm trong cơ sở dữ liệu
        //            var phieuDiemDb = db.Phieudiems.FirstOrDefault(pd => pd.Malophoc == phieuDiem.Malophoc && pd.Mahv == phieuDiem.Mahv);

        //            if (phieuDiemDb != null)
        //            {
        //                // Cập nhật điểm
        //                phieuDiemDb.Diemdoc = phieuDiem.Diemdoc;
        //                phieuDiemDb.Diemviet = phieuDiem.Diemviet;
        //                phieuDiemDb.Diemnoi = phieuDiem.Diemnoi;
        //                phieuDiemDb.Diemnghe = phieuDiem.Diemnghe;
        //                phieuDiemDb.Trangthai = phieuDiem.Trangthai;
        //            }
        //            else
        //            {
        //                // Thêm phiếu điểm mới
        //                db.Phieudiems.Add(phieuDiem);
        //            }
        //        }

        //        db.SaveChanges();

        //        return RedirectToAction("Index");
        //    }

        //    return View("NhapDiem", phieuDiemList);
        //}

        //[HttpPost]
        //public IActionResult NhapDiem(List<CDiemView> model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            foreach (var ds in model)
        //            {
        //                Model.Phieudiem hv = db.Phieudiems.Find(ds.Mahv);
        //                if (hv != null)
        //                {
        //                    // Học viên đã có phiếu điểm, cập nhật điểm
        //                    hv.Diemdoc = ds.Diemdoc;
        //                    hv.Diemviet = ds.Diemviet;
        //                    hv.Diemnoi = ds.Diemnoi;
        //                    hv.Diemnghe = ds.Diemnghe;
        //                    db.SaveChanges();
        //                }

        //            }
        //            //db.Phieudiems.Add();


        //            return RedirectToAction("Index");
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("", "Đã xảy ra lỗi trong quá trình lưu dữ liệu: " + ex.Message);
        //        }
        //    }

        //    return View(model);
        //}



    }

}

