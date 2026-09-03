using DesignDBusingCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesignDBusingCodeFirst
{
    public class EFCoreDbContext : DbContext
    {
        //Constructor calling the Base DbContext Class Constructor
        public EFCoreDbContext() : base()
        {
            //Disabling Lazy Loading
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Enable Logging
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            //Enabling Lazy Loading
            //optionsBuilder.UseLazyLoadingProxies();
            //Connection String
            optionsBuilder.UseSqlServer("Server=.;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        // DbSet properties represent the tables in the database. 
        // Each DbSet corresponds to a table, and the type parameter corresponds to the entity class mapped to that table.
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
