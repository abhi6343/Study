using GlobalConfigurationFluentAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GlobalConfigurationFluentAPI
{
    internal class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuring the Connection String
            optionsBuilder.UseSqlServer(@"Server=.;Database=GlobalConfigurationFluentAPIDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply global configurations
            // Set the default schema for the database to "Admin"
            modelBuilder.HasDefaultSchema("Admin");

            // Iterate through all entity types in the model
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Select all properties of type decimal or nullable decimal
                var decimalProperties = entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));
                foreach (var property in decimalProperties)
                {
                    // Set the precision to 18 (total number of digits)
                    property.SetPrecision(18);
                    // Set the scale to 3 (digits after the decimal point)
                    property.SetScale(3);
                }
            }


            // Iterate through all entity types in the model
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Select all properties of type string
                var stringProperties = entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(string));
                foreach (var property in stringProperties)
                {
                    // Apply the default max length only if not already configured
                    if (property.GetMaxLength() == null)
                    {
                        property.SetMaxLength(200); // Set default max length to 200 characters
                    }
                }
            }


            // Iterate through all entity types in the model
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Get all properties of type Enum (enumerations)
                var enumProperties = entityType.GetProperties()
                    .Where(p => p.ClrType.IsEnum);
                foreach (var property in enumProperties)
                {
                    // Get the CLR type of the enum
                    var enumType = Nullable.GetUnderlyingType(property.ClrType) ?? property.ClrType;
                    // Dynamically Create a generic EnumToStringConverter for the specific enum type
                    var converterType = typeof(EnumToStringConverter<>).MakeGenericType(enumType);
                    // Apply the converter to the property if the instance was created successfully
                    if (Activator.CreateInstance(converterType) is ValueConverter converter)
                    {
                        property.SetValueConverter(converter);
                    }
                }
            }



            // Iterate through all foreign keys in the model
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                // Set the delete behavior to "Restrict" to prevent cascading deletes
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }


            // Iterate through all entity types in the model
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Select all properties of type string
                var stringProperties = entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(string));
                foreach (var property in stringProperties)
                {
                    // Apply non-Unicode configuration only if not already set
                    if (property.IsUnicode() != false)
                    {
                        property.SetIsUnicode(false); // Maps to varchar
                    }
                }
            }



            // Iterate through all entity types in the model
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Check if the entity implements the ITimestampedEntity interface
                if (typeof(ITimestampedEntity).IsAssignableFrom(entityType.ClrType))
                {
                    // Configure the CreatedAt property
                    modelBuilder.Entity(entityType.ClrType)
                        //.Property(e => ((ITimestampedEntity)e).CreatedAt)
                        .Property<DateTime>("CreatedAt")
                        .HasDefaultValueSql("GETUTCDATE()")      // SQL Server function for current UTC date/time
                        .ValueGeneratedOnAdd()                   // Set value when the entity is added
                        .IsRequired();                           // Optionally, make the property non-nullable

                    // Configure the UpdatedAt property
                    modelBuilder.Entity(entityType.ClrType)
                        //.Property(e => ((ITimestampedEntity)e).UpdatedAt)
                        .Property<DateTime>("UpdatedAt")
                        .HasDefaultValueSql("GETUTCDATE()")      // SQL Server function for current UTC date/time
                        .ValueGeneratedOnAddOrUpdate()           // Set value on add and update
                        .IsRequired();                           // Optionally, make the property non-nullable

                }
            }
        }

        // Define DbSets
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
