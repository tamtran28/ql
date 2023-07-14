﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace hocvien.Model
{
    public partial class Giaovien
    {
        public Giaovien()
        {
            LophocGiaoviens = new HashSet<LophocGiaovien>();
        }

        public string Magv { get; set; }
        public string Hoten { get; set; }
        public DateTime Ngaysinh { get; set; }
        public int Gioitinh { get; set; }
        public string Diachi { get; set; }
        [MaxLength(10, ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string Sdt { get; set; }
        public string Capdoday { get; set; }
        public string Trinhdo { get; set; }
        public string Email { get; set; }
        public string Nguoitao { get; set; }
        public DateTime Ngaytao { get; set; }
        public string Matkhau { get; set; }

        public virtual ICollection<LophocGiaovien> LophocGiaoviens { get; set; }
    }
}
