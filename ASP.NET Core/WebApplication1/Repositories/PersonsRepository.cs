using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using System.Linq.Expressions;

namespace Repositories
{
    public class PersonsRepository : IPersonsRepository
    {
        readonly ApplicationDbContext _db;
        readonly ILogger<PersonsRepository> _logger;
        public PersonsRepository(ApplicationDbContext db, ILogger<PersonsRepository> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public async Task<Person> AddPerson(Person person)
        {
            this._db.Persons.Add(person);
            await this._db.SaveChangesAsync();
            return person;
        }

        public async Task<bool> DeletePersonByPersonID(Guid personID)
        {
            this._db.Persons.RemoveRange(this._db.Persons.Where(temp => temp.PersonID == personID));
            int rowsDeleted = await this._db.SaveChangesAsync();
            return rowsDeleted > 0;
        }

        public Task<List<Person>> GetAllPersons()
        {
            this._logger.LogInformation("GetAllPersons of PersonsRepository");
            return this._db.Persons.Include(nameof(Person.Country)).ToListAsync();
        }

        public async Task<List<Person>> GetFilteredPersons(Expression<Func<Person, bool>> predicate)
        {
            this._logger.LogInformation("GetFilteredPersons of PersonsRepository");
            return await this._db.Persons.Include(nameof(Person.Country)).Where(predicate).ToListAsync();
        }

        public async Task<Person?> GetPersonByPersonID(Guid personID)
        {
            return await _db.Persons.Include(nameof(Person.Country)).FirstOrDefaultAsync(temp => temp.PersonID == personID);
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            var matchingPerson = await _db.Persons.FirstOrDefaultAsync(temp => temp.PersonID == person.PersonID);

            if (matchingPerson == null)
            {
                return person;
            }

            matchingPerson.PersonName = person.PersonName;
            matchingPerson.Email = person.Email;
            matchingPerson.DateOfBirth = person.DateOfBirth;
            matchingPerson.Gender = person.Gender;
            matchingPerson.CountryID = person.CountryID;
            matchingPerson.Address = person.Address;
            matchingPerson.ReceiveNewsLetters = person.ReceiveNewsLetters;

            int countUpdated = await _db.SaveChangesAsync();

            return matchingPerson;
        }
    }
}
