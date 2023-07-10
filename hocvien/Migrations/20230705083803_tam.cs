using Microsoft.EntityFrameworkCore.Migrations;

namespace hocvien.Migrations
{
    public partial class tam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Maloptuyensinh",
                table: "phieudangkyhoc");

            migrationBuilder.DropColumn(
                name: "mahv",
                table: "lophoc");

            migrationBuilder.AddColumn<int>(
                name: "trangthai",
                table: "phieudiem",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "manv",
                table: "phieudangkyhoc",
                type: "char(20)",
                unicode: false,
                fixedLength: true,
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "trangthai",
                table: "monhoc",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "thuhoc",
                table: "loptuyensinh",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "giohoc",
                table: "loptuyensinh",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "macahoc",
                table: "loptuyensinh",
                type: "char(50)",
                unicode: false,
                fixedLength: true,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Trangthai",
                table: "lop_dangkyhoc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "trangthai",
                table: "khoahoc",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Sotienconlai",
                table: "hoadon",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Sotiendatra",
                table: "hoadon",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "matkhau",
                table: "giaovien",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "cahoc",
                columns: table => new
                {
                    macahoc = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    thuhoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    giohoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewTable", x => x.macahoc);
                });

            migrationBuilder.CreateIndex(
                name: "IX_phieudangkyhoc_manv",
                table: "phieudangkyhoc",
                column: "manv");

            migrationBuilder.CreateIndex(
                name: "IX_loptuyensinh_macahoc",
                table: "loptuyensinh",
                column: "macahoc");

            migrationBuilder.AddForeignKey(
                name: "FKloptuyensinhch",
                table: "loptuyensinh",
                column: "macahoc",
                principalTable: "cahoc",
                principalColumn: "macahoc",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FKphieudangkyhocnv",
                table: "phieudangkyhoc",
                column: "manv",
                principalTable: "nhanvien",
                principalColumn: "manv",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKloptuyensinhch",
                table: "loptuyensinh");

            migrationBuilder.DropForeignKey(
                name: "FKphieudangkyhocnv",
                table: "phieudangkyhoc");

            migrationBuilder.DropTable(
                name: "cahoc");

            migrationBuilder.DropIndex(
                name: "IX_phieudangkyhoc_manv",
                table: "phieudangkyhoc");

            migrationBuilder.DropIndex(
                name: "IX_loptuyensinh_macahoc",
                table: "loptuyensinh");

            migrationBuilder.DropColumn(
                name: "trangthai",
                table: "phieudiem");

            migrationBuilder.DropColumn(
                name: "manv",
                table: "phieudangkyhoc");

            migrationBuilder.DropColumn(
                name: "trangthai",
                table: "monhoc");

            migrationBuilder.DropColumn(
                name: "macahoc",
                table: "loptuyensinh");

            migrationBuilder.DropColumn(
                name: "Trangthai",
                table: "lop_dangkyhoc");

            migrationBuilder.DropColumn(
                name: "trangthai",
                table: "khoahoc");

            migrationBuilder.DropColumn(
                name: "Sotienconlai",
                table: "hoadon");

            migrationBuilder.DropColumn(
                name: "Sotiendatra",
                table: "hoadon");

            migrationBuilder.DropColumn(
                name: "matkhau",
                table: "giaovien");

            migrationBuilder.AddColumn<string>(
                name: "Maloptuyensinh",
                table: "phieudangkyhoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "thuhoc",
                table: "loptuyensinh",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "giohoc",
                table: "loptuyensinh",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mahv",
                table: "lophoc",
                type: "char(50)",
                unicode: false,
                fixedLength: true,
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
