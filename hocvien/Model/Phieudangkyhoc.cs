using System;
using System.Collections.Generic;

#nullable disable

namespace hocvien.Model
{
    public partial class Phieudangkyhoc
    {
        public Phieudangkyhoc()
        {
            Hoadons = new HashSet<Hoadon>();
            LopDangkyhocs = new HashSet<LopDangkyhoc>();
        }

        public string Maphieu { get; set; }
        public string Mahv { get; set; }
        public DateTime? Ngaydk { get; set; }
        public string Ghichu { get; set; }
        public string Manv { get; set; }
        public decimal tongtien { get; set; }
        public decimal? Sotiendatra { get; set; }
        public decimal Sotienconlai { get; set; }
        public virtual Hocvien MahvNavigation { get; set; }
        public virtual Nhanvien ManvNavigation { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
        public virtual ICollection<LopDangkyhoc> LopDangkyhocs { get; set; }
    }
}
