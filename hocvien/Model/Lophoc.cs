using System;
using System.Collections.Generic;

#nullable disable

namespace hocvien.Model
{
    public partial class Lophoc
    {
        public Lophoc()
        {
            LophocGiaoviens = new HashSet<LophocGiaovien>();
            Phieudiems = new HashSet<Phieudiem>();
        }

        public string Malophoc { get; set; }
        public string Phonghoc { get; set; }
        public string Maloptuyensinh { get; set; }
        //public string Magv { get; set; }
        public string Nguoitao { get; set; }
        public DateTime Ngaytao { get; set; }
        public virtual Loptuyensinh MaloptuyensinhNavigation { get; set; }
        public virtual ICollection<LophocGiaovien> LophocGiaoviens { get; set; }
        public virtual ICollection<Phieudiem> Phieudiems { get; set; }
    }
}
