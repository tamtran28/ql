using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace hocvien.Models
{
    public partial class Hocvien
    {
        public Hocvien()
        {
            Phieudangkyhocs = new HashSet<Phieudangkyhoc>();
            Phieudiems = new HashSet<Phieudiem>();
        }

        public string Mahv { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string Hoten { get; set; }

        //[Required(ErrorMessage = "Ngày sinh là trường bắt buộc.")]

        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        //[Range(typeof(DateTime), "dd/MM/1910", "dd/MM/2019", ErrorMessage = "Ngày sinh không hợp lệ")]
       
        public DateTime? Ngaysinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên số điện thoại")]
        [Range(100000000, 999999999, ErrorMessage = "Số điện thoại phải có 10 chữ số.")]
        public string Sdt { get; set; }
        public string Diachi { get; set; }
        public int Gioitinh { get; set; }
        public string Trangthai { get; set; }
        public string Nguoitao { get; set; }
        public DateTime? Ngaytao { get; set; }
       

        public virtual ICollection<Phieudangkyhoc> Phieudangkyhocs { get; set; }
        public virtual ICollection<Phieudiem> Phieudiems { get; set; }
    }
}
