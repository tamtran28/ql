using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using hocvien.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hocvien.Controllers
{
    [Authorize(Roles = "tuyển sinh,quản lý")]
    public class LopTSController : Controller
    {
        private centerContext db = new centerContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }
            return View();
        }
       

        //[HttpPost]
        //public IActionResult Create(List<CreateClassViewModel> model)
        //{
        //    string thangNamHienTai = DateTime.Now.ToString("MMyyyy");
        //    if (ModelState.IsValid)
        //    {
        //        // Save the data to the database
        //        foreach (var monhoc in model)
        //        {
        //            var macahoc = Request.Form[$"Macahoc_{monhoc.Mamh}"];

        //            var loptuyensinh = new Loptuyensinh
        //            {
        //                Maloptuyensinh = String.Concat(monhoc.Makh, "-", monhoc.Mamh, thangNamHienTai).Replace(" ", ""),
        //                Tenloptuyensinh = String.Concat(monhoc.Makh, "-", monhoc.Mamh, thangNamHienTai).Replace(" ", ""),
        //                Trangthai = "Trạng thái",
        //                Nguoitao = "Người tạo",
        //                Ngaytao = DateTime.Now,
        //                Ngaybatdau = monhoc.Ngaybatdau,
        //                Ngayketthuc = monhoc.Ngayketthuc,
        //                Macahoc = macahoc,
        //                Makh = monhoc.Makh,
        //                Mamh = monhoc.Mamh
        //            };

        //            db.Loptuyensinhs.Add(loptuyensinh);
        //        }

        //        db.SaveChanges();

        //        // Redirect to a success page or display a success message
        //        return RedirectToAction("Index", "Loptuyensinh");
        //    }

        //    // If the model is invalid, reload the view with the model to display validation errors
        //    var khoahocs = db.Khoahocs.ToList();
        //    var monhocs = db.Monhocs.ToList();
        //    var cahoc = db.Cahocs.ToList();
        //    var khoahocSelectList = new SelectList(khoahocs, "Makh", "Tenkh");

        //    ViewBag.DSKhoahoc = khoahocSelectList;
        //    ViewBag.DSMonhoc = monhocs;
        //    ViewBag.Cahocs = cahoc;
        //    return View(model);
        //}


    }
}


