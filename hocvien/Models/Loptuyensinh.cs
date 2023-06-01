using System;
using System.Collections.Generic;

#nullable disable

namespace hocvien.Models
{
    public partial class Loptuyensinh
    {
        public Loptuyensinh()
        {
            LopDangkyhocs = new HashSet<LopDangkyhoc>();
            Lophocs = new HashSet<Lophoc>();
        }

        public string Maloptuyensinh { get; set; }
        public string Tenloptuyensinh { get; set; }
        public string Trangthai { get; set; }
        public string Nguoitao { get; set; }
        public DateTime Ngaytao { get; set; }
        public DateTime Ngaybatdau { get; set; }
        public DateTime Ngayketthuc { get; set; }
        public string Thuhoc { get; set; }
        public string Giohoc { get; set; }
        public string Makh { get; set; }
        public string Mamh { get; set; }

        public virtual Khoahoc MakhNavigation { get; set; }
        public virtual Monhoc MamhNavigation { get; set; }
        public virtual ICollection<LopDangkyhoc> LopDangkyhocs { get; set; }
        public virtual ICollection<Lophoc> Lophocs { get; set; }

       
    }
}
