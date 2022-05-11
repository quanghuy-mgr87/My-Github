using HVITQuanLyNhanVien.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVITQuanLyNhanVien
{
    public class QuanLyNhanVienDbContext : DbContext
    {
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<DuAn> DuAn { get; set; }
        public DbSet<PhanCong> PhanCong { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = ADMIN\\SQLEXPRESS; initial catalog = QuanLyNhanVienDB; integrated security = sspi;");
        }
    }
}
