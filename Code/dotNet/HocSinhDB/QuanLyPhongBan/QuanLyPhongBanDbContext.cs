using Microsoft.EntityFrameworkCore;
using QuanLyPhongBan.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyPhongBan
{
    public class QuanLyPhongBanDbContext : DbContext
    {
        public DbSet<DuAn> DuAn { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<PhongBan> PhongBan { get; set; }
        public DbSet<QuanLyDuAn> QuanLyDuAn { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = ADMIN\\SQLEXPRESS; initial catalog = QuanLyPhongBan_Entity; integrated security = sspi;");
        }

    }
}
