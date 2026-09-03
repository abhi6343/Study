using BulkExtensionsvsZExtensionsvsStandardEFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BulkExtensionsvsZExtensionsvsStandardEFCore
{
    internal class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the SQL Server connection string
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-6P5NK25R\SQLSERVER2022DEV;Database=ProductsDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        // DbSet representing the Students table
        public DbSet<Product> Products { get; set; }
    }
}
