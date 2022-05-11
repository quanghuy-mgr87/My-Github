using Microsoft.EntityFrameworkCore.Migrations;

namespace HVITQuanLyNhanVien.Migrations
{
    public partial class QLNV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhanCong",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVienId = table.Column<int>(nullable: true),
                    DuAnId = table.Column<int>(nullable: true),
                    SoGioLam = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanCong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DuAn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDuAn = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    PhanCongId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuAn_PhanCong_PhanCongId",
                        column: x => x.PhanCongId,
                        principalTable: "PhanCong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(nullable: true),
                    SDT = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    HeSoLuong = table.Column<double>(nullable: true),
                    PhanCongId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanVien_PhanCong_PhanCongId",
                        column: x => x.PhanCongId,
                        principalTable: "PhanCong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_PhanCongId",
                table: "DuAn",
                column: "PhanCongId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_PhanCongId",
                table: "NhanVien",
                column: "PhanCongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuAn");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "PhanCong");
        }
    }
}
