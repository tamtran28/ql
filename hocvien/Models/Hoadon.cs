﻿using System;
using System.Collections.Generic;

#nullable disable

namespace hocvien.Models
{
    public partial class Hoadon
    {
        public string Mahd { get; set; }
        public DateTime Ngaythu { get; set; }
        public decimal Tongtienthanhtoan { get; set; }
        public string Ghichu { get; set; }
        public string Hinhthuc { get; set; }
        public string Trangthaithanhtoan { get; set; }
        public string Manv { get; set; }
       // public string Mahv { get; set; }
        public string Maphieu { get; set; }

        public virtual Nhanvien ManvNavigation { get; set; }
        public virtual Phieudangkyhoc MaphieuNavigation { get; set; }
    }
}
