using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ThucHanh.Entities
{
    public class AppDbContext : DbContext
    {
        public DbSet<BillDetail> billDetails { get; set; }
        public DbSet<Bill> bills { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductType> productTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-PLLSRC9\SQLEXPRESS; initial catalog = ProductDB; integrated security = SSPI");
        }
    }
}
