using hocvien.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
            if (TempData.ContainsKey("MessageXoaGV"))
            {
                ViewBag.XoaSuccessMessageGV = TempData["MessageXoaGV"];
            }
            var danhSachgiaovien = db.Giaoviens.Where(nv => nv.Trangthai == "Đang làm").ToList();
            return View(danhSachgiaovien);
           
        }

        public IActionResult formthemGiaovien()
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;
            return View();
        }

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
                gv.Trangthai = "Đang làm";
                gv.Ngaytao = DateTime.Now;
                gv.Matkhau = GetMd5Hash(gv.Matkhau);
                gv.Nhom = 4;
                db.Giaoviens.Add(gv);
                db.SaveChanges();

                TempData["SuccessMessageGV"] = "Thêm giáo viên thành công";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessageGV"] = "Đã xảy ra lỗi khi thêm giáo viên";
               
            }
            return RedirectToAction("formthemGiaovien", gv);
        }
        public string GetMd5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
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
            TempData["MessageXoaGV"] = "Xóa giáo viên thành công";
            return RedirectToAction("Index");
        }

        public IActionResult formSuaGiaovien(string id)
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;
            Model.Giaovien x = db.Giaoviens.Find(id);

            return View(x);
        }
       
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
                    hv.Trangthai = "đang làm";
                    db.SaveChanges();
                }
                TempData["SuaSuccessMessageGV"] = "Sửa thành công";


               
                return RedirectToAction("Index");
              
            }

            return View("formSuathongtinnhanvien",x);
        }
        [HttpGet]
        public IActionResult timGiaoVien(string id)
        {

            List<Giaovien> ds = db.Giaoviens.Where(x => x.Hoten.Contains(id)).ToList();
            
            if (ds.Count == 0)
            {
                ViewBag.Message = "Không tìm thấy giáo viên";
            }

            return PartialView(ds);


        }
    }
}
