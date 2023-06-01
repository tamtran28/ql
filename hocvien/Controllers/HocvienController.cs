using hocvien.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hocvien.Controllers
{
    public class HocvienController : Controller
    {
        private trungtamContext db = new trungtamContext();
        //public IActionResult Index()

        //{
        //    if (TempData.ContainsKey("SuccessMessage"))
        //    {
        //        ViewBag.SuccessMessage = TempData["SuccessMessage"];
        //    }
        //    List<Models.CHocvienview> ds = db.Hocviens.Select(a => new Models.CHocvienview
        //    {
        //       Mahv = a.Mahv,
        //        Hoten = a.Hoten,
        //        Ngaysinh = a.Ngaysinh.Value.ToShortDateString(),
        //        Gioitinh = (a.Gioitinh == 1 ? "Nam" : "Nữ"),
        //        Sdt = a.Sdt,
        //        Diachi = a.Diachi,
        //        Trangthai = a.Trangthai,


        //    }).ToList();
        //    return View(ds);

        //}
        public IActionResult Index(int currentPage = 1)
        {
            int pageSize = 5; // Số lượng học viên hiển thị trên mỗi trang

            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }

            List<Models.CHocvienview> ds = db.Hocviens.Select(a => new Models.CHocvienview
            {
                Mahv = a.Mahv,
                Hoten = a.Hoten,
                Ngaysinh = a.Ngaysinh.Value.ToShortDateString(),
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

        public IActionResult themHocVien()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThemHocVien(Hocvien hocVien)
        {
            if (hocVien.Ngaysinh.Value.Year >= DateTime.Now.Year || (DateTime.Now.Year - hocVien.Ngaysinh.Value.Year) < 4)
            {
                ModelState.AddModelError("Ngaysinh", "Ngày sinh không hợp lệ.");
                return View(hocVien);
            }

            hocVien.Mahv = taoMaHocVien();
           db.Hocviens.Add(hocVien);
            db.SaveChanges();
            ViewBag.SuccessMessage = "Thêm học viên thành công!";
            return RedirectToAction("Index");
           

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
            return PartialView(ds);

            
        }

        public IActionResult formSuaHocvien(string id)
        {
            
            Models.Hocvien x = db.Hocviens.Find(id);
            return View(x);
        }
        [HttpPost]
        public IActionResult suaHocvien(Models.Hocvien x)
        {

            if (ModelState.IsValid)
            {
                Models.Hocvien hv = db.Hocviens.Find(x.Mahv);
                if (hv != null)
                {
                    hv.Hoten = x.Hoten;
                    hv.Ngaysinh = x.Ngaysinh;
                    //if (x.Ngaysinh.Value.Year >= DateTime.Now.Year || (DateTime.Now.Year - x.Ngaysinh.Value.Year) < 4)
                    //{
                    //    ModelState.AddModelError("Ngaysinh", "Ngày sinh không hợp lệ.");
                    //    return -1;
                    //}
                    hv.Gioitinh = x.Gioitinh;
                    hv.Nguoitao = x.Nguoitao;
                    hv.Diachi = x.Diachi;
                    hv.Ngaytao = x.Ngaytao;
                    hv.Sdt = x.Sdt;
                  
                   

                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
           
            return View("formSuaHocvien");
        }

        public IActionResult formXoaHocVien(String id)
        {
            int dem = db.Phieudangkyhocs.Where(a => a.Mahv == id).ToList().Count();
            Models.Hocvien x = db.Hocviens.Find(id);
            ViewBag.flag = dem;

            return View(x);
        }
        public IActionResult xoaHocVien(String id)
        {
            Models.Hocvien x = db.Hocviens.Find(id);
            if (x != null)
            {
                db.Hocviens.Remove(x);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        public IActionResult chiTiet(string id)
        {

            //     Models.Hocvien a = db.Hocviens.Find(id);
            //     if (a != null)
            //     {
            //         var studentDetails = db.Hocviens.Join(db.Phieudiems, x => x.Mahv, y => y.Mahv,
            //(x, y) => new { HocVien = x, PhieuDiem = y }
            //     ).Where(x => x.HocVien.Mahv == id).Select(x => new
            //     {
            //         x.HocVien.Mahv,
            //         x.HocVien.Hoten,
            //         x.HocVien.Ngaysinh,
            //         x.HocVien.Diachi,
            //         x.PhieuDiem.MalophocNavigation.Tenlop,
            //     }).FirstOrDefault();

            //         return View(studentDetails);

            //     }
            //     return View("Index");


            var hocVien = db.Hocviens.FirstOrDefault(hv => hv.Mahv == id);

            if (hocVien == null)
            {
                return NotFound();
            }

            var phieuDiem = db.Phieudiems.FirstOrDefault(pd => pd.Mahv == id);
            var lopHoc = db.Lophocs.Where(lh => lh.Malophoc == phieuDiem.Malophoc);

           //var lopHoc = db.Lophocs.Join(db.Phieudiems, x => x.Malophoc, y => y.MalophocNavigation, (x, y) => new { Phieudiem = x, Lophoc = y }

            var model = new CHocvienview
            {
                Mahv = hocVien.Mahv,
                Hoten = hocVien.Hoten,
                Diachi = hocVien.Diachi,
                Sdt = hocVien.Sdt,
                

               // Gioitinh = hocVien.Gioitinh,

                //Malophoc = 
                //Tenlop = lopHoc.Tenlop,
                // Phieudie = lopHoc?.Id,
                // TenLop = lopHoc?.TenLop
            };
            return View(model);
        }
    }
}
