using Microsoft.EntityFrameworkCore.Migrations;

namespace HVIT_EF_QLNguyenLieu.Migrations
{
    public partial class addRecycleBin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecycleBins",
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
                    table.PrimaryKey("PK_RecycleBins", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecycleBins");
        }
    }
}
