using HVIT_EF_QLHocSinh.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLHocSinh
{
    class QLHocSinhDbContext : DbContext
    {
        public DbSet<HocSinh> hocSinhs { get; set; }
        public DbSet<Lop> lops { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-FCU7UJN\\SQLEXPRESS; initial catalog = EF_QLHocSinhDb; integrated security = SSPI;");
        }
    }
}
