using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace hocvien.Model
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Hoadons = new HashSet<Hoadon>();
            Phieudangkyhocs = new HashSet<Phieudangkyhoc>();
        }

        public string Manv { get; set; }
        public string Hoten { get; set; }
        public DateTime Ngaysinh { get; set; }
        public string Diachi { get; set; }
        public byte Gioitinh { get; set; }
        public string Email { get; set; }
        [MaxLength(10, ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string Sdt { get; set; }
        public string Trangthai { get; set; }
        public string Matkhau { get; set; }
        public int Nhom { get; set; }

        public virtual ICollection<Hoadon> Hoadons { get; set; }
        public virtual ICollection<Phieudangkyhoc> Phieudangkyhocs { get; set; }
    }
}
