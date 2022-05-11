using HVIT_EF_QLNguyenLieu.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HVIT_EF_QLNguyenLieu
{
    class QLNguyenLieuDbContext : DbContext
    {
        public DbSet<ChiTietPhieuThu> ChiTietPhieuThus { get; set; }
        public DbSet<LoaiNguyenLieu> LoaiNguyenLieus { get; set; }
        public DbSet<NguyenLieu> NguyenLieus { get; set; }
        public DbSet<PhieuThu> PhieuThus { get; set; }
        public DbSet<RecycleBin> RecycleBins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-FCU7UJN\\SQLEXPRESS; initial catalog = EF_QLNguyenLieu; integrated security = SSPI;");
        }
    }
}
