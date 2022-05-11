using HVIT_EF_QLMonAn.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLMonAn
{
    class AppDbContext : DbContext
    {
        public DbSet<CongThuc> congThucs { get; set; }
        public DbSet<LoaiMonAn> loaiMonAns { get; set; }
        public DbSet<MonAn> monAns { get; set; }
        public DbSet<NguyenLieu> nguyenLieus { get; set; }
        public DbSet<CongThucRecycle> congThucRecycles { get; set; }
        public DbSet<MonAnRecycle> monAnRecycles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-FCU7UJN\\SQLEXPRESS; initial catalog = EF_QLMonAn; integrated security = SSPI;");
        }
    }
}
