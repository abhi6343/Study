using Microsoft.EntityFrameworkCore;
using ZExtensionsEFCoreDemo.Entities;

namespace ZExtensionsEFCoreDemo
{
    internal class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Optional: Log generated SQL to the console for debugging
            // Uncomment the following line to enable SQL logging
            // optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            // Configure the SQL Server connection string
            optionsBuilder.UseSqlServer(@"Server=.;Database=EFCoreDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        // DbSet representing the Students table
        public DbSet<Student> Students { get; set; }
    }
}
