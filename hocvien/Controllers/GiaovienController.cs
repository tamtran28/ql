﻿using hocvien.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlTypes;
using System.Linq;

namespace hocvien.Controllers
{
    [Authorize(Roles = "hocvu")]
    public class GiaovienController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {
            if (TempData.ContainsKey("SuccessMessageGV"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessageGV"];
            }
            if (TempData.ContainsKey("SuaSuccessMessageGV"))
            {
                ViewBag.SuaSuccessMessage = TempData["SuaSuccessMessageGV"];
            }
            var danhSachgiaovien = db.Giaoviens.Where(nv => nv.Trangthai == "Đang làm").ToList();
            return View(danhSachgiaovien);
            //return View(db.Giaoviens.ToList());
        }

        public IActionResult formthemGiaovien()
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;
            return View();
        }



        //}
        [HttpPost]
        public IActionResult themGiaovien(Giaovien gv)
        {
            try
            {
                if (gv.Ngaysinh.Year >= DateTime.Now.Year || (DateTime.Now.Year - gv.Ngaysinh.Year) < 18)
                {
                    ModelState.AddModelError("Ngaysinh", "Ngày sinh không hợp lệ.");
                    return RedirectToAction("formthemGiaovien");
                }

                gv.Magv = taoMagiaovien();
                db.Giaoviens.Add(gv);
                db.SaveChanges();

                TempData["SuccessMessageGV"] = "Thêm giáo viên thành công";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessageGV"] = "Đã xảy ra lỗi khi thêm giáo viên";
                // Log the exception if needed
                // logger.LogError(ex, "Error while adding teacher");

                return RedirectToAction("formthemGiaovien");
            }
        }

        private string taoMagiaovien()
        {
            // Lấy mã học viên cuối cùng từ CSDL
            var lastgv = db.Giaoviens.OrderByDescending(gv => gv.Magv).FirstOrDefault();
            int lastId = lastgv != null ? int.Parse(lastgv.Magv.Substring(2)) : 0;

            // Tạo mã học viên mới
            string newId = (lastId + 1).ToString("D3");
            string maHocVien = "GV" + newId;

            return maHocVien;
        }
        public IActionResult formXoaGiaoVien(String id)
        {
            int dem = db.LophocGiaoviens.Where(a => a.Magv == id).ToList().Count();
            Model.Giaovien x = db.Giaoviens.Find(id);
            ViewBag.flag = dem;

            return View(x);
        }
        public IActionResult xoaGiaoVien(String id)
        {
            var giaovien = db.Giaoviens.Find(id);

            if (giaovien != null)
            {
                // Thay đổi trạng thái của nhân viên thành "nghỉ"
                giaovien.Trangthai = "Nghỉ";

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        public IActionResult formSuaGiaovien(string id)
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;
            Model.Giaovien x = db.Giaoviens.Find(id);

            return View(x);
        }
        //lỗi
        [HttpPost]
        public IActionResult suaGiaovien(Model.Giaovien x)
        {
            string manv = HttpContext.Session.GetString("Manv");
            if (ModelState.IsValid)
            {
                Model.Giaovien hv = db.Giaoviens.Find(x.Magv);
                if (hv != null)
                {
                    hv.Hoten = x.Hoten;
                    hv.Ngaysinh = x.Ngaysinh;

                    hv.Gioitinh = x.Gioitinh;
                    hv.Sdt = x.Sdt;
                    hv.Diachi = x.Diachi;
                    hv.Capdoday = x.Capdoday;
                    hv.Trinhdo = x.Trinhdo;
                    hv.Ngaytao = DateTime.Now;
                    //hv.Nguoitao = x.Nguoitao;
                    hv.Trangthai = x.Trangthai;
                   // db.SaveChanges();
                    db.SaveChanges();
                }
                TempData["SuaSuccessMessageGV"] = "Sửa thành công";


                //else if (User.IsInRole("giaovien"))
                //{
                return RedirectToAction("Index");
              
            }

            return View("formSuathongtinnhanvien", x);
        }
        //[HttpPost]
        //public IActionResult suaGiaovien(Model.Giaovien x)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Model.Giaovien hv = db.Giaoviens.Find(x.Magv);
        //        if (hv != null)
        //        {
        //            // Cập nhật thông tin giáo viên
        //            hv.Hoten = x.Hoten;
        //            hv.Ngaysinh = x.Ngaysinh;
        //            //if (x.Ngaysinh < SqlDateTime.MinValue.Value || x.Ngaysinh > SqlDateTime.MaxValue.Value)
        //            //{
        //            //    ModelState.AddModelError("Ngaysinh", "Ngày sinh không hợp lệ.");
        //            //    return View("formSuaGiaovien", x);
        //            //}
        //            hv.Gioitinh = x.Gioitinh;
        //            hv.Sdt = x.Sdt;
        //            hv.Diachi = x.Diachi;
        //            hv.Capdoday = x.Capdoday;
        //            hv.Trinhdo = x.Trinhdo;
        //            hv.Ngaytao = x.Ngaytao;
        //            hv.Nguoitao = x.Nguoitao;
        //            hv.Trangthai = x.Trangthai;
        //            db.SaveChanges();

        //            TempData["SuaSuccessMessageGV"] = "Sửa giáo viên thành công";
        //            return RedirectToAction("Index");
        //        }
               
        //    }

        //    return View("formSuaGiaovien");
        //}

    }
}
