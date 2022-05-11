using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HVIT_EF_QLNguyenLieu.Migrations
{
    public partial class addQLNLDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiNguyenLieus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiNguyenLieus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhieuThus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayLap = table.Column<DateTime>(nullable: false),
                    NhanVienLap = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    ThanhTien = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuThus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguyenLieus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiNguyenLieuId = table.Column<int>(nullable: true),
                    TenNguyenLieu = table.Column<string>(nullable: true),
                    GiaBan = table.Column<double>(nullable: true),
                    DonViTinh = table.Column<string>(nullable: true),
                    SoLuongKho = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguyenLieus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguyenLieus_LoaiNguyenLieus_LoaiNguyenLieuId",
                        column: x => x.LoaiNguyenLieuId,
                        principalTable: "LoaiNguyenLieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuThus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguyenLieuId = table.Column<int>(nullable: true),
                    PhieuThuId = table.Column<int>(nullable: true),
                    SoLuongBan = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuThus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuThus_NguyenLieus_NguyenLieuId",
                        column: x => x.NguyenLieuId,
                        principalTable: "NguyenLieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuThus_PhieuThus_PhieuThuId",
                        column: x => x.PhieuThuId,
                        principalTable: "PhieuThus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuThus_NguyenLieuId",
                table: "ChiTietPhieuThus",
                column: "NguyenLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuThus_PhieuThuId",
                table: "ChiTietPhieuThus",
                column: "PhieuThuId");

            migrationBuilder.CreateIndex(
                name: "IX_NguyenLieus_LoaiNguyenLieuId",
                table: "NguyenLieus",
                column: "LoaiNguyenLieuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietPhieuThus");

            migrationBuilder.DropTable(
                name: "NguyenLieus");

            migrationBuilder.DropTable(
                name: "PhieuThus");

            migrationBuilder.DropTable(
                name: "LoaiNguyenLieus");
        }
    }
}
