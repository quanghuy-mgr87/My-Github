using Microsoft.EntityFrameworkCore.Migrations;

namespace VueEnd.Migrations
{
    public partial class update271020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lops_LoaiKhoaHoc_LoaiKhoaHocId",
                table: "Lops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiKhoaHoc",
                table: "LoaiKhoaHoc");

            migrationBuilder.RenameTable(
                name: "LoaiKhoaHoc",
                newName: "LoaiKhoaHocs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiKhoaHocs",
                table: "LoaiKhoaHocs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lops_LoaiKhoaHocs_LoaiKhoaHocId",
                table: "Lops",
                column: "LoaiKhoaHocId",
                principalTable: "LoaiKhoaHocs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lops_LoaiKhoaHocs_LoaiKhoaHocId",
                table: "Lops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiKhoaHocs",
                table: "LoaiKhoaHocs");

            migrationBuilder.RenameTable(
                name: "LoaiKhoaHocs",
                newName: "LoaiKhoaHoc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiKhoaHoc",
                table: "LoaiKhoaHoc",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lops_LoaiKhoaHoc_LoaiKhoaHocId",
                table: "Lops",
                column: "LoaiKhoaHocId",
                principalTable: "LoaiKhoaHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
