using HocSinhDB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HocSinhDB
{
    public class AppDbContext : DbContext
    {
        public DbSet<HocSinh> hocSinhs { get; set; }
        public DbSet<MonHoc> monHocs { get; set; }
        public DbSet<QuanLyHS> quanLyHs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = ADMIN\\SQLEXPRESS; initial catalog = HocSinhDB; integrated security = sspi;");
        }

    }
}
