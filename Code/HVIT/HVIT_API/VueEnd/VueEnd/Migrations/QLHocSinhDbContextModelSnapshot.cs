﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VueEnd;

namespace VueEnd.Migrations
{
    [DbContext(typeof(QLHocSinhDbContext))]
    partial class QLHocSinhDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VueEnd.Entities.HocSinh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GioiTinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LopId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("QueQuan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LopId");

                    b.ToTable("HocSinhs");
                });

            modelBuilder.Entity("VueEnd.Entities.LoaiKhoaHoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChuDe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoaiKhoaHocs");
                });

            modelBuilder.Entity("VueEnd.Entities.Lop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Gia")
                        .HasColumnType("int");

                    b.Property<string>("HinhThuc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KhuyenMai")
                        .HasColumnType("int");

                    b.Property<string>("LinkAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LoaiKhoaHocId")
                        .HasColumnType("int");

                    b.Property<int?>("SiSo")
                        .HasColumnType("int");

                    b.Property<string>("TenLop")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LoaiKhoaHocId");

                    b.ToTable("Lops");
                });

            modelBuilder.Entity("VueEnd.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuyenAdmin")
                        .HasColumnType("int");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaiKhoan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VueEnd.Entities.HocSinh", b =>
                {
                    b.HasOne("VueEnd.Entities.Lop", "Lop")
                        .WithMany("HocSinhs")
                        .HasForeignKey("LopId");
                });

            modelBuilder.Entity("VueEnd.Entities.Lop", b =>
                {
                    b.HasOne("VueEnd.Entities.LoaiKhoaHoc", "LoaiKhoaHoc")
                        .WithMany("Lops")
                        .HasForeignKey("LoaiKhoaHocId");
                });
#pragma warning restore 612, 618
        }
    }
}