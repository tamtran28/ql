using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace hocvien.Model
{
    public partial class Hocvien
    {
        public Hocvien()
        {
            Phieudangkyhocs = new HashSet<Phieudangkyhoc>();
            Phieudiems = new HashSet<Phieudiem>();
        }

        public string Mahv { get; set; }

        [Required(ErrorMessage = "Họ tên là trường bắt buộc.")]
        public string Hoten { get; set; }

        [Required(ErrorMessage = "Ngày sinh là trường bắt buộc.")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2019", ErrorMessage = "Ngày sinh không hợp lệ")]
        public DateTime Ngaysinh { get; set; }

       // public DateTime Ngaysinh { get; set; }

        [Required(ErrorMessage = "Số điện thoại là trường bắt buộc.")]
        [MaxLength(10, ErrorMessage = "Số điện thoại không hợp lệ.")]
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
