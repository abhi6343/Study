using EntityConfigurationFluentAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityConfigurationFluentAPI
{
    internal class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuring the Connection String
            optionsBuilder.UseSqlServer(@"Server=.;Database=OrderDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring Table Names and Schema
            modelBuilder.Entity<Customer>().ToTable("tblCustomer", schema: "Admin");
            // Configuring Primary Key
            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
            // Configuring Composite Primary Keys
            modelBuilder.Entity<OrderItem>().HasKey(oi => new { oi.OrderId, oi.ProductId });
            // Configuring Indexes
            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();
            // Composite Indexes
            modelBuilder.Entity<Customer>().HasIndex(c => new { c.LastName, c.FirstName }).HasDatabaseName("IX_Customer_LastName_FirstName");
            // Filtered Indexes
            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).HasFilter("[Email] IS NOT NULL");
            // Include Columns
            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IncludeProperties(c => new { c.FirstName, c.LastName });
            // Configuring Cascade Delete Behavior for Specific Relationships
            modelBuilder.Entity<OrderItem>().HasOne(oi => oi.Order).WithMany(o => o.OrderItems).HasForeignKey(oi => oi.OrderId).OnDelete(DeleteBehavior.Cascade);
            // Ignoring Entities
            modelBuilder.Ignore<AuditLog>();
            // Configuring Alternate Keys (Unique Constraints)
            modelBuilder.Entity<Customer>().HasAlternateKey(c => c.Email).HasName("AK_Customer_Email");
            // Composite Alternate Keys
            modelBuilder.Entity<Customer>().HasAlternateKey(c => new { c.FirstName, c.LastName, c.DateOfBirth }).HasName("AK_Customer_FullNameDOB");
            // Configuring Owned Entities
            modelBuilder.Entity<Customer>().OwnsOne(c => c.Address);
        }

        // Define DbSets
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
