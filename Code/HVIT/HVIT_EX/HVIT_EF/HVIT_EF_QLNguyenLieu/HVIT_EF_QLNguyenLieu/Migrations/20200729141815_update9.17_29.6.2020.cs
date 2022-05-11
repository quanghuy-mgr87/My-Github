using Microsoft.EntityFrameworkCore.Migrations;

namespace HVIT_EF_QLNguyenLieu.Migrations
{
    public partial class update917_2962020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SoLuongBan",
                table: "ChiTietPhieuThus",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SoLuongBan",
                table: "ChiTietPhieuThus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
