using Microsoft.EntityFrameworkCore.Migrations;

namespace HVIT_EF_NhanVien.Migrations
{
    public partial class addDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "duAns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenDuAn = table.Column<string>(nullable: true),
                    moTa = table.Column<string>(nullable: true),
                    ghiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_duAns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nhanViens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoTen = table.Column<string>(nullable: true),
                    soDienThoai = table.Column<string>(nullable: true),
                    diaChi = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    heSoLuong = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhanViens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "phanCongs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nhanVienId = table.Column<int>(nullable: true),
                    duAnId = table.Column<int>(nullable: true),
                    soGioLam = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phanCongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phanCongs_duAns_duAnId",
                        column: x => x.duAnId,
                        principalTable: "duAns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_phanCongs_nhanViens_nhanVienId",
                        column: x => x.nhanVienId,
                        principalTable: "nhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_phanCongs_duAnId",
                table: "phanCongs",
                column: "duAnId");

            migrationBuilder.CreateIndex(
                name: "IX_phanCongs_nhanVienId",
                table: "phanCongs",
                column: "nhanVienId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "phanCongs");

            migrationBuilder.DropTable(
                name: "duAns");

            migrationBuilder.DropTable(
                name: "nhanViens");
        }
    }
}
