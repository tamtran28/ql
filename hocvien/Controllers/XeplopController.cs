using hocvien.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;


namespace hocvien.Controllers
{
    public class XeplopController : Controller
    {
        private centerContext db = new centerContext();

        //public ActionResult CreateClass(string id)
        //{
        //    // Lấy mã lớp tuyển sinh từ bảng lớp học
        //    // var lastAdmissionCode = db.Lophocs.OrderByDescending(c => c.Maloptuyensinh).Select(c => c.Maloptuyensinh).FirstOrDefault();
        //    var lastAdmissionCode = db.Lophocs.Find(id);
        //    string newAdmissionCode;
        //    if (lastAdmissionCode == null)
        //    {
        //        // Nếu chưa tồn tại mã tuyển sinh, sử dụng mã tuyển sinh làm mã lớp học
        //        newAdmissionCode = GetNextAdmissionCode();
        //       // newAdmissionCode = lastAdmissionCode;
        //    }
        //    else
        //    {
        //        // Nếu đã tồn tại mã tuyển sinh, tăng mã lớp tuyển sinh lên 1
        //        newAdmissionCode = lastAdmissionCode + 1;
        //    }/

        //    // Tạo lớp học mới với mã lớp tuyển sinh
        //    var newClass = new Class
        //    {
        //        AdmissionCode = newAdmissionCode,
        //        // Các thông tin khác về lớp học
        //    };

        //    // Lưu lớp học vào CSDL
        //    db.Classes.Add(newClass);
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //private int GetNextAdmissionCode()
        //{
        //    // Logic để lấy mã tuyển sinh mới
        //    // Có thể truy vấn CSDL hoặc tính toán dựa trên yêu cầu cụ thể của bạn
        //    // Ví dụ:
        //    var lastAdmissionCode = db.AdmissionCodes.OrderByDescending(ac => ac.Id).Select(ac => ac.Code).FirstOrDefault();
        //    return lastAdmissionCode + 1;
        //}


        //public ActionResult taoLop(string id)
        //{
        //    Loptuyensinh l = new Loptuyensinh();
        //    l.Maloptuyensinh = id;
        //    MySessions.Set<Loptuyensinh>(HttpContext.Session, "selectedClass", l);
        //    // using (var context = new YourDbContext())

        //    return View();
        //   // return RedirectToAction("Index", "YourControllerName");
        //}
        //[HttpPost]
        //public ActionResult them(Lophoc lh)
        //{
        //    Loptuyensinh selectedClass = MySessions.Get<Loptuyensinh>(HttpContext.Session, "selectedClass");

        //   // var classCode = string.Empty;

        //        // Kiểm tra xem mã lớp tuyển sinh đã tồn tại trong bảng lớp học chưa
        //    var existingClass = db.Lophocs.FirstOrDefault(c => c.Maloptuyensinh == selectedClass.Maloptuyensinh);
        //    if (existingClass == null)
        //    {
        //            // Nếu mã lớp tuyển sinh chưa tồn tại trong bảng lớp học, sử dụng mã đó
        //           lh.Malophoc = selectedClass.Maloptuyensinh;
        //    }
        //    else
        //    {
        //            // Nếu mã lớp tuyển sinh đã tồn tại trong bảng lớp học, tăng lên 1 và sử dụng mã mới
        //            var ma = int.Parse(existingClass.Malophoc.Substring(2));
        //            var maMoi = ma + 1;
        //        lh.Malophoc = $"LH{maMoi.ToString("D3")}";
        //    }

        //    // Tiếp tục tạo mới bản ghi lớp học với mã lớp học là `classCode` và lưu vào CSDL
        //    // ...

        //    //lh.Malophoc = classCode;
        //    db.Lophocs.Add(lh);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");

        //}
        //public ActionResult themLop()
        //{
        //    {
        //        var classCode = string.Empty;

        //        Kiểm tra xem mã lớp tuyển sinh đã tồn tại trong bảng lớp học chưa
        //       var existingClass = db.Lophocs.FirstOrDefault(c => c.Maloptuyensinh == admissionClassCode);
        //        if (existingClass == null)
        //        {
        //            Nếu mã lớp tuyển sinh chưa tồn tại trong bảng lớp học, sử dụng mã đó
        //           classCode = admissionClassCode;
        //        }
        //        else
        //        {
        //            Nếu mã lớp tuyển sinh đã tồn tại trong bảng lớp học, tăng lên 1 và sử dụng mã mới
        //           var lastCodeNumber = int.Parse(existingClass.Malophoc.Substring(2));
        //            var newCodeNumber = lastCodeNumber + 1;
        //            classCode = $"LH{newCodeNumber.ToString("D3")}";
        //        }

        //        Tiếp tục tạo mới bản ghi lớp học với mã lớp học là `classCode` và lưu vào CSDL
        //         ...
        //    }
        //}
        public IActionResult formTaolophoc(string id)
        {
            ViewBag.s = id;
            return View();
        }
        [HttpPost]
        public IActionResult themLophoc(Lophoc h)
        {
           
            db.Lophocs.Add(h);
            db.SaveChanges();
            ViewBag.SuccessMessage = "Thêm học viên thành công!";
            return RedirectToAction("Index");

        }

        public ActionResult AddStudentToClass(string classId, string studentId)
        {
            // Thêm sinh viên vào lớp học
            var student = db.Hocviens.SingleOrDefault(s => s.Mahv == studentId);
           // student. = classId;
            db.SaveChanges();
            return RedirectToAction("GetStudentsByClass", new { classId = classId });
        }
       
        public IActionResult formThemLop()
        {
            ViewBag.DSlop = new SelectList(db.Khoahocs.ToList(), "Makh", "Tenkh");
            return View();
        }

