using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hocvien.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hocvien.Controllers
{
    public class NhanvienController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {
            return View(db.Nhanviens.ToList());
        }

        public IActionResult formThemnhanvien()
        {
            ViewBag.ten = User.Identity.Name;
            return View();
        }

        [HttpPost]
        public IActionResult themNhanvien(Nhanvien kh)
        {
            if (ModelState.IsValid)
            {
                //kh.Makh = taoMaHocVien();
                //ma kh se la IEMMYYYY IE052023
                db.Nhanviens.Add(kh);
                db.SaveChanges();
                TempData["them"] = "Thêm khóa học thành công";
                return RedirectToAction("Index");
            }

            return View("formThemnhanvien");


        }
        public IActionResult formDoimatkhau(string id)
        {
            //ViewBag.manv = 

            return View();
        }
        [HttpPost]
        public IActionResult doiMatkhau( string oldPassword, string newPassword)
        {
            string username = HttpContext.Session.GetString("Manv");
           // ViewBag.ten = manv;
           // string username = User.Identity.Name; // Retrieve the username from the logged-in user's identity

            // Example logic to retrieve the employee from the database using the username
            var employee = db.Nhanviens.FirstOrDefault(nv => nv.Manv == username);
            if (employee == null)
            {
                // Handle case when the employee is not found
                return NotFound();
            }

            string manv = employee.Manv; // Retrieve the Manv value from the employee object

            // TODO: Implement logic to change the password for the employee with the given manv (employee ID).

            // Example logic to update the password in the database:
            var employee1 = db.Nhanviens.FirstOrDefault(nv => nv.Manv == manv);
            if (employee1 == null)
            {
                // Handle case when the employee is not found
                return NotFound();
            }

            // Check if the old password matches the stored password
            if (employee.Matkhau != oldPassword)
            {
                // Handle case when the old password is incorrect
                return BadRequest("password cũ khong dung");
            }

            // Update the password with the new value
            employee.Matkhau = newPassword;

            // Save the changes to the database
            db.SaveChanges();

            // Return e success response
            return RedirectToAction("Index");
        }

    }
}