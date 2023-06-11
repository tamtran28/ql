using System;
using System.Collections.Generic;

namespace hocvien.Model
{
    public class CHocvienview
    {
        public string Mahv { get; set; }
        public string Hoten { get; set; }
        public string Ngaysinh { get; set; }
        public string Sdt { get; set; }
        public string Diachi { get; set; }
        public string Gioitinh { get; set; }
        public string Trangthai { get; set; }

        public string Trungtamhoc { get; set; }
        public string Malophoc { get; set; }
        public string Tenlop { get; set; }

        public virtual ICollection<Phieudangkyhoc> Phieudangkyhocs { get; set; }
        public virtual ICollection<Phieudiem> Phieudiems
        {
            get; set;

        }
    }
}
