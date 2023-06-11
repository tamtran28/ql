using System;
using System.Collections.Generic;
using System.Linq;

namespace hocvien.Model
{
    public class CChitietphieudangkyViewcs
    {
        public string Maphieu { get; set; }
        public string Mahv { get; set; }
        public String Ngaydk { get; set; }
        public string Ghichu { get; set; }
        public string Maloptuyensinh { get; set; }
        public string Tenloptuyensinh { get; set; }
        //public static List<CChitietphieudangkyViewcs> getDSChitietHoadon(Model.Phieudangkyhoc hd)
        //{
        //    return hd.LopDangkyhocs.Select(x => new CChitietphieudangkyViewcs
        //    {
        //        Maloptuyensinh = x.Maloptuyensinh,
        //        Tenloptuyensinh = x.MalopNavigation.Tenloptuyensinh,
        //        Ngaydk = x.MaphieuNavigation.Ngaydk.Value.ToShortDateString(),
        //        //Mahv = x.Don.Value.ToString(),
        //        Mahv = x.MaphieuNavigation.Mahv,
        //       // Thanhtien = (x.Soluong.Value * x.Dongia.Value).ToString()
        //    }).ToList();
        //}
    }
}
