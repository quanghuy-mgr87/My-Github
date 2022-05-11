using HVIT_EF_NhanVien.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_NhanVien
{
    class DuAnDbContext : DbContext
    {
        public DbSet<NhanVien> nhanViens { get; set; }
        public DbSet<DuAn> duAns { get; set; }
        public DbSet<PhanCong> phanCongs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-FCU7UJN\\SQLEXPRESS; initial catalog = EF_NhanVien; integrated security = SSPI;");
        }
    }
}
