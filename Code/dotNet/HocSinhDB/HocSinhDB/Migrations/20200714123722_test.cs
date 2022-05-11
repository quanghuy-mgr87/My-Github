using Microsoft.EntityFrameworkCore.Migrations;

namespace HocSinhDB.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quanLyHs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HocSinhId = table.Column<int>(nullable: false),
                    MonHocId = table.Column<int>(nullable: false),
                    DiemPhay = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quanLyHs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hocSinhs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    TenLop = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    QuanLyHSId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hocSinhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hocSinhs_quanLyHs_QuanLyHSId",
                        column: x => x.QuanLyHSId,
                        principalTable: "quanLyHs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "monHocs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMon = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    QuanLyHSId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_monHocs_quanLyHs_QuanLyHSId",
                        column: x => x.QuanLyHSId,
                        principalTable: "quanLyHs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hocSinhs_QuanLyHSId",
                table: "hocSinhs",
                column: "QuanLyHSId");

            migrationBuilder.CreateIndex(
                name: "IX_monHocs_QuanLyHSId",
                table: "monHocs",
                column: "QuanLyHSId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hocSinhs");

            migrationBuilder.DropTable(
                name: "monHocs");

            migrationBuilder.DropTable(
                name: "quanLyHs");
        }
    }
}
