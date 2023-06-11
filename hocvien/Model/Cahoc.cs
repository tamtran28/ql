using System;
using System.Collections.Generic;

#nullable disable

namespace hocvien.Model
{
    public partial class Cahoc
    {
        public Cahoc()
        {
            Loptuyensinhs = new HashSet<Loptuyensinh>();
        }

        public string Macahoc { get; set; }
        public string Thuhoc { get; set; }
        public string Giohoc { get; set; }

        public virtual ICollection<Loptuyensinh> Loptuyensinhs { get; set; }
    }
}
