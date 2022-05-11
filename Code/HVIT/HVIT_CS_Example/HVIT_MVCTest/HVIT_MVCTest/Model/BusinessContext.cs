using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVCTest.Model
{
    class BusinessContext : DbContext
    {
        public DbSet<DuAn> duAns { get; set; }
        public DbSet<NhanVien> nhanViens { get; set; }
        public DbSet<PhanCong> phanCongs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server = DESKTOP-8DJEGCK\SQLEXPRESS; database = TestMVC; integrated security = SSPI;");
        }
    }
}
