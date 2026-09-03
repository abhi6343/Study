using BatchProcessingwithJobScheduler.Entities;
using Microsoft.EntityFrameworkCore;

namespace BatchProcessingwithJobScheduler
{
    internal class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configuring the Connection String
            optionsBuilder.UseSqlServer(@"Server=.;Database=OrderDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        // DbSets
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobDetail> JobDetails { get; set; }
    }
}
