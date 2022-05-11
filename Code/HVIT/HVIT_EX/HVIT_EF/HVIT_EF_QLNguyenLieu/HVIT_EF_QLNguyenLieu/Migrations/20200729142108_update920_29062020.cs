using Microsoft.EntityFrameworkCore.Migrations;

namespace HVIT_EF_QLNguyenLieu.Migrations
{
    public partial class update920_29062020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SoLuongBan",
                table: "ChiTietPhieuThus",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SoLuongBan",
                table: "ChiTietPhieuThus",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
