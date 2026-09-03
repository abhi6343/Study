using AsynchronousProgramming.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsynchronousProgramming
{
    internal class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuring the Connection String
            optionsBuilder.UseSqlServer(@"Server=.;Database=ProductDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Product> Products { get; set; }
    }
}
