namespace DefaultConvention
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new EFCoreDbContext();
            // Ensure the database is created. This will create the database and tables based on the DbContext and entity classes.
            context.Database.EnsureCreated();
            Console.WriteLine("Database created successfully.");
        }
    }
}