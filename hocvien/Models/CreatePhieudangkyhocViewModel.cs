using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace hocvien.Model
{
	public class CreatePhieudangkyhocViewModel
	{
        public string MaPhieu { get; set; }
        public string MaHV { get; set; }
        public DateTime NgayDangKy { get; set; }
        public string GhiChu { get; set; }
        public List<string> SelectedLoptuyensinhs { get; set; }
        public MultiSelectList Loptuyensinhs { get; set; }
    }
}


