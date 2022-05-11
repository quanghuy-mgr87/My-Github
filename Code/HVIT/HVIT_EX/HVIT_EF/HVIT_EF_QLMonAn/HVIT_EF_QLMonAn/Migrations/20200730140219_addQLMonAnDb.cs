using Microsoft.EntityFrameworkCore.Migrations;

namespace HVIT_EF_QLMonAn.Migrations
{
    public partial class addQLMonAnDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "congThucRecycles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguyenLieuId = table.Column<int>(nullable: true),
                    MonAnId = table.Column<int>(nullable: true),
                    SoLuong = table.Column<int>(nullable: true),
                    DonViTinh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_congThucRecycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loaiMonAns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiMonAns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "monAnRecycles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiMonAnId = table.Column<int>(nullable: true),
                    TenMon = table.Column<string>(nullable: true),
                    GiaBan = table.Column<double>(nullable: true),
                    GioiThieu = table.Column<string>(nullable: true),
                    CachLam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monAnRecycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nguyenLieus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguyenLieu = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguyenLieus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "monAns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiMonAnId = table.Column<int>(nullable: true),
                    TenMon = table.Column<string>(nullable: true),
                    GiaBan = table.Column<double>(nullable: true),
                    GioiThieu = table.Column<string>(nullable: true),
                    CachLam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monAns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_monAns_loaiMonAns_LoaiMonAnId",
                        column: x => x.LoaiMonAnId,
                        principalTable: "loaiMonAns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "congThucs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguyenLieuId = table.Column<int>(nullable: true),
                    MonAnId = table.Column<int>(nullable: true),
                    SoLuong = table.Column<int>(nullable: true),
                    DonViTinh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_congThucs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_congThucs_monAns_MonAnId",
                        column: x => x.MonAnId,
                        principalTable: "monAns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_congThucs_nguyenLieus_NguyenLieuId",
                        column: x => x.NguyenLieuId,
                        principalTable: "nguyenLieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_congThucs_MonAnId",
                table: "congThucs",
                column: "MonAnId");

            migrationBuilder.CreateIndex(
                name: "IX_congThucs_NguyenLieuId",
                table: "congThucs",
                column: "NguyenLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_monAns_LoaiMonAnId",
                table: "monAns",
                column: "LoaiMonAnId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "congThucRecycles");

            migrationBuilder.DropTable(
                name: "congThucs");

            migrationBuilder.DropTable(
                name: "monAnRecycles");

            migrationBuilder.DropTable(
                name: "monAns");

            migrationBuilder.DropTable(
                name: "nguyenLieus");

            migrationBuilder.DropTable(
                name: "loaiMonAns");
        }
    }
}
