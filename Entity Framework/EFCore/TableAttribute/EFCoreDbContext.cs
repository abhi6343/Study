using Microsoft.EntityFrameworkCore;

namespace TableAttributeDemo
{
    internal class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=EFCoreDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Student> Students { get; set; }
    }
}
