using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Owner> Owners { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source = .; initial catalog = ReposPatternDB; integrated security = sspi;");
        }
    }
}
