using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VueEnd.Migrations
{
    public partial class createDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiKhoaHoc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChuDe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiKhoaHoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoan = table.Column<string>(nullable: true),
                    MatKhau = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SoDienThoai = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLop = table.Column<string>(nullable: true),
                    LinkAnh = table.Column<string>(nullable: true),
                    HinhThuc = table.Column<string>(nullable: true),
                    Gia = table.Column<int>(nullable: true),
                    KhuyenMai = table.Column<int>(nullable: true),
                    SiSo = table.Column<int>(nullable: true),
                    LoaiKhoaHocId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lops_LoaiKhoaHoc_LoaiKhoaHocId",
                        column: x => x.LoaiKhoaHocId,
                        principalTable: "LoaiKhoaHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HocSinhs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    LopId = table.Column<int>(nullable: true),
                    QueQuan = table.Column<string>(nullable: true),
                    GioiTinh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocSinhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HocSinhs_Lops_LopId",
                        column: x => x.LopId,
                        principalTable: "Lops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HocSinhs_LopId",
                table: "HocSinhs",
                column: "LopId");

            migrationBuilder.CreateIndex(
                name: "IX_Lops_LoaiKhoaHocId",
                table: "Lops",
                column: "LoaiKhoaHocId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HocSinhs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Lops");

            migrationBuilder.DropTable(
                name: "LoaiKhoaHoc");
        }
    }
}
