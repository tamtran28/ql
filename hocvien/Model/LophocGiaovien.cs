using System;
using System.Collections.Generic;

#nullable disable

namespace hocvien.Model
{
    public partial class LophocGiaovien
    {
        public string Malophoc { get; set; }
        public string Magv { get; set; }

        public virtual Giaovien MagvNavigation { get; set; }
        public virtual Lophoc MalophocNavigation { get; set; }
    }
}
