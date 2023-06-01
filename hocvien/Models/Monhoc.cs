using System;
using System.Collections.Generic;

#nullable disable

namespace hocvien.Models
{
    public partial class Monhoc
    {
        public Monhoc()
        {
            Loptuyensinhs = new HashSet<Loptuyensinh>();
        }

        public string Mamh { get; set; }
        public string Tenmh { get; set; }
        public string Mota { get; set; } 
        public decimal Hocphi { get; set; }
        public string Nguoitao { get; set; }
        public DateTime Ngaytao { get; set; }

        public virtual ICollection<Loptuyensinh> Loptuyensinhs { get; set; }
    }
}
