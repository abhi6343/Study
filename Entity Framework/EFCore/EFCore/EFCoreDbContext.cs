using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
// Import the Entity Framework Core namespace to access DbContext and other EF Core functionalities.
namespace EFCore
{
    // EFCoreDbContext class inherits from DbContext, which is the primary class for interacting with the database using EF Core.
    public class EFCoreDbContext//(DbContextOptions<EFCoreDbContext> options)
                                  : DbContext//(options) // The base(options) call passes the options to the base DbContext class constructor.
    {
        // Constructor that accepts DbContextOptions<EFCoreDbContext> as a parameter.
        // The options parameter contains the settings required by EF Core to configure the DbContext,
        // such as the connection string and provider.

        // OnConfiguring is an override method that allows configuring the DbContext options,
        // like setting the database provider and connection string.
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Configure the database provider and connection string.
        //    // UseSqlServer method configures the DbContext to use SQL Server as the database provider.
        //    // The provided connection string specifies the server, database name, and credentials.
        //    // Replace "Server=YourServerName;Database=YourDatabaseName;User Id=YourUsername;Password=YourPassword;"
        //    // with your actual SQL Server details.
        //    optionsBuilder.UseSqlServer("Server=.;Database=YourDatabaseName;User Id=YourUsername;Password=YourPassword;Trusted_Connection=True;TrustServerCertificate=True;");
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Display the generated SQL queries in the Console window
        //    optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        //    // Step 1: Load the Configuration File (appsettings.json).
        //    // The ConfigurationBuilder class is used to construct configuration settings from various sources.
        //    // Here, we add the appsettings.json file to the configuration sources and then build it.
        //    var configBuilder = new ConfigurationBuilder()
        //    .AddJsonFile("appsettings.json") // Specify the configuration file to load.
        //    .Build(); // Build the configuration object, making it ready to retrieve values.

        //    // Step 2: Get the "ConnectionStrings" section from the configuration.
        //    // The GetSection method is used to access a specific section within the configuration file.
        //    // Here, we are accessing the "ConnectionStrings" section which contains our database connection strings.
        //    var configSection = configBuilder.GetSection("ConnectionStrings");

        //    // Step 3: Retrieve the connection string value using its key ("SQLServerConnection").
        //    // The indexer [] is used to access the value corresponding to the "SQLServerConnection" key within the section.
        //    // The null-coalescing operator (??) ensures that if the key is not found, it will return null.
        //    var connectionString = configSection["SQLServerConnection"] ?? null;

        //    // Step 4: Configure the DbContext to use SQL Server with the retrieved connection string.
        //    // The UseSqlServer method is an extension method that configures the context to connect to a SQL Server database.
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        // DbSet<Student> Students represents a table in the database corresponding to the Student entity.
        // EF Core uses DbSet<TEntity> to track changes and execute queries related to the Student entity.
        public DbSet<Student> Students { get; set; }
        // DbSet<Branch> Branches represents a table in the database corresponding to the Branch entity.
        // Similar to the Students DbSet, this property is used by EF Core to track and manage Branch entities.
        public DbSet<Branch> Branches { get; set; }
    }
}
