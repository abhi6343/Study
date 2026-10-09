using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Person>().ToTable("Persons");

            //Seed to Countries
            var countriesJson = File.ReadAllText("countries.json");
            var countries = JsonSerializer.Deserialize<IEnumerable<Country>>(countriesJson);
            foreach (var country in countries ?? [])
            {
                modelBuilder.Entity<Country>().HasData(country);
            }
            //modelBuilder.Entity<Country>().HasData(countries);
            //modelBuilder.Entity<Country>().HasData(new Country() { CountryID = Guid.NewGuid(), CountryName = "Sample"});


            //Seed to Persons
            var personsJson = File.ReadAllText("persons.json");
            var persons = JsonSerializer.Deserialize<IEnumerable<Person>>(personsJson);
            foreach (var person in persons ?? [])
            {
                modelBuilder.Entity<Person>().HasData(person);
            }

            //Fluent API
            modelBuilder.Entity<Person>().Property(p => p.TIN).HasColumnName("TaxIdentificationNumber").HasColumnType("varchar(8)").HasDefaultValue("ABC12345");

            //modelBuilder.Entity<Person>().HasIndex(p => p.TIN).IsUnique();

            //modelBuilder.Entity<Person>().HasCheckConstraint("CHK_TIN", "len([TIN]) = 8");
            modelBuilder.Entity<Person>().HasCheckConstraint("CHK_TIN", "len([TaxIdentificationNumber]) = 8");

            //Table Relations
            //modelBuilder.Entity<Person>(entity => entity.HasOne<Country>(c => c.Country).WithMany(p => p.Persons).HasForeignKey(p => p.CountryID));
        }

        /// <summary>
        /// Executes the GetAllPersons stored procedure and returns the result.
        /// </summary>
        /// <returns>An IQueryable of Person objects.</returns>
        //public IQueryable<Person> sp_GetAllPersons()
        public List<Person> sp_GetAllPersons()
        {
            //return Persons.FromSqlRaw("EXECUTE [dbo].[GetAllPersons]");
            return [.. Persons.FromSqlRaw("EXECUTE [dbo].[GetAllPersons]")];
        }

        public int sp_InsertPerson(Person person)
        {
            //return Database.ExecuteSqlRaw("EXECUTE [dbo].[InsertPerson] @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7",
            //    parameters: new object[]
            //    {
            //        person.PersonID,
            //        person.CountryID,
            //        person.PersonName,
            //        person.Email,
            //        person.Gender,
            //        person.DateOfBirth,
            //        person.Address,
            //        person.ReceiveNewsLetters
            //    }
            //);
            var parameters = new SqlParameter[]
            {
                new("@PersonID", person.PersonID),
                new("@CountryID", person.CountryID),
                new("@PersonName", person.PersonName),
                new("@Email", person.Email),
                new("@Gender", person.Gender),
                new("@DateOfBirth", person.DateOfBirth),
                new("@Address", person.Address),
                new("@ReceiveNewsLetters", person.ReceiveNewsLetters)
            };

            return Database.ExecuteSqlRaw("EXECUTE [dbo].[InsertPerson] @PersonID, @CountryID, @PersonName, @Email, @Gender, @DateOfBirth, @Address, @ReceiveNewsLetters", parameters);
        }
    }
}
