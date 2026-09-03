using InversePropertyAttributeDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace InversePropertyAttributeDemo
{
    internal class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=InversePropertyAttributeDemoDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
