using System;
using System.Collections.Generic;

#nullable disable

namespace hocvien.Models
{
    public partial class LopDangkyhoc
    {
        public string Maphieu { get; set; }
        public string Maloptuyensinh { get; set; }

        public virtual Loptuyensinh MalopNavigation { get; set; }
        public virtual Phieudangkyhoc MaphieuNavigation { get; set; }
    }
}
