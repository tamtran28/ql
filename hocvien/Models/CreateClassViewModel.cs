using System;
using System.Collections.Generic;

namespace hocvien.Model
{
	public class CreateClassViewModel
	{
        public string Makh { get; set; }
        
        public List<string> MamhList { get; set; }
        public DateTime Ngaybatdau { get; set; }
        public DateTime Ngayketthuc { get; set; }
        public string Giohoc { get; set; }
    }
}

