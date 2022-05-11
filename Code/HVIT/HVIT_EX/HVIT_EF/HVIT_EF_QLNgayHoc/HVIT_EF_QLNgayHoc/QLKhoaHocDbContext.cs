using HVIT_EF_QLNgayHoc.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNgayHoc
{
    class QLKhoaHocDbContext : DbContext
    {
        public DbSet<NgayHoc> ngayHocs { get; set; }
        public DbSet<KhoaHoc> khoaHocs { get; set; }
        public DbSet<HocVien> hocViens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-FCU7UJN\\SQLEXPRESS; initial catalog = EF_QuanLyKhoaHoc; integrated security = SSPI;");
        }
    }
}
