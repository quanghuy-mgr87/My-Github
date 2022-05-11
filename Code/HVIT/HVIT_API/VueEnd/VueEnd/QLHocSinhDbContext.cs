using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueEnd.Entities;

namespace VueEnd
{
    public class QLHocSinhDbContext : DbContext
    {
        public DbSet<HocSinh> HocSinhs { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LoaiKhoaHoc> LoaiKhoaHocs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = .; initial catalog = QLHocSinhDb; integrated security = SSPI");
        }
    }
}
