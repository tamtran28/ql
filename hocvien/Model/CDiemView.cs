namespace hocvien.Model
{
    public class CDiemView
    {
        public string Hoten { get; set; }
        public string Malophoc { get; set; }
        public string Mahv { get; set; }
        public int? Diemdoc { get; set; }
        public int? Diemviet { get; set; }
        public int? Diemnoi { get; set; }
        public int? Diemnghe { get; set; }
        public int? Trangthai { get; set; }

        public virtual Hocvien MahvNavigation { get; set; }
        public virtual Lophoc MalophocNavigation { get; set; }
    }
}
