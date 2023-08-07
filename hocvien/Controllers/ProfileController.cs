using hocvien.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hocvien.Controllers
{
    public class ProfileController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {

            return View();
        }
       
        public IActionResult formSuathongtinnhanvien()
        {
            return View();
        }
        public IActionResult formSuathongtingiaovien()
        {
            return View();
        }
        public IActionResult formSuathongtin()
        {
            string manv = HttpContext.Session.GetString("Manv");
            ViewBag.ten = manv;

            if (User.IsInRole("giaovien"))
            {
                Model.Giaovien giaovien = db.Giaoviens.Find(manv);
                if (giaovien != null)
                {
                    return View("formSuathongtingiaovien",giaovien);
                }
            }
            else
            {
                Model.Nhanvien nhanvien = db.Nhanviens.Find(manv);
                if (nhanvien != null)
                {
                    return View("formSuathongtinnhanvien",nhanvien);
                }
            }

           
            return RedirectToAction("Login", "Dangnhap");
        }

        [HttpPost]
        public IActionResult suaNhanvien(Model.Nhanvien x)
        {
            string manv = HttpContext.Session.GetString("Manv");
            if (ModelState.IsValid)
            {
                Model.Nhanvien hv = db.Nhanviens.Find(manv);
                if (hv != null)
                {
                    hv.Hoten = x.Hoten;
                    hv.Ngaysinh = x.Ngaysinh;
                   
                    hv.Gioitinh = x.Gioitinh;
                    //hv.Trangthai = x.Trangthai;
                    hv.Diachi = x.Diachi;
                   // hv.Email = x.Email;
                   // hv.Nhom = x.Nhom;
                    hv.Sdt = x.Sdt;
                    db.SaveChanges();
                }
                TempData["SuaSuccessMessage"] = "Sửa nhân viên thành công";
                if (User.IsInRole("quanly"))
                {
                    return RedirectToAction("Index", "Khoahoc");
                }
                else if (User.IsInRole("tuyensinh"))
                {
                    return RedirectToAction("Index", "Hocvien");
                }
                else if (User.IsInRole("hocvu"))
                {
                    return RedirectToAction("Index", "Giaovien");
                }
                
                else
                {
                    return RedirectToAction("Login", "Dangnhap");
                }
            }

            return View("formSuathongtinnhanvien");
        }
        [HttpPost]
        public IActionResult suaGiaovien(Model.Giaovien x)
        {
            string manv = HttpContext.Session.GetString("Manv");
            if (ModelState.IsValid)
            {
                Model.Giaovien hv = db.Giaoviens.Find(manv);
                if (hv != null)
                {
                    hv.Hoten = x.Hoten;
                    hv.Ngaysinh = x.Ngaysinh;

                    hv.Gioitinh = x.Gioitinh;
                  
                    hv.Diachi = x.Diachi;
                   
                    hv.Sdt = x.Sdt;
                    db.SaveChanges();
                }
                TempData["SuaSuccessMessage"] = "Sửa thành công thành công";


                
                return RedirectToAction("Index", "Hocvien");
              
            }

            return View("formSuathongtinnhanvien",x);
        }
    }
}
