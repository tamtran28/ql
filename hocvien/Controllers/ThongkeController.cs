using hocvien.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace hocvien.Controllers
{
    public class ThongkeController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {
            ViewBag.SoLuongHocVien = soLuonghocvientrongthang();
            ViewBag.DoanhThu = TongTienThuTrongThang();
            return View();
        }
        //public IActionResult thongKepdk(int month)
        //{
        //    int numberOfStudents = db.Phieudangkyhocs
        //  .Where(p => p.Ngaydk.HasValue && p.Ngaydk.Value.Month == month)
        //  .Count();


        //    ViewBag.NumberOfStudents = numberOfStudents;

        //    return View();
        //}
        public int soLuonghocvientrongthang()
        {
            // Lấy ngày hiện tại
            DateTime currentDate = DateTime.Now;

            // Lấy danh sách các học viên đăng ký trong tháng hiện tại
            var hocVienTrongThang = db.Phieudangkyhocs
                .Where(p => p.Ngaydk != null && p.Ngaydk.Value.Month == currentDate.Month && p.Ngaydk.Value.Year == currentDate.Year)
                .ToList();

            // Đếm số lượng học viên trong danh sách
            int soLuongHocVienTrongThang = hocVienTrongThang.Count;

            return soLuongHocVienTrongThang;
        }
        public decimal TongTienThuTrongThang()
        {
            // Lấy ngày hiện tại
            DateTime currentDate = DateTime.Now;

            // Lấy danh sách các hóa đơn đã thanh toán trong tháng hiện tại
            var hoaDonTrongThang = db.Hoadons
                .Where(hd => hd.Ngaythu != null && hd.Ngaythu.Month == currentDate.Month && hd.Ngaythu.Year == currentDate.Year)
                .ToList();

            // Tính tổng số tiền thu từ các hóa đơn trong danh sách
            decimal tongTienThuTrongThang = hoaDonTrongThang.Sum(hd => hd.Tongtienthanhtoan);

            return tongTienThuTrongThang;
        }

    }
}
