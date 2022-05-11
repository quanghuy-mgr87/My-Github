using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HVIT_EF_QLNgayHoc.Migrations
{
    public partial class addDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "khoaHocs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenKhoaHoc = table.Column<string>(nullable: true),
                    moTa = table.Column<string>(nullable: true),
                    hocPhi = table.Column<int>(nullable: true),
                    ngayBatDau = table.Column<DateTime>(nullable: false),
                    ngayKetThuc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khoaHocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hocViens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    khoaHocId = table.Column<int>(nullable: true),
                    hoTen = table.Column<string>(nullable: true),
                    ngaySinh = table.Column<DateTime>(nullable: false),
                    queQuan = table.Column<string>(nullable: true),
                    diaChi = table.Column<string>(nullable: true),
                    soDienThoai = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hocViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hocViens_khoaHocs_khoaHocId",
                        column: x => x.khoaHocId,
                        principalTable: "khoaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ngayHocs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    khoaHocId = table.Column<int>(nullable: true),
                    noiDung = table.Column<string>(nullable: true),
                    ghiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ngayHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ngayHocs_khoaHocs_khoaHocId",
                        column: x => x.khoaHocId,
                        principalTable: "khoaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hocViens_khoaHocId",
                table: "hocViens",
                column: "khoaHocId");

            migrationBuilder.CreateIndex(
                name: "IX_ngayHocs_khoaHocId",
                table: "ngayHocs",
                column: "khoaHocId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hocViens");

            migrationBuilder.DropTable(
                name: "ngayHocs");

            migrationBuilder.DropTable(
                name: "khoaHocs");
        }
    }
}
