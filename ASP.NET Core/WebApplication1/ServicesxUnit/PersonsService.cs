using Entities;
using ServiceContractsxUnit;
using ServiceContractsxUnit.DTO;
using ServiceContractsxUnit.Enums;
using ServicesxUnit.Helpers;

namespace ServicesxUnit
{
    public class PersonsService : IPersonsService
    {
        readonly List<Person> _persons;
        readonly ICountriesService _countryService;
        public PersonsService()
        {
            _persons = [];
            _countryService = new CountriesService();
        }
        PersonResponse ConvertPersonToPersonResponse(Person person)
        {
            var personResponse = person.ToPersonResponse();

            personResponse.Country = _countryService.GetCountryByCopuntryID(person.CountryID)?.CountryName;
            return personResponse;
        }

        public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
        {
            //check if PersonAddRequest is not null
            ArgumentNullException.ThrowIfNull(personAddRequest);

            //Validation: PersonName
            //if (string.IsNullOrEmpty(personAddRequest.PersonName))
            //{
            //    throw new ArgumentException("PersonName can't be blank");
            //}

            //Model validations
            ValidationHelper.ModelValidation(personAddRequest);

            //convert personAddRequest into Person type
            var person = personAddRequest.ToPerson();

            //generate PersonID
            person.PersonID = Guid.NewGuid();

            //add person object to persons list
            _persons.Add(person);

            //convert the Person object to PersonResponse type
            return ConvertPersonToPersonResponse(person);
        }

        public List<PersonResponse> GetAllPersons()
        {
            return [.._persons.Select(temp => temp.ToPersonResponse())];
        }

        public PersonResponse? GetPersonByPersonID(Guid? personID)
        {
            if (personID == null)
            {
                return null;
            }

            var person = _persons.FirstOrDefault(temp => temp.PersonID == personID);

            if (person == null)
            {
                return null;
            }

            return person.ToPersonResponse();
        }

        public List<PersonResponse> GetFilteredPersons(string searchBy, string? searchString)
        {
            var allPersons = GetAllPersons();
            var matchingPersons = allPersons;

            if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchString))
            {
                return matchingPersons;
            }

            switch (searchBy)
            {
                case nameof(Person.PersonName):
                    matchingPersons = [..allPersons.Where(temp => string.IsNullOrEmpty(temp.PersonName) || temp.PersonName.Contains(searchString, StringComparison.OrdinalIgnoreCase))];
                    break;

                case nameof(Person.Email):
                    matchingPersons = [.. allPersons.Where(temp => string.IsNullOrEmpty(temp.Email) || temp.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase))];
                    break;

                case nameof(Person.DateOfBirth):
                    matchingPersons = [.. allPersons.Where(temp => temp.DateOfBirth == null || temp.DateOfBirth.Value.ToString("dd MMM yyyy").Contains(searchString, StringComparison.OrdinalIgnoreCase))];
                    break;

                case nameof(Person.Gender):
                    matchingPersons = [.. allPersons.Where(temp => string.IsNullOrEmpty(temp.Gender) || temp.Gender.Contains(searchString, StringComparison.OrdinalIgnoreCase))];
                    break;

                case nameof(Person.Address):
                    matchingPersons = [.. allPersons.Where(temp => string.IsNullOrEmpty(temp.Address) || temp.Address.Contains(searchString, StringComparison.OrdinalIgnoreCase))];
                    break;

                default:
                    matchingPersons = allPersons;
                    break;
            }

            return matchingPersons;
        }

        public List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy))
            {
                return allPersons;
            }

            IEnumerable<PersonResponse> sortedPersons = 
            (sortBy, sortOrder) switch
            {
                (nameof(PersonResponse.PersonName), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase),
                (nameof(PersonResponse.PersonName), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase),

                (nameof(PersonResponse.Email), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Email, StringComparer.OrdinalIgnoreCase),
                (nameof(PersonResponse.Email), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Email, StringComparer.OrdinalIgnoreCase),

                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.DateOfBirth),
                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.DateOfBirth),

                (nameof(PersonResponse.Age), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Age),
                (nameof(PersonResponse.Age), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Age),

                (nameof(PersonResponse.Gender), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Gender, StringComparer.OrdinalIgnoreCase),
                (nameof(PersonResponse.Gender), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Gender, StringComparer.OrdinalIgnoreCase),

                (nameof(PersonResponse.Country), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Country, StringComparer.OrdinalIgnoreCase),
                (nameof(PersonResponse.Country), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Country, StringComparer.OrdinalIgnoreCase),

                (nameof(PersonResponse.Address), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Address, StringComparer.OrdinalIgnoreCase),
                (nameof(PersonResponse.Address), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Address, StringComparer.OrdinalIgnoreCase),

                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.ReceiveNewsLetters),
                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.ReceiveNewsLetters),

                _ => allPersons
            };

            return [..sortedPersons];
        }

        public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            ArgumentNullException.ThrowIfNull(personUpdateRequest);

            //validation
            ValidationHelper.ModelValidation(personUpdateRequest);

            //get matching person object to update
            var matchingPerson = _persons.FirstOrDefault(temp => temp.PersonID == personUpdateRequest.PersonID) ?? throw new ArgumentException("Given person id doesn't exist");

            //update all details
            matchingPerson.PersonName = personUpdateRequest.PersonName;
            matchingPerson.Email = personUpdateRequest.PersonName;
            matchingPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
            matchingPerson.Gender = personUpdateRequest.Gender.ToString();
            matchingPerson.CountryID = personUpdateRequest.CountryID;
            matchingPerson.Address = personUpdateRequest.PersonName;
            matchingPerson.ReceiveNewsLetters = personUpdateRequest.ReceiveNewsLetters;

            return matchingPerson.ToPersonResponse();
        }

        public bool DeletePerson(Guid? personID)
        {
            if (personID == null)
            {
                throw new ArgumentNullException(nameof(personID));
            }

            var person = _persons.FirstOrDefault(temp => temp.PersonID == personID);
            if (person == null)
            {
                return false;
            }

            _persons.RemoveAll(temp => temp.PersonID == personID);
            return true;
        }
    }
}
