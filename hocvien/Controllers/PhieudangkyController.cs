
using hocvien.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hocvien.Controllers
{
    public class PhieudangkyController : Controller
    {
        private trungtamContext db = new trungtamContext();
       
        //[HttpPost]
        //[Route("addToCart")]
        //public async Task<IActionResult> AddToCart([FromBody] AddCartItemViewModel model)
        //{
        //    var product = await db.Loptuyensinhs.Where(x => x.Maloptuyensinh == model.Id).FirstOrDefaultAsync();

        //    var session = HttpContext.Session.GetString(SystemConstants.CartSession);
        //    List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
        //    if (session != null)
        //        currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
        //    int quantity = 1;
        //    var cartItem = new CartItemViewModel();
        //    //if (currentCart.Any(x => x.Maloptuyensinh == model.Id))
        //    //{
        //    //    var currentCartItem = currentCart.FirstOrDefault(x => x.Maloptuyensinh == model.Id);
        //    //    currentCartItem.Quantity += 1;
        //    //}
        //    else
        //    {
        //        cartItem = new CartItemViewModel
        //        {
        //            Maloptuyensinh = model.Id,
        //            Tenloptuyensinh = product.Tenloptuyensinh,
        //            //Description = product.Description,
        //            //Image = product.Image,
        //            //Price = product.Price,
        //            //Quantity = quantity
        //        };
        //        currentCart.Add(cartItem);
        //    }

        //    HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
        //    return Ok(currentCart);
        //}

        public IActionResult Index()
        {
            //var danhSachPhieuDangKy = (from p in db.Phieudangkyhocs
            //                           join hv in db.Hocviens on p.Mahv equals hv.Mahv
            //                           select new
            //                           {
            //                               p.Maphieu,
            //                               hv.Hoten,
            //                               p.Ngaydk
            //                           }).ToList();
            //    var danhSachPhieuDangKy=db.Phieudangkyhocs
            //.Join(db.Hocviens,
            //    r => r.Mahv,
            //    s => s.Mahv,
            //    (r, s) => new CPhieuDangKy
            //    {
            //        Maphieu = r.Maphieu,
            //        Mahv = s.Mahv,
            //        Hoten = s.Hoten,
            //        Ngaydk = r.Ngaydk,
            //        Maloptuyensinh = r.Maloptuyensinh,
            //        //Tenloptuyensinh =r.LopDangkyhocs. 
            //        // Map các thuộc tính khác của phiếu đăng ký tại đây
            //    })
            //.ToList();
            var danhSachPhieuDangKy = db.Hocviens
            .Join(db.Phieudangkyhocs,
                r => r.Mahv,
                s => s.Mahv,
                (r, s) => new { Hocvien = r, Phieudangkyhoc = s })
            .Join(db.Loptuyensinhs,
            s => s.Phieudangkyhoc.Maloptuyensinh,
            j => j.Maloptuyensinh,
            (s, j) => new CPhieuDangKy
            {
                Maphieu = s.Phieudangkyhoc.Maphieu,
                Mahv = s.Hocvien.Mahv,
                Hoten = s.Hocvien.Hoten,
                Ngaydk = s.Phieudangkyhoc.Ngaydk,
                Maloptuyensinh = s.Phieudangkyhoc.Maloptuyensinh,
                Tenloptuyensinh = j.Tenloptuyensinh,
            });
            return View(danhSachPhieuDangKy);
        }
        //public IActionResult SelectClass(string selectedClassId)
        //{
        //    Lấy thông tin lớp học từ CSDL dựa trên selectedClassId

        //     Kiểm tra lớp học có tồn tại không
        //    if (selectedClassId == null)
        //    {
        //        Lớp học không tồn tại, xử lý tương ứng(ví dụ: thông báo lỗi)
        //        return View("Error");
        //    }

        //    Lớp học tồn tại, tiếp tục xử lý

        //    Tạo mới đối tượng lớp học
        //   LopHoc lopHoc = new LopHoc();
        //    lopHoc.MaLop = selectedClassId;

        //    Lưu thông tin lớp học vào session
        //    MySessions.Set<LopHoc>(HttpContext.Session, "selectedClass", lopHoc);

        //    Tiếp tục xử lý khác(ví dụ: chuyển hướng đến trang hiển thị danh sách sinh viên của lớp)
        //    return RedirectToAction("StudentsList");
        //}

        //public IActionResult StudentsList()
        //{
        //    Lấy thông tin lớp học từ session
        //   LopHoc selectedClass = MySessions.Get<LopHoc>(HttpContext.Session, "selectedClass");

        //    Kiểm tra lớp học có tồn tại không
        //    if (selectedClass == null)
        //    {
        //        Lớp học không tồn tại, xử lý tương ứng(ví dụ: thông báo lỗi)
        //        return View("Error");
        //    }

        //    Lớp học tồn tại, tiếp tục xử lý

        //    Lấy danh sách sinh viên dựa trên thông tin lớp học
        //    List<SinhVien> students = GetStudentsByClass(selectedClass.MaLop);

        //    Truyền danh sách sinh viên vào view để hiển thị
        //    return View(students);
        //}

        public IActionResult formThemphieudangky(string id)
        {
            ViewBag.DSLop = new SelectList(db.Monhocs.ToList(), "Mamh", "Tenmh");
            //MySessions.Get<Phieudangkyhoc>(HttpContext.Session, "malop");
            //Models.Loptuyensinh hd = MySessions.Get<Loptuyensinh>(HttpContext.Session, "malop");
            //MySessions.Set<Loptuyensinh>(HttpContext.Session, "malop",hd );
            Lophoc l = new Lophoc();
            l.Maloptuyensinh = id;
            MySessions.Set<Lophoc>(HttpContext.Session, "selectedClass", l);
             return View();
           // return Content(id);
        }
        public IActionResult SearchCourse(string maLopHoc)
        {
            ViewBag.DSLop = new SelectList(db.Monhocs.ToList(), "Mamh", "Tenmh");
           // HttpContext.Session.SetString("Maloptuyensinh", maLopHoc);

            return View();
           //return RedirectToAction("formThemphieudangky", "Phieudangky");
        }
        [HttpPost]
        public IActionResult SelectCourse(String kh)
        {
            // Lưu mã khóa học vào session
            HttpContext.Session.SetString("Maloptuyensinh", kh);
           // ViewBag.Kh = kh;
            //return Content(kh);
            return RedirectToAction("formThemphieudangky","Phieudangky");
        }
        public IActionResult SearchStudent(String kh)
        {
           // ViewBag.Kh = kh;
            return View();
        }
        //[HttpPost]
        //public IActionResult SelectStudent(String id)
        //{
        //    // Lưu mã học viên vào session
        //    //TempData.Set("SelectedStudentId", student.Id);

        //    HttpContext.Session.SetString("SelectedStudentId", id);
        //    // return RedirectToAction("CreateRegistration");
        //    return RedirectToAction("registration");
        //}
        //public IActionResult r()
        //{
        //    String e = HttpContext.Session.GetString("maLopHoc");
        //    return Content(e);
        //}
        public IActionResult registration(string kh, string id)
        {
            //kh = HttpContext.Session.GetString("Maloptuyensinh");
           
          //  ViewBag.kh = HttpContext.Session.GetString("maLopHoc");
            Lophoc selectedClass = MySessions.Get<Lophoc>(HttpContext.Session, "selectedClass");
            kh = selectedClass.Maloptuyensinh.ToString();
            ViewBag.kh = kh;
            // selectedId = HttpContext.Session.GetString("SelectedStudentId");
            ViewBag.s = id;
            return View();
        }
        //public IActionResult SelectStudent(String studentId)
        //{
        //    string? selectedCourseId = HttpContext.Session.GetString("SelectedCourseId");
        //    if (selectedCourseId == null)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    Phieudangkyhoc registration = new Phieudangkyhoc
        //    {
        //        Maloptuyensinh = selectedCourseId,
        //        Mahv = studentId,
        //    };

        //    db.Phieudangkyhocs.Add(registration);
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult CreateRegistration(Phieudangkyhoc p)
        {
            // Lấy mã khóa học và mã học viên từ session
           // string? selectedCourseId = HttpContext.Session.GetString("SelectedCourseId");
           // String? selectedStudentId = HttpContext.Session.GetString("SelectedStudentId");

            // Kiểm tra xem mã khóa học và mã học viên đã được chọn hay chưa
            //if (selectedCourseId == null || studentId == null)
            //{
            //    return RedirectToAction("CourseList");
            //}

            // Tạo phiếu đăng ký mới với mã khóa học và mã học viên đã chọn
            //Phieudangkyhoc registration = new Phieudangkyhoc
            //{
                //Maloptuyensinh = selectedCourseId,
                //Mahv = studentId

            //};

            // Thêm phiếu đăng ký vào CSDL
            p.Maphieu = taoMaphieu();
            db.Phieudangkyhocs .Add(p);
            db.SaveChanges();

            // Xóa mã khóa học và mã học viên khỏi session
           // HttpContext.Session.Remove("SelectedCourseId");
            //HttpContext.Session.Remove("SelectedStudentId");

            // Truyền thông tin phiếu đăng ký vào view để hiển thị
            // return View(registration);
           return RedirectToAction("Index");
        }
     
        public IActionResult test(string studentId)
        {

            return Content(studentId);
        }

        [HttpPost]
        public IActionResult themPhieudangky(Phieudangkyhoc p)
        {
            p.Maphieu = taoMaphieu();
            db.Phieudangkyhocs.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private string taoMaphieu()
        {
            // Lấy mã học viên cuối cùng từ CSDL
            var lastphieu = db.Phieudangkyhocs.OrderByDescending(x => x.Maphieu).FirstOrDefault();
            int lastId = lastphieu != null ? int.Parse(lastphieu.Maphieu.Substring(2)) : 0;
           // Lấy phần số của mã phiếu cuối cùng(trừ đi 2 ký tự đầu tiên) và gán vào biến lastId.
   // Nếu không có phiếu nào trong CSDL, lastId sẽ được gán giá trị 0.

            // Tạo mã học viên mới
            string newId = (lastId + 1).ToString("D3");
            string maPhieu = "PH" + newId;

            return maPhieu;
        }
        [HttpGet]
        public IActionResult timHocvien(string id)
        {

            List<Hocvien> ds = db.Hocviens.Where(x => x.Hoten.Contains(id) || x.Sdt == (id)).ToList()
;
            // List<Hocvien> ds = db.Hocviens.Where(x => x.Hoten.Contains(id)).ToList();
            return PartialView(ds);


        }

        public IActionResult timMotHocvien(string id)
        {
            Hocvien x = db.Hocviens.Find(id);
            return PartialView(x);
        }

        public IActionResult dangkyMonhoc(Phieudangkyhoc x)
        {
           
                x.Maphieu = taoMaphieu();
                x.Ngaydk = DateTime.Now;
                db.Phieudangkyhocs.Add(x);
                db.SaveChanges();
                 return RedirectToAction("Index");

            
        }

        public IActionResult timLop(string id)
        {
            //List<Monhoc> dsMH = xulyhv.getDSMonhoc();
            List<Loptuyensinh> ds = db.Loptuyensinhs.Where(p => p.Mamh == id).ToList();
            //Loptuyensinh x = db.Loptuyensinhs.Find(id);
            return PartialView(ds);
        }
        //public IActionResult chonLop(string id)
        //{
        //    Models.Phieudangkyhoc hd = MySessions.Get<Models.Phieudangkyhoc>(HttpContext.Session, "Phieudangky");
        //    if (hd == null)
        //    {
        //        hd = new Phieudangkyhoc();
        //    }
        //    Models.Loptuyensinh a = db.Loptuyensinhs.Find(id);
        //    LopDangkyhoc b = null;
        //    // foreach (Phieudangkyhoc ct in hd.P.Where(x => x.Mahang == id))
        //    //{
        //    //    b = ct;
        //    //    break;
        //    //}
        //    if (b == null)
        //    {
        //        b = new LopDangkyhoc();
        //        b.Maloptuyensinh = a.Maloptuyensinh;
        //        //b.Dongia = a.Dongia;
        //        //b.Soluong = 1;
        //        //b.MahangNavigation = a;
        //        hd.LopDangkyhocs.Add(b);
        //    }
        //    //else
        //    //{
        //    //    b.Soluong++;
        //    //}
        //    MySessions.Set<Phieudangkyhoc>(HttpContext.Session, "Phieudangky", hd);
        //    return View(CChitietphieudangkyViewcs.getDSChitietHoadon(hd));
        //}
        //public IActionResult giohang()
        //{
        //    Phieudangkyhoc hd = MySessions.Get<Phieudangkyhoc>(HttpContext.Session, "Phieudangky");
        //    if (hd == null)
        //    {
        //        hd = new Phieudangkyhoc();
        //    }
        //    return View("chonMua", CChitietphieudangkyViewcs.getDSChitietHoadon(hd));
        //}
    }
}
