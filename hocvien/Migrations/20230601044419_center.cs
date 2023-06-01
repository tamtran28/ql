using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hocvien.Migrations
{
    public partial class center : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "giaovien",
                columns: table => new
                {
                    magv = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    hoten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ngaysinh = table.Column<DateTime>(type: "datetime", nullable: false),
                    gioitinh = table.Column<int>(type: "int", nullable: false),
                    diachi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SDT = table.Column<int>(type: "int", nullable: false),
                    capdoday = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    trinhdo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    nguoitao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ngaytao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__giaovien__7A2118CDC4E0E876", x => x.magv);
                });

            migrationBuilder.CreateTable(
                name: "hocvien",
                columns: table => new
                {
                    mahv = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    hoten = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ngaysinh = table.Column<DateTime>(type: "date", nullable: false),
                    sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diachi = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    gioitinh = table.Column<int>(type: "int", nullable: false),
                    trangthai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    nguoitao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ngaytao = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__hocvien__7A2100ACCDE8976F", x => x.mahv);
                });

            migrationBuilder.CreateTable(
                name: "khoahoc",
                columns: table => new
                {
                    makh = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    tenkh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    thoiluong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    motakh = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    nguoitao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ngaytao = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__khoahoc__7A21BB4CEC06FD83", x => x.makh);
                });

            migrationBuilder.CreateTable(
                name: "monhoc",
                columns: table => new
                {
                    mamh = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    tenmh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    mota = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    hocphi = table.Column<decimal>(type: "money", nullable: false),
                    nguoitao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ngaytao = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__monhoc__7A21CB8E6E58B74A", x => x.mamh);
                });

            migrationBuilder.CreateTable(
                name: "nhanvien",
                columns: table => new
                {
                    manv = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    hoten = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ngaysinh = table.Column<DateTime>(type: "date", nullable: false),
                    diachi = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    gioitinh = table.Column<byte>(type: "tinyint", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    sdt = table.Column<int>(type: "int", nullable: false),
                    trangthai = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Matkhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nhom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("manv", x => x.manv);
                });

            migrationBuilder.CreateTable(
                name: "phieudangkyhoc",
                columns: table => new
                {
                    maphieu = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    mahv = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    ngaydk = table.Column<DateTime>(type: "datetime", nullable: true),
                    ghichu = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Maloptuyensinh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__phieudan__A72B5185C862877D", x => x.maphieu);
                    table.ForeignKey(
                        name: "FKphieudangk163725",
                        column: x => x.mahv,
                        principalTable: "hocvien",
                        principalColumn: "mahv",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "loptuyensinh",
                columns: table => new
                {
                    maloptuyensinh = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    tenloptuyensinh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    trangthai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    nguoitao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ngaytao = table.Column<DateTime>(type: "date", nullable: false),
                    ngaybatdau = table.Column<DateTime>(type: "date", nullable: false),
                    ngayketthuc = table.Column<DateTime>(type: "date", nullable: false),
                    thuhoc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    giohoc = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    makh = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    mamh = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__loptuyen__15F456FDA9F7C730", x => x.maloptuyensinh);
                    table.ForeignKey(
                        name: "FKloptuyensi77378",
                        column: x => x.mamh,
                        principalTable: "monhoc",
                        principalColumn: "mamh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKloptuyensi996854",
                        column: x => x.makh,
                        principalTable: "khoahoc",
                        principalColumn: "makh",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hoadon",
                columns: table => new
                {
                    mahd = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    ngaythu = table.Column<DateTime>(type: "datetime", nullable: false),
                    tongtienthanhtoan = table.Column<decimal>(type: "money", nullable: false),
                    ghichu = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    hinhthuc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    trangthaithanhtoan = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    manv = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    maphieu = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__hoadon__7A2100DE7B55A670", x => x.mahd);
                    table.ForeignKey(
                        name: "FKhoadon404248",
                        column: x => x.manv,
                        principalTable: "nhanvien",
                        principalColumn: "manv",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKhoadon89696",
                        column: x => x.maphieu,
                        principalTable: "phieudangkyhoc",
                        principalColumn: "maphieu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lop_dangkyhoc",
                columns: table => new
                {
                    maphieu = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    maloptuyensinh = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lop_dang__667414EAC3CA8403", x => new { x.maphieu, x.maloptuyensinh });
                    table.ForeignKey(
                        name: "FKlop_dangky777448",
                        column: x => x.maphieu,
                        principalTable: "phieudangkyhoc",
                        principalColumn: "maphieu",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKlop_dangky847460",
                        column: x => x.maloptuyensinh,
                        principalTable: "loptuyensinh",
                        principalColumn: "maloptuyensinh",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lophoc",
                columns: table => new
                {
                    Malophoc = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    mahv = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    phonghoc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    maloptuyensinh = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    Magv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lophoc__03B4ED841809EB80", x => x.Malophoc);
                    table.ForeignKey(
                        name: "FKlophoc12899",
                        column: x => x.maloptuyensinh,
                        principalTable: "loptuyensinh",
                        principalColumn: "maloptuyensinh",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lophoc_giaovien",
                columns: table => new
                {
                    malophoc = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    magv = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__lophoc_g__C416FC08AA169897", x => new { x.malophoc, x.magv });
                    table.ForeignKey(
                        name: "FKlophoc_gia710147",
                        column: x => x.malophoc,
                        principalTable: "lophoc",
                        principalColumn: "Malophoc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKlophoc_gia956872",
                        column: x => x.magv,
                        principalTable: "giaovien",
                        principalColumn: "magv",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "phieudiem",
                columns: table => new
                {
                    malophoc = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    mahv = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    diemdoc = table.Column<int>(type: "int", nullable: true),
                    diemviet = table.Column<int>(type: "int", nullable: true),
                    diemnoi = table.Column<int>(type: "int", nullable: true),
                    diemnghe = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__phieudie__D416FD8EF39C6EED", x => new { x.malophoc, x.mahv });
                    table.ForeignKey(
                        name: "FKphieudiem484564",
                        column: x => x.malophoc,
                        principalTable: "lophoc",
                        principalColumn: "Malophoc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKphieudiem797904",
                        column: x => x.mahv,
                        principalTable: "hocvien",
                        principalColumn: "mahv",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__giaovien__CA1930A5274DE8AF",
                table: "giaovien",
                column: "SDT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_hoadon_manv",
                table: "hoadon",
                column: "manv");

            migrationBuilder.CreateIndex(
                name: "IX_hoadon_maphieu",
                table: "hoadon",
                column: "maphieu");

            migrationBuilder.CreateIndex(
                name: "IX_lop_dangkyhoc_maloptuyensinh",
                table: "lop_dangkyhoc",
                column: "maloptuyensinh");

            migrationBuilder.CreateIndex(
                name: "IX_lophoc_maloptuyensinh",
                table: "lophoc",
                column: "maloptuyensinh");

            migrationBuilder.CreateIndex(
                name: "IX_lophoc_giaovien_magv",
                table: "lophoc_giaovien",
                column: "magv");

            migrationBuilder.CreateIndex(
                name: "IX_loptuyensinh_makh",
                table: "loptuyensinh",
                column: "makh");

            migrationBuilder.CreateIndex(
                name: "IX_loptuyensinh_mamh",
                table: "loptuyensinh",
                column: "mamh");

            migrationBuilder.CreateIndex(
                name: "UQ__nhanvien__DDDFB4832ACE57B4",
                table: "nhanvien",
                column: "sdt",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_phieudangkyhoc_mahv",
                table: "phieudangkyhoc",
                column: "mahv");

            migrationBuilder.CreateIndex(
                name: "IX_phieudiem_mahv",
                table: "phieudiem",
                column: "mahv");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hoadon");

            migrationBuilder.DropTable(
                name: "lop_dangkyhoc");

            migrationBuilder.DropTable(
                name: "lophoc_giaovien");

            migrationBuilder.DropTable(
                name: "phieudiem");

            migrationBuilder.DropTable(
                name: "nhanvien");

            migrationBuilder.DropTable(
                name: "phieudangkyhoc");

            migrationBuilder.DropTable(
                name: "giaovien");

            migrationBuilder.DropTable(
                name: "lophoc");

            migrationBuilder.DropTable(
                name: "hocvien");

            migrationBuilder.DropTable(
                name: "loptuyensinh");

            migrationBuilder.DropTable(
                name: "monhoc");

            migrationBuilder.DropTable(
                name: "khoahoc");
        }
    }
}
