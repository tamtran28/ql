using hocvien.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace hocvien.Controllers
{
    [Authorize(Roles = "tuyensinh,hocvu,giaovien") ]
   // [Authorize(Roles = "học vụ") ]
    
    public class HocvienController : Controller
    {
        private centerContext db = new centerContext();
        [Authorize(Roles = "tuyensinh,hocvu,giaovien")]
        public IActionResult Index(int currentPage = 1)
        {
            int pageSize = 10; // Số lượng học viên hiển thị trên mỗi trang

            if (TempData.ContainsKey("SuccessMessageHV"))
            {
                ViewBag.SuccessMessageHV = TempData["SuccessMessageHV"];
            }
            if (TempData.ContainsKey("SuaSuccessMessage"))
            {
                ViewBag.SuaSuccessMessageHV = TempData["SuaSuccessMessage"];
            }
            if (TempData.ContainsKey("SuccessMessageXoaHV"))
            {
                ViewBag.SuccessMessageXoaHV = TempData["SuccessMessageXoaHV"];
            }
            if (TempData.ContainsKey("SuccessMatKhau"))
            {
                ViewBag.SuccessMatKhau = TempData["SuccessMatKhau"];
            }

            List<Model.CHocvienview> ds = db.Hocviens.Select(a => new Model.CHocvienview
            {
                Mahv = a.Mahv,
                Hoten = a.Hoten,
                Ngaysinh = a.Ngaysinh.ToString("dd/MM/yyyy"),
                Gioitinh = (a.Gioitinh == 1 ? "Nam" : "Nữ"),
                Sdt = a.Sdt,
                Diachi = a.Diachi,
                Trangthai = a.Trangthai,
            }).ToList();

            // Tính toán số trang dựa trên tổng số học viên và kích thước trang
            int totalItems = ds.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // Truyền thông tin số trang vào ViewBag
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = currentPage;

            // Lấy danh sách học viên cho trang hiện tại
            var pagedHocvienList = ds
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = currentPage;
            ViewBag.TotalItems = totalItems;
            return View(pagedHocvienList);
        }
        [Authorize(Roles = "tuyensinh,hocvu")]
        public IActionResult themHocVien()
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;
            return View();
        }

        [HttpPost]
        public IActionResult ThemHocVien(Hocvien hocVien)
        {
            try
            {
                if (hocVien.Ngaysinh.Year >= DateTime.Now.Year || (DateTime.Now.Year - hocVien.Ngaysinh.Year) < 4)
                {
                    ModelState.AddModelError("Ngaysinh", "Ngày sinh không hợp lệ.");
                    return View(hocVien);
                }

                hocVien.Mahv = taoMaHocVien();
                hocVien.Trangthai = "mới";
                hocVien.Ngaytao = DateTime.Now;
                db.Hocviens.Add(hocVien);
                db.SaveChanges();

                TempData["SuccessMessageHV"] = "Thêm học viên thành công";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorThem"]="Đã xảy ra lỗi khi thêm học viên";
            }

            return View(hocVien);
        }

        private string taoMaHocVien()
        {
            // Lấy mã học viên cuối cùng từ CSDL
            var lastHocVien = db.Hocviens.OrderByDescending(hv => hv.Mahv).FirstOrDefault();
            int lastId = lastHocVien != null ? int.Parse(lastHocVien.Mahv.Substring(2)) : 0;

            // Tạo mã học viên mới
            string newId = (lastId + 1).ToString("D4");
            string maHocVien = "HV" + newId;

            return maHocVien;
        }
        [HttpGet]
        public IActionResult timHocvien(string id)
        {
            
            List<Hocvien>ds = db.Hocviens.Where(x => x.Hoten.Contains(id) || x.Sdt == (id)).ToList()
                ;
            // List<Hocvien> ds = db.Hocviens.Where(x => x.Hoten.Contains(id)).ToList();
            if (ds.Count == 0)
            {
                ViewBag.Message = "Không tìm thấy học viên";
            }

            return PartialView(ds);

            
        }
        [Authorize(Roles = "tuyensinh,hocvu")]
        public IActionResult formSuaHocvien(string id)
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;
            Model.Hocvien x = db.Hocviens.Find(id);
            
            return View(x);
        }
        [HttpPost]
        public IActionResult suaHocvien( Model.Hocvien x)
        {
            string manv = HttpContext.Session.GetString("Manv");
            if (ModelState.IsValid)
            {
                Model.Hocvien hv = db.Hocviens.Find(x.Mahv);
                if (hv != null)
                {
                    hv.Hoten = x.Hoten;
                    hv.Ngaysinh = x.Ngaysinh;
                    if (x.Ngaysinh.Year >= DateTime.Now.Year || (DateTime.Now.Year - x.Ngaysinh.Year) < 4)
                    {
                        ModelState.AddModelError("Ngaysinh", "Ngày sinh không hợp lệ.");
                        return View("formSuaHocvien", x);
                    }
                    hv.Gioitinh = x.Gioitinh;
                    hv.Nguoitao = manv;
                    hv.Diachi = x.Diachi;
                    hv.Ngaytao = DateTime.Now;
                    hv.Sdt = x.Sdt;
                    db.SaveChanges();
                }
                TempData["SuaSuccessMessage"] = "Sửa học viên thành công";
                return RedirectToAction("Index");
            }
           
            return View("formSuaHocvien",x);
        }
        [Authorize(Roles = "tuyensinh,hocvu")]
        public IActionResult formXoaHocVien(String id)
        {
            int dem = db.Phieudangkyhocs.Where(a => a.Mahv == id).ToList().Count();
            Model.Hocvien x = db.Hocviens.Find(id);
            ViewBag.flag = dem;

            return View(x);
        }
        public IActionResult xoaHocVien(String id)
        {
            Model.Hocvien x = db.Hocviens.Find(id);
            if (x != null)
            {
                db.Hocviens.Remove(x);
                db.SaveChanges();
            }
            TempData["SuccessMessageXoaHV"] = "Xóa học viên thành công";
            return RedirectToAction("Index");

        }

        public IActionResult chiTiet(string id)
        {
            var hocVien = db.Hocviens.FirstOrDefault(hv => hv.Mahv == id);

            if (hocVien == null)
            {
                return NotFound();
            }

            var phieuDiems = db.Phieudiems.Where(pd => pd.Mahv == id).ToList();
            if (phieuDiems.Count == 0)
            {
                return View(new CHocvienview
                {
                    Mahv = hocVien.Mahv,
                    Hoten = hocVien.Hoten,
                    Ngaysinh = hocVien.Ngaysinh.ToShortDateString(),
                    Sdt = hocVien.Sdt,
                    Diachi = hocVien.Diachi,
                    Gioitinh = hocVien.Gioitinh == 1 ? "Nam" : "Nữ",
                    Trangthai = hocVien.Trangthai
                });
            }
            else
            {
                var malophoc = phieuDiems[0].Malophoc;
                var lopHoc = db.Lophocs.FirstOrDefault(lh => lh.Malophoc == malophoc);

                var model = new CHocvienview
                {
                    Mahv = hocVien.Mahv,
                    Hoten = hocVien.Hoten,
                    Ngaysinh = hocVien.Ngaysinh.ToShortDateString(),
                    Sdt = hocVien.Sdt,
                    Diachi = hocVien.Diachi,
                    Gioitinh = hocVien.Gioitinh == 1 ? "Nam" : "Nữ",
                    Trangthai = hocVien.Trangthai,
                    Malophoc = lopHoc?.Malophoc ?? "Chưa có",
                    //Tenlop = lopHoc?.Malophoc ?? "Chưa có",
                    Phieudiems = phieuDiems
                };

                return View(model);
            }
        }

    }
}
