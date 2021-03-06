// <auto-generated />
using System;
using HVIT_EF_NhanVien;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HVIT_EF_NhanVien.Migrations
{
    [DbContext(typeof(DuAnDbContext))]
    [Migration("20200810125712_addDatabase")]
    partial class addDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HVIT_EF_NhanVien.Entities.DuAn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ghiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("moTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tenDuAn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("duAns");
                });

            modelBuilder.Entity("HVIT_EF_NhanVien.Entities.NhanVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("diaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("heSoLuong")
                        .HasColumnType("float");

                    b.Property<string>("hoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("soDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("nhanViens");
                });

            modelBuilder.Entity("HVIT_EF_NhanVien.Entities.PhanCong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("duAnId")
                        .HasColumnType("int");

                    b.Property<int?>("nhanVienId")
                        .HasColumnType("int");

                    b.Property<int?>("soGioLam")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("duAnId");

                    b.HasIndex("nhanVienId");

                    b.ToTable("phanCongs");
                });

            modelBuilder.Entity("HVIT_EF_NhanVien.Entities.PhanCong", b =>
                {
                    b.HasOne("HVIT_EF_NhanVien.Entities.DuAn", "DuAn")
                        .WithMany("phanCongs")
                        .HasForeignKey("duAnId");

                    b.HasOne("HVIT_EF_NhanVien.Entities.NhanVien", "NhanVien")
                        .WithMany("phanCongs")
                        .HasForeignKey("nhanVienId");
                });
#pragma warning restore 612, 618
        }
    }
}
