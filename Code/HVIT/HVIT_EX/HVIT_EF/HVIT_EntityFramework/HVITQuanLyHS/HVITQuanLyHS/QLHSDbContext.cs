using HVITQuanLyHS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HVITQuanLyHS
{
    public class QLHSDbContext : DbContext
    {
        public DbSet<HocSinh> HocSinh { get; set; }
        public DbSet<Lop> Lop { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = ADMIN\\SQLEXPRESS; initial catalog = HVITHocSinhDB; integrated security = sspi;");
        }
    }
}
