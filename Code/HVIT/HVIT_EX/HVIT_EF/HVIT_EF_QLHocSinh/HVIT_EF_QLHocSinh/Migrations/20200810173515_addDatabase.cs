using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HVIT_EF_QLHocSinh.Migrations
{
    public partial class addDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLop = table.Column<string>(nullable: true),
                    SiSo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hocSinhs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LopId = table.Column<int>(nullable: false),
                    HoTen = table.Column<string>(nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    QueQuan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hocSinhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hocSinhs_lops_LopId",
                        column: x => x.LopId,
                        principalTable: "lops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hocSinhs_LopId",
                table: "hocSinhs",
                column: "LopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hocSinhs");

            migrationBuilder.DropTable(
                name: "lops");
        }
    }
}
