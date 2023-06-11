using hocvien.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hocvien.Controllers
{
    public class LoptuyensinhController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {

            var ds = db.Loptuyensinhs
            .Join(db.Cahocs,
                r => r.Macahoc,
                s => s.Macahoc,
                (r, s) =>
            //    new { Loptuyensinh = r, Cahoc = s })
            //.Join(db.LopDangkyhocs, s => s.Phieudangkyhoc.Maphieu, n => n.Maphieu, (s, n) => new { Phieudangkyhoc = s, LopDangkyhoc = n })
            //.Join(db.Loptuyensinhs,
            //s => s.LopDangkyhoc.Maloptuyensinh,
            //j => j.Maloptuyensinh,
            new CLopTS
            {
               // Maphieu = s.Phieudangkyhoc.Phieudangkyhoc.Maphieu,
                //Mahv = s.Phieudangkyhoc.Hocvien.Mahv,
                //Hoten = s.Phieudangkyhoc.Hocvien.Hoten,
                Ngaybatdau = r.Ngaybatdau,
                Ngayketthuc = r.Ngayketthuc,
                Maloptuyensinh = r.Maloptuyensinh,
                Tenloptuyensinh = r.Tenloptuyensinh,
                Thuhoc = s.Thuhoc,
                Giohoc = s.Giohoc,
            });
            return View(ds);
        }
       
        public IActionResult formthemLoptuyensinh()

        {
            ViewBag.DSKhoahoc = new SelectList(db.Khoahocs.ToList(), "Makh", "Tenkh");
            ViewBag.DSMonhoc = new SelectList(db.Monhocs.ToList(), "Mamh", "Tenmh");
            return View();
        }

        [HttpPost]
        public IActionResult themLoptuyensinh(Loptuyensinh ts)
        {
            if (ModelState.IsValid)
            {
                // Lấy mã khóa học và mã môn học từ form
                string courseId = ts.Makh;
                string subjectId = ts.Mamh;

                // Lấy thông tin khóa học và môn học từ database
                var course = db.Khoahocs.Find(courseId);
                var subject = db.Monhocs.Find(subjectId);

                // Tạo mã lớp tuyển sinh tự động
              
         
                string thangNamHienTai = DateTime.Now.ToString("MMyyyy");

                string maLopTuyenSinh = String.Concat(course.Makh,"-",subject.Mamh,"-",thangNamHienTai).Replace(" ", "");
         
               ts.Maloptuyensinh = maLopTuyenSinh;
                db.Loptuyensinhs.Add(ts);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

           
            ViewBag.Courses = db.Khoahocs.ToList();
            ViewBag.Subjects = db.Monhocs.ToList();
            return View(ts);
        }

        public IActionResult xemKhoahoc(string id)
        {
            Khoahoc x = db.Khoahocs.Find(id);
            return PartialView(x);
        }
        public IActionResult xemMonhoc(string id)
        {
            Monhoc x = db.Monhocs.Find(id);
            return PartialView(x);
        }

        

    }
}
