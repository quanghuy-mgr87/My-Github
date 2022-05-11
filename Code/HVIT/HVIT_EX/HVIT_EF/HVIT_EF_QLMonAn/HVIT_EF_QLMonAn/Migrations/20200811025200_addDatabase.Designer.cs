﻿// <auto-generated />
using System;
using HVIT_EF_QLMonAn;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HVIT_EF_QLMonAn.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200811025200_addDatabase")]
    partial class addDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HVIT_EF_QLMonAn.Entities.CongThuc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DonViTinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MonAnId")
                        .HasColumnType("int");

                    b.Property<int?>("NguyenLieuId")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MonAnId");

                    b.HasIndex("NguyenLieuId");

                    b.ToTable("congThucs");
                });

            modelBuilder.Entity("HVIT_EF_QLMonAn.Entities.CongThucRecycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DonViTinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MonAnId")
                        .HasColumnType("int");

                    b.Property<int?>("NguyenLieuId")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("congThucRecycles");
                });

            modelBuilder.Entity("HVIT_EF_QLMonAn.Entities.LoaiMonAn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLoai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("loaiMonAns");
                });

            modelBuilder.Entity("HVIT_EF_QLMonAn.Entities.MonAn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CachLam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("GiaBan")
                        .HasColumnType("float");

                    b.Property<string>("GioiThieu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LoaiMonAnId")
                        .HasColumnType("int");

                    b.Property<string>("TenMon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LoaiMonAnId");

                    b.ToTable("monAns");
                });

            modelBuilder.Entity("HVIT_EF_QLMonAn.Entities.MonAnRecycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CachLam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("GiaBan")
                        .HasColumnType("float");

                    b.Property<string>("GioiThieu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LoaiMonAnId")
                        .HasColumnType("int");

                    b.Property<string>("TenMon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("monAnRecycles");
                });

            modelBuilder.Entity("HVIT_EF_QLMonAn.Entities.NguyenLieu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNguyenLieu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("nguyenLieus");
                });

            modelBuilder.Entity("HVIT_EF_QLMonAn.Entities.CongThuc", b =>
                {
                    b.HasOne("HVIT_EF_QLMonAn.Entities.MonAn", "MonAn")
                        .WithMany("CongThucs")
                        .HasForeignKey("MonAnId");

                    b.HasOne("HVIT_EF_QLMonAn.Entities.NguyenLieu", "NguyenLieu")
                        .WithMany("CongThucs")
                        .HasForeignKey("NguyenLieuId");
                });

            modelBuilder.Entity("HVIT_EF_QLMonAn.Entities.MonAn", b =>
                {
                    b.HasOne("HVIT_EF_QLMonAn.Entities.LoaiMonAn", "LoaiMonAn")
                        .WithMany("MonAns")
                        .HasForeignKey("LoaiMonAnId");
                });
#pragma warning restore 612, 618
        }
    }
}
