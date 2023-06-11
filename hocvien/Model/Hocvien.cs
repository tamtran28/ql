using System;
using System.Collections.Generic;

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
        public string Hoten { get; set; }
        public DateTime Ngaysinh { get; set; }
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
