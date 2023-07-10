using System;
using System.Collections.Generic;

#nullable disable

namespace hocvien.Model
{
    public partial class Khoahoc
    {
        public Khoahoc()
        {
            Loptuyensinhs = new HashSet<Loptuyensinh>();
        }

        public string Makh { get; set; }
        public string Tenkh { get; set; }
       // public string Thoiluong { get; set; }
        public string Motakh { get; set; }
        public string Nguoitao { get; set; }
        public DateTime Ngaytao { get; set; }
        public string Trangthai { get; set; }

        public virtual ICollection<Loptuyensinh> Loptuyensinhs { get; set; }
    }
}
