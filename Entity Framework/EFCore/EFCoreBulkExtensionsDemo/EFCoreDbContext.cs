using EFCoreBulkExtensionsDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBulkExtensionsDemo
{
    internal class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the SQL Server connection string
            optionsBuilder.UseSqlServer(@"Server=.;Database=EFCoreDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        // DbSet representing the Students table
        public DbSet<Student> Students { get; set; }
    }
}
