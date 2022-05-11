using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<HocVien> HocViens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\SQLEXPRESS; initial catalog = IELTsDB; integrated security = sspi;");
        }
    }
}
