using DisconnectedEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DisconnectedEntities
{
    internal class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //To Display the Generated SQL Statements
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            //Configuring the Connection String
            optionsBuilder.UseSqlServer(@"Server=.;Database=EFCoreDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Student> Students { get; set; }
    }
}
