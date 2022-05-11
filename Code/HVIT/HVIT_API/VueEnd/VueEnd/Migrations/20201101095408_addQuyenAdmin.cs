using Microsoft.EntityFrameworkCore.Migrations;

namespace VueEnd.Migrations
{
    public partial class addQuyenAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuyenAdmin",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuyenAdmin",
                table: "Users");
        }
    }
}
