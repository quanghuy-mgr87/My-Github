using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLKhoaHocMVC.Model
{
    class BusinessContext : DbContext
    {
        public DbSet<KhoaHoc> khoaHocs { get; set; }
        public DbSet<NgayHoc> ngayHocs { get; set; }
        public DbSet<HocVien> hocViens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server = DESKTOP-5GPG8CE\SQLEXPRESS; database = QLKhoaHoc; integrated security = SSPI;");
        }
    }
}
