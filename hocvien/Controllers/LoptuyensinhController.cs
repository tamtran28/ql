using hocvien.Models;
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
        private trungtamContext db = new trungtamContext();
        public IActionResult Index()
        {
            return View(db.Loptuyensinhs.ToList());
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


        //[HttpPost]
        //public IActionResult CreateClass(DanhsachMH model)
        //{
        //    // Lưu danh sách mã môn học đã chọn vào session
        //    // HttpContext.Session.Set<List<string>>("Mamh", model.SelectedSubjects);
        //    byte[] selectedSubjectsBytes = HttpContext.Session.Get("SelectedSubjects");
        //    List<string> selectedSubjects = JsonConvert.DeserializeObject<List<string>>(Encoding.UTF8.GetString(selectedSubjectsBytes));



        //    // Chuyển hướng đến trang nhập ngày và giờ học
        //    //return RedirectToAction("EnterSchedule");
        //    //return Content(selectedSubjects.ToList());
        //}


    }
}
