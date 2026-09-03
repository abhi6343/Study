using DefaultConvention.Entities;
using Microsoft.EntityFrameworkCore;

namespace DefaultConvention
{
    internal class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connection String
            optionsBuilder.UseSqlServer("Server=.;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        // DbSet properties represent the tables in the database. 
        // Each DbSet corresponds to a table, and the type parameter corresponds to the entity class mapped to that table.
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
