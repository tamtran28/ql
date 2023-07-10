using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace hocvien.Model
{
    public partial class centerContext : DbContext
    {
        public centerContext()
        {
        }

        public centerContext(DbContextOptions<centerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cahoc> Cahocs { get; set; }
        public virtual DbSet<Giaovien> Giaoviens { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Hocvien> Hocviens { get; set; }
        public virtual DbSet<Khoahoc> Khoahocs { get; set; }
        public virtual DbSet<LopDangkyhoc> LopDangkyhocs { get; set; }
        public virtual DbSet<Lophoc> Lophocs { get; set; }
        public virtual DbSet<LophocGiaovien> LophocGiaoviens { get; set; }
        public virtual DbSet<Loptuyensinh> Loptuyensinhs { get; set; }
        public virtual DbSet<Monhoc> Monhocs { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Phieudangkyhoc> Phieudangkyhocs { get; set; }
        public virtual DbSet<Phieudiem> Phieudiems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=NNGWIN009\\SQLEXPRESS;Database=center;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cahoc>(entity =>
            {
                entity.HasKey(e => e.Macahoc)
                    .HasName("PK_NewTable");

                entity.ToTable("cahoc");

                entity.Property(e => e.Macahoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("macahoc")
                    .IsFixedLength(true);

                entity.Property(e => e.Giohoc)
                    .HasMaxLength(50)
                    .HasColumnName("giohoc");

                entity.Property(e => e.Thuhoc)
                    .HasMaxLength(50)
                    .HasColumnName("thuhoc");
            });

            modelBuilder.Entity<Giaovien>(entity =>
            {
                entity.HasKey(e => e.Magv)
                    .HasName("PK__giaovien__7A2118CDC4E0E876");

                entity.ToTable("giaovien");

                entity.HasIndex(e => e.Sdt, "UQ__giaovien__CA1930A5274DE8AF")
                    .IsUnique();

                entity.Property(e => e.Magv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("magv")
                    .IsFixedLength(true);

                entity.Property(e => e.Capdoday)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("capdoday");

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("diachi");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Gioitinh).HasColumnName("gioitinh");

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("hoten");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("matkhau");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaytao");

                entity.Property(e => e.Nguoitao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nguoitao");

                entity.Property(e => e.Sdt).HasColumnName("SDT");

                entity.Property(e => e.Trinhdo)
                    .HasMaxLength(255)
                    .HasColumnName("trinhdo");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahd)
                    .HasName("PK__hoadon__7A2100DE7B55A670");

                entity.ToTable("hoadon");

                entity.HasIndex(e => e.Manv, "IX_hoadon_manv");

                entity.HasIndex(e => e.Maphieu, "IX_hoadon_maphieu");

                entity.Property(e => e.Mahd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mahd")
                    .IsFixedLength(true);

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(1000)
                    .HasColumnName("ghichu");

                entity.Property(e => e.Hinhthuc)
                    .HasMaxLength(255)
                    .HasColumnName("hinhthuc");

                entity.Property(e => e.Manv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("manv")
                    .IsFixedLength(true);

                entity.Property(e => e.Maphieu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("maphieu")
                    .IsFixedLength(true);

                entity.Property(e => e.Ngaythu)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaythu");

                entity.Property(e => e.Sotiendatra).HasColumnType("money");

                entity.Property(e => e.Tongtienthanhtoan)
                    .HasColumnType("money")
                    .HasColumnName("tongtienthanhtoan");

                entity.Property(e => e.Trangthaithanhtoan)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("trangthaithanhtoan");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Manv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKhoadon404248");

                entity.HasOne(d => d.MaphieuNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Maphieu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKhoadon89696");
            });

            modelBuilder.Entity<Hocvien>(entity =>
            {
                entity.HasKey(e => e.Mahv)
                    .HasName("PK__hocvien__7A2100ACCDE8976F");

                entity.ToTable("hocvien");

                entity.Property(e => e.Mahv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mahv")
                    .IsFixedLength(true);

                entity.Property(e => e.Diachi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("diachi");

                entity.Property(e => e.Gioitinh).HasColumnName("gioitinh");

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("hoten");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("date")
                    .HasColumnName("ngaytao");

                entity.Property(e => e.Nguoitao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nguoitao");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnName("sdt");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(255)
                    .HasColumnName("trangthai");
            });

            modelBuilder.Entity<Khoahoc>(entity =>
            {
                entity.HasKey(e => e.Makh)
                    .HasName("PK__khoahoc__7A21BB4CEC06FD83");

                entity.ToTable("khoahoc");

                entity.Property(e => e.Makh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("makh")
                    .IsFixedLength(true);

                entity.Property(e => e.Motakh)
                    .HasMaxLength(1000)
                    .HasColumnName("motakh");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("date")
                    .HasColumnName("ngaytao");

                entity.Property(e => e.Nguoitao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nguoitao");

                entity.Property(e => e.Tenkh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tenkh");

                //entity.Property(e => e.Thoiluong)
                //    .IsRequired()
                //    .HasMaxLength(50)
                //    .HasColumnName("thoiluong");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(50)
                    .HasColumnName("trangthai");
            });

            modelBuilder.Entity<LopDangkyhoc>(entity =>
            {
                entity.HasKey(e => new { e.Maphieu, e.Maloptuyensinh })
                    .HasName("PK__lop_dang__667414EAC3CA8403");

                entity.ToTable("lop_dangkyhoc");

                entity.HasIndex(e => e.Maloptuyensinh, "IX_lop_dangkyhoc_maloptuyensinh");

                entity.Property(e => e.Maphieu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("maphieu")
                    .IsFixedLength(true);

                entity.Property(e => e.Maloptuyensinh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("maloptuyensinh")
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaloptuyensinhNavigation)
                    .WithMany(p => p.LopDangkyhocs)
                    .HasForeignKey(d => d.Maloptuyensinh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKlop_dangky847460");

                entity.HasOne(d => d.MaphieuNavigation)
                    .WithMany(p => p.LopDangkyhocs)
                    .HasForeignKey(d => d.Maphieu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKlop_dangky777448");
            });

            modelBuilder.Entity<Lophoc>(entity =>
            {
                entity.HasKey(e => e.Malophoc)
                    .HasName("PK__lophoc__03B4ED841809EB80");

                entity.ToTable("lophoc");

                entity.HasIndex(e => e.Maloptuyensinh, "IX_lophoc_maloptuyensinh");

                entity.Property(e => e.Malophoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Maloptuyensinh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("maloptuyensinh")
                    .IsFixedLength(true);

                entity.Property(e => e.Phonghoc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("phonghoc");

                entity.HasOne(d => d.MaloptuyensinhNavigation)
                    .WithMany(p => p.Lophocs)
                    .HasForeignKey(d => d.Maloptuyensinh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKlophoc12899");
            });

            modelBuilder.Entity<LophocGiaovien>(entity =>
            {
                entity.HasKey(e => new { e.Malophoc, e.Magv })
                    .HasName("PK__lophoc_g__C416FC08AA169897");

                entity.ToTable("lophoc_giaovien");

                entity.HasIndex(e => e.Magv, "IX_lophoc_giaovien_magv");

                entity.Property(e => e.Malophoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("malophoc")
                    .IsFixedLength(true);

                entity.Property(e => e.Magv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("magv")
                    .IsFixedLength(true);

                entity.HasOne(d => d.MagvNavigation)
                    .WithMany(p => p.LophocGiaoviens)
                    .HasForeignKey(d => d.Magv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKlophoc_gia956872");

                entity.HasOne(d => d.MalophocNavigation)
                    .WithMany(p => p.LophocGiaoviens)
                    .HasForeignKey(d => d.Malophoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKlophoc_gia710147");
            });

            modelBuilder.Entity<Loptuyensinh>(entity =>
            {
                entity.HasKey(e => e.Maloptuyensinh)
                    .HasName("PK__loptuyen__15F456FDA9F7C730");

                entity.ToTable("loptuyensinh");

                entity.HasIndex(e => e.Makh, "IX_loptuyensinh_makh");

                entity.HasIndex(e => e.Mamh, "IX_loptuyensinh_mamh");

                entity.Property(e => e.Maloptuyensinh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("maloptuyensinh")
                    .IsFixedLength(true);

                //entity.Property(e => e.Giohoc)
                //    .HasMaxLength(50)
                //    .HasColumnName("giohoc");

                entity.Property(e => e.Macahoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("macahoc")
                    .IsFixedLength(true);

                entity.Property(e => e.Makh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("makh")
                    .IsFixedLength(true);

                entity.Property(e => e.Mamh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mamh")
                    .IsFixedLength(true);

                entity.Property(e => e.Ngaybatdau)
                    .HasColumnType("date")
                    .HasColumnName("ngaybatdau");

                entity.Property(e => e.Ngayketthuc)
                    .HasColumnType("date")
                    .HasColumnName("ngayketthuc");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("date")
                    .HasColumnName("ngaytao");

                entity.Property(e => e.Nguoitao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nguoitao");

                entity.Property(e => e.Tenloptuyensinh)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("tenloptuyensinh");

                //entity.Property(e => e.Thuhoc)
                //    .HasMaxLength(255)
                //    .HasColumnName("thuhoc");

                entity.Property(e => e.Trangthai)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("trangthai");

                entity.HasOne(d => d.MacahocNavigation)
                    .WithMany(p => p.Loptuyensinhs)
                    .HasForeignKey(d => d.Macahoc)
                    .HasConstraintName("FKloptuyensinhch");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Loptuyensinhs)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKloptuyensi996854");

                entity.HasOne(d => d.MamhNavigation)
                    .WithMany(p => p.Loptuyensinhs)
                    .HasForeignKey(d => d.Mamh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKloptuyensi77378");
            });

            modelBuilder.Entity<Monhoc>(entity =>
            {
                entity.HasKey(e => e.Mamh)
                    .HasName("PK__monhoc__7A21CB8E6E58B74A");

                entity.ToTable("monhoc");

                entity.Property(e => e.Mamh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mamh")
                    .IsFixedLength(true);

                entity.Property(e => e.Hocphi)
                    .HasColumnType("money")
                    .HasColumnName("hocphi");

                entity.Property(e => e.Mota)
                    .HasMaxLength(1000)
                    .HasColumnName("mota");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("date")
                    .HasColumnName("ngaytao");

                entity.Property(e => e.Nguoitao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nguoitao");

                entity.Property(e => e.Tenmh)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("tenmh");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(50)
                    .HasColumnName("trangthai");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manv)
                    .HasName("manv");

                entity.ToTable("nhanvien");

                entity.HasIndex(e => e.Sdt, "UQ__nhanvien__DDDFB4832ACE57B4")
                    .IsUnique();

                entity.Property(e => e.Manv)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("manv")
                    .IsFixedLength(true);

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("diachi");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Gioitinh).HasColumnName("gioitinh");

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("hoten");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.Nhom)
                    .HasMaxLength(50)
                    .HasColumnName("nhom");

                entity.Property(e => e.Sdt).HasColumnName("sdt");

                entity.Property(e => e.Trangthai)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("trangthai");
            });

            modelBuilder.Entity<Phieudangkyhoc>(entity =>
            {
                entity.HasKey(e => e.Maphieu)
                    .HasName("PK__phieudan__A72B5185C862877D");

                entity.ToTable("phieudangkyhoc");

                entity.HasIndex(e => e.Mahv, "IX_phieudangkyhoc_mahv");

                entity.Property(e => e.Maphieu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("maphieu")
                    .IsFixedLength(true);

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(1000)
                    .HasColumnName("ghichu");

                entity.Property(e => e.Mahv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mahv")
                    .IsFixedLength(true);

                entity.Property(e => e.Manv)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("manv")
                    .IsFixedLength(true);

                entity.Property(e => e.Ngaydk)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaydk");

                entity.HasOne(d => d.MahvNavigation)
                    .WithMany(p => p.Phieudangkyhocs)
                    .HasForeignKey(d => d.Mahv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKphieudangk163725");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Phieudangkyhocs)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FKphieudangkyhocnv");
            });

            modelBuilder.Entity<Phieudiem>(entity =>
            {
                entity.HasKey(e => new { e.Malophoc, e.Mahv })
                    .HasName("PK__phieudie__D416FD8EF39C6EED");

                entity.ToTable("phieudiem");

                entity.HasIndex(e => e.Mahv, "IX_phieudiem_mahv");

                entity.Property(e => e.Malophoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("malophoc")
                    .IsFixedLength(true);

                entity.Property(e => e.Mahv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mahv")
                    .IsFixedLength(true);

                entity.Property(e => e.Diemdoc).HasColumnName("diemdoc");

                entity.Property(e => e.Diemnghe).HasColumnName("diemnghe");

                entity.Property(e => e.Diemnoi).HasColumnName("diemnoi");

                entity.Property(e => e.Diemviet).HasColumnName("diemviet");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(50)
                    .HasColumnName("trangthai");

                entity.HasOne(d => d.MahvNavigation)
                    .WithMany(p => p.Phieudiems)
                    .HasForeignKey(d => d.Mahv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKphieudiem797904");

                entity.HasOne(d => d.MalophocNavigation)
                    .WithMany(p => p.Phieudiems)
                    .HasForeignKey(d => d.Malophoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKphieudiem484564");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
