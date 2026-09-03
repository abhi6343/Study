using Microsoft.EntityFrameworkCore;
using PropertyConfigurationFluentAPI.Entities;

namespace PropertyConfigurationFluentAPI
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
            // Configuring Column Names
            modelBuilder.Entity<Customer>().Property(c => c.FirstName).HasColumnName("First_Name");
            // Configuring Data Types
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(10, 2)");
            // Configuring Default Values
            modelBuilder.Entity<Order>().Property(o => o.Status).HasDefaultValue(OrderStatus.Pending);
            // Setting Default Values Using SQL Functions
            modelBuilder.Entity<Order>().Property(o => o.OrderDate).HasDefaultValueSql("GETUTCDATE()");
            // Configuring Required Properties
            modelBuilder.Entity<Customer>().Property(c => c.Email).IsRequired();
            // Configuring Nullable Properties
            modelBuilder.Entity<Product>().Property(p => p.Description).IsRequired(false);
            // Configuring Maximum Length
            modelBuilder.Entity<Customer>().Property(c => c.FirstName).HasMaxLength(100);
            // Configuring Precision and Scale
            modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(10, 2);
            // Configuring Computed Columns
            modelBuilder.Entity<OrderItem>().Property(oi => oi.TotalPrice).HasComputedColumnSql("[Quantity] * [UnitPrice]");
            // Configuring Value Conversions
            modelBuilder.Entity<Order>().Property(o => o.Status).HasConversion<string>();
            // Configuring Concurrency Tokens
            modelBuilder.Entity<Order>().Property(o => o.RowVersion).IsRowVersion();
            // Alternative Concurrency Tokens
            modelBuilder.Entity<Order>().Property(o => o.LastModified).IsConcurrencyToken();
            // Configuring Shadow Properties
            modelBuilder.Entity<Product>().Property<DateTime>("CreatedDate").HasDefaultValueSql("GETDATE()");
            // Configuring Value Generation (Identity)
            modelBuilder.Entity<Customer>().Property(c => c.Id).ValueGeneratedOnAdd();
            // Ignoring Properties
            modelBuilder.Entity<Product>().Ignore(p => p.FullDescription);
        }
        // Define DbSets
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
