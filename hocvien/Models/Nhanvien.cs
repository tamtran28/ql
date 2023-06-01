using System;
using System.Collections.Generic;

#nullable disable

namespace hocvien.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public string Manv { get; set; }
        public string Hoten { get; set; }
        public DateTime Ngaysinh { get; set; }
        public string Diachi { get; set; }
        public byte Gioitinh { get; set; }
        public string Email { get; set; }
        public int Sdt { get; set; }
        public string Trangthai { get; set; }
        public string Matkhau { get; set; }
        public int nhom { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
