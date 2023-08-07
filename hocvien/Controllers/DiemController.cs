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
             return View(db.Lophocs.ToList());
        }
        public IActionResult xemDiem(string maLopHoc)
        {
            if (TempData.ContainsKey("Diem"))
            {
                ViewBag.Diem = TempData["Diem"];
            }
            // Lấy danh sách phiếu điểm của lớp
            var phieuDiemList = db.Phieudiems
                .Where(p => p.Malophoc == maLopHoc)
                .Include(p => p.MahvNavigation)
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

                  
                    db.SaveChanges();
                    TempData["Diem"] = "Nhập điểm thành công";
                    return RedirectToAction("xemDiem", new { malophoc = maLopHoc });
                }
                catch (Exception ex)
                {
                    TempData["loiDiem"] = "Đã xảy ra lỗi trong quá trình lưu dữ liệu";
                    
                }
            }

            
            return View(model);
        }

    }

}