        public IActionResult danhSach(string malophoc,string maloptuyensinh)
        {
            ViewBag.Maloptuyensinh = maloptuyensinh;
            // Lấy danh sách học viên dựa trên mã tuyển sinh
            var danhSachHocVien = db.Phieudangkyhocs
                .Where(p => p.LopDangkyhocs.Any(ldh => ldh.Maloptuyensinh == maloptuyensinh))
                .Select(p => p.MahvNavigation)
                .ToList();


            ViewBag.Malophoc = malophoc;
            return View(danhSachHocVien);
        }
        [HttpPost]
        public IActionResult XepLop( string malophoc, List<string> hocvienIds)
        {
            foreach (var hocvienId in hocvienIds)
            {
                // Kiểm tra trùng lặp trước khi thêm
                var existingPhieuDiem = db.Phieudiems.FirstOrDefault(p => p.Malophoc == malophoc && p.Mahv == hocvienId);
                if (existingPhieuDiem == null)
                {
                    var phieuDiem = new Phieudiem
                    {
                        Malophoc = malophoc,
                        Mahv = hocvienId,
                        // Các thông tin khác về điểm
                    };

                    db.Phieudiems.Add(phieuDiem);
                }
            }

            db.SaveChanges();
            //
           // var hocvienDaXepLop = db.Hocviens.Where(h => hocvienIds.Contains(h.Mahv)).ToList();
            var hocvienChuaXepLop = db.Phieudiems.Where(h => !hocvienIds.Contains(h.Mahv)).ToList();

            return View(hocvienChuaXepLop);
            //return RedirectToAction("Index");
        }
        public IActionResult DanhSachHocVien(string malophoc)
        {
            var hocvien = db.Phieudiems
                .Where(p => p.Malophoc == malophoc)
                .Select(p => p.MahvNavigation)
                .ToList();

            return View(hocvien);
        }

        //[HttpPost]
        //public IActionResult XepLop(string malophoc, List<string> hocvienIds)
        //{

        //     foreach (var hocvienId in hocvienIds)
        //    {
        //        var phieuDiem = new Phieudiem
        //        {
        //            Malophoc = malophoc,
        //            Mahv = hocvienId,
        //            // Các thông tin khác về điểm
        //        };

        //        db.Phieudiems.Add(phieuDiem);
        //    }

        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        public IActionResult Index()
        {

            //ViewBag.DSlop = new SelectList(db.Khoahocs.ToList(), "Makh", "Tenkh");
            return View(db.Lophocs.ToList());

        }
        public IActionResult xemDSLop(string id)
        {
            List<Loptuyensinh> ds = db.Loptuyensinhs.Where(p => p.Maloptuyensinh == id).ToList();
            return PartialView(ds);
        }

        //public IActionResult xemDSLop(string id)
        //{
        //   // List<Phieudangkyhoc> ds = db.Phieudangkyhocs.Join(db.Hocviens, x => x.Mahv, y => y.Mahv, (x, y) => new { Phieudangkyhoc = x, Hocvien = y }).Where(x => x.Phieudangkyhoc.Maloptuyensinh == id).ToList();
        //   // db.Hocviens.Join(db.Phieudiems, x => x.Mahv, y => y.Mahv,
        //    //(x, y) => new { HocVien = x, PhieuDiem = y }
        //    //     ).Where(x => x.HocVien.Mahv == id)

        //   // return PartialView(ds);
        //}
        public ActionResult ChonLop()
        {
            // Lấy danh sách các lớp từ cơ sở dữ liệu
            var classes = db.Lophocs.ToList();

            // Truyền danh sách lớp vào view
            return View(classes);
        }
        public ActionResult ChonHocVien(int lopId)
        {
            // Lấy lớp từ cơ sở dữ liệu dựa trên lopId
            var selectedClass = db.Lophocs.Find(lopId);

            if (selectedClass == null)
            {
                // Xử lý khi không tìm thấy lớp
                return RedirectToAction("ChonLop");
            }

            // Lấy danh sách học viên chưa có lớp trong khóa đó
            var unassignedStudents = db.Hocviens.Join(db.Phieudiems,x =>x.Mahv , y =>y.Mahv,(x,y) =>new { HocVien = x, PhieuDiem = y }). 
                Where(x => x.HocVien.Mahv == null && x.PhieuDiem.Malophoc == selectedClass.Malophoc).ToList();

            // Truyền danh sách học viên và lớp đã chọn vào view
            ViewBag.SelectedClass = selectedClass;
            return View(unassignedStudents);
        }
        //[HttpPost]
        //public ActionResult ThemHocVien(List<int> selectedStudents, int classId)
        //{
        //    // Lấy lớp từ cơ sở dữ liệu dựa trên classId
        //    var selectedClass = db.Lophocs.Find(classId);

        //    if (selectedClass == null)
        //    {
        //        // Xử lý khi không tìm thấy lớp
        //        return RedirectToAction("ChonLop");
        //    }

        //    // Lấy danh sách học viên từ cơ sở dữ liệu dựa trên selectedStudents
        //    var studentsToAdd = db.Hocviens.Where(hv => selectedStudents.Contains(hv.Mahv)).ToList();

        //    foreach (var hocvien in studentsToAdd)
        //    {
        //        hocvien.LopId = selectedClass.Malophoc;
        //    }

        //    // Lưu thay đổi vào cơ sở dữ liệu
        //    db.SaveChanges();

        //    // Chuyển hướng đến trang thông báo hoặc trang khác
        //    return RedirectToAction("Index", "Home");
        //}

    }
}
        
       