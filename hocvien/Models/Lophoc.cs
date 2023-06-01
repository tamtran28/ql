using System;
using System.Collections.Generic;

#nullable disable

namespace hocvien.Models
{
    public partial class Lophoc
    {
        public Lophoc()
        {
            LophocGiaoviens = new HashSet<LophocGiaovien>();
            Phieudiems = new HashSet<Phieudiem>();
        }

        public string Malophoc { get; set; }
        public string Mahv { get; set; }
        //public DateTime Ngaybatday { get; set; }
        //public DateTime Ngayketthuc { get; set; }
        public string Phonghoc { get; set; }
        public string Maloptuyensinh { get; set; }
       //public string Tenlophoc { get; set; }
        public string Magv { get; set; }
        public virtual Loptuyensinh MalopNavigation { get; set; }
        public virtual ICollection<LophocGiaovien> LophocGiaoviens { get; set; }
        public virtual ICollection<Phieudiem> Phieudiems { get; set; }
    }
}
