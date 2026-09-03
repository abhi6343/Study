using Entities;
using ServiceContractsxUnit;
using ServiceContractsxUnit.DTO;
using ServiceContractsxUnit.Enums;
using ServicesxUnit;
using Xunit.Abstractions;

namespace CRUDTests
{
    public class PersonsServiceTest
    {
        readonly IPersonsService _personService;
        readonly ICountriesService _countryService;
        readonly ITestOutputHelper _testOutputHelper;

        public PersonsServiceTest(ITestOutputHelper testOutputHelper)
        {
            _personService = new PersonsService();
            _countryService = new CountriesService(false);
            _testOutputHelper = testOutputHelper;
        }

        #region AddPerson
        //When we supply null value as PersonAddRequest, it should throw ArgumentNullException
        [Fact]
        public void AddPerson_NullPerson()
        {
            //Arrange
            PersonAddRequest personAddRequest = null;

            //Act
            Assert.Throws<ArgumentNullException>(() =>
            {
                _personService.AddPerson(personAddRequest);
            });
        }

        //When we supply null value as PersonName, it should throw ArgumentException
        [Fact]
        public void AddPerson_PersonNameNull()
        {
            //Arrange
            var personAddRequest = new PersonAddRequest() { PersonName = null };

            //Act
            Assert.Throws<ArgumentException>(() =>
            {
                _personService.AddPerson(personAddRequest);
            });
        }

        //When we supply proper person details, it should insert the person into the persons list and it should return an object of PersonResponse, which includes with the newly generated person id
        [Fact]
        public void AddPerson_ProperPersonDetails()
        {
            //Arrange
            var personAddRequest = new PersonAddRequest()
            {
                PersonName = "Person name...",
                Email = "person@example.com",
                Address = "sample address",
                CountryID = Guid.NewGuid(),
                Gender = ServiceContractsxUnit.Enums.GenderOptions.Male,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                ReceiveNewsLetters = true,
            };

            //Act            
            var person_response_from_add = _personService.AddPerson(personAddRequest);
            var persons_list = _personService.GetAllPersons();

            //Assert
            Assert.True(person_response_from_add.PersonID != Guid.Empty);
            Assert.Contains(person_response_from_add, persons_list);
        }
        #endregion


        #region GetPersonByPersonID
        //If we supply null as PersonID, it should return null as PersonResponse
        [Fact]
        public void GetPersonByPersonID_NullPersonID()
        {
            //Arrange
            Guid? personID = null;

            //Act
            var person_response_from_get = _personService.GetPersonByPersonID(personID);

            //Assert
            Assert.Null(person_response_from_get);
        }

        //If we supply a valid PersonID, it should return the valid personDetails as PersonReponse object
        [Fact]
        public void GetPersonByPersonID_WithPersonID()
        {
            //Arrange
            var country_request = new CountryAddRequest() { CountryName = "Canada" };

            var country_response = _countryService.AddCountry(country_request);

            //Act
            var person_request = new PersonAddRequest()
            {
                PersonName = "person name...",
                Email = "email@Sample.com",
                Address = "address",
                CountryID = country_response.CountryID,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                Gender = ServiceContractsxUnit.Enums.GenderOptions.Male,
                ReceiveNewsLetters = false
            };
            var person_response_from_add = _personService.AddPerson(person_request);

            var person_response_from_get = _personService.GetPersonByPersonID(person_response_from_add.PersonID);

            //Assert
            Assert.Equal(person_response_from_add, person_response_from_get);
        }
        #endregion


        #region GetAllPersons
        // The GetAllPersons should return an empty list by default
        [Fact]
        public void GetAllPersons_EmptyList()
        {
            //Act
            var persons_from_get = _personService.GetAllPersons();

            //Assert
            Assert.Empty(persons_from_get);
        }

        // First, we will add few persons; and then when we call GetAllPersons(), it should rteurn the same persons that were added
        [Fact]
        public void GetAllPersons_AddFewPersons() 
        {
            //Arrange
            var country_request_1 = new CountryAddRequest() { CountryName = "USA" };
            var country_request_2 = new CountryAddRequest() { CountryName = "India" };

            var country_response_1 = _countryService.AddCountry(country_request_1);
            var country_response_2 = _countryService.AddCountry(country_request_2);

            var person_request_1 = new PersonAddRequest() 
            { 
                PersonName = "Smith",
                Email = "smith@example.com",
                Gender = ServiceContractsxUnit.Enums.GenderOptions.Male,
                Address = "address of smith",
                CountryID = country_response_1.CountryID,
                DateOfBirth = DateTime.Parse("2002-05-06"),
                ReceiveNewsLetters = true,
            };

            var person_request_2 = new PersonAddRequest() 
            {
                PersonName = "Mary",
                Email = "mary@example.com",
                Gender = ServiceContractsxUnit.Enums.GenderOptions.Female,
                Address = "address of mary",
                CountryID = country_response_2.CountryID,
                DateOfBirth = DateTime.Parse("2000-02-02"),
                ReceiveNewsLetters = false,
            };

            var person_request_3 = new PersonAddRequest() 
            {
                PersonName = "Rahman",
                Email = "rahman@example.com",
                Gender = ServiceContractsxUnit.Enums.GenderOptions.Female,
                Address = "address of rahman",
                CountryID = country_response_2.CountryID,
                DateOfBirth = DateTime.Parse("1999-03-03"),
                ReceiveNewsLetters = true,
            };


            var person_requests = new List<PersonAddRequest>() { person_request_1, person_request_2, person_request_3 };
            var person_response_list_from_add = new List<PersonResponse>();
            foreach (var person_request in person_requests)
            {
                var person_response = _personService.AddPerson(person_request);
                person_response_list_from_add.Add(person_response);
            }

            //Print person_response_list_from_add
            _testOutputHelper.WriteLine("Expected:");
            foreach(var person_response_from_add in person_response_list_from_add)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }

            //Act
            var persons_list_from_get = _personService.GetAllPersons();

            //Print persons_list_from_get
            _testOutputHelper.WriteLine("Actual:");
            foreach (var person_response_from_get in persons_list_from_get)
            {
                _testOutputHelper.WriteLine(person_response_from_get.ToString());
            }

            //Assert
            foreach (var person_response_from_add in person_response_list_from_add)
            {
                Assert.Contains(person_response_from_add, persons_list_from_get);
            }
        }
        #endregion


        #region GetFilteredPersons
        // If the search text is empty and search by is "PersonName", it should return all persons
        [Fact]
        public void GetFilteredPersons_EmptySearchText()
        {
            //Arrange
            var country_request_1 = new CountryAddRequest() { CountryName = "USA" };
            var country_request_2 = new CountryAddRequest() { CountryName = "India" };

            var country_response_1 = _countryService.AddCountry(country_request_1);
            var country_response_2 = _countryService.AddCountry(country_request_2);

            var person_request_1 = new PersonAddRequest()
            {
                PersonName = "Smith",
                Email = "smith@example.com",
                Gender = ServiceContractsxUnit.Enums.GenderOptions.Male,
                Address = "address of smith",
                CountryID = country_response_1.CountryID,
                DateOfBirth = DateTime.Parse("2002-05-06"),
                ReceiveNewsLetters = true,
            };

            var person_request_2 = new PersonAddRequest()
            {
                PersonName = "Mary",
                Email = "mary@example.com",
                Gender = ServiceContractsxUnit.Enums.GenderOptions.Female,
                Address = "address of mary",
                CountryID = country_response_2.CountryID,
                DateOfBirth = DateTime.Parse("2000-02-02"),
                ReceiveNewsLetters = false,
            };

            var person_request_3 = new PersonAddRequest()
            {
                PersonName = "Rahman",
                Email = "rahman@example.com",
                Gender = ServiceContractsxUnit.Enums.GenderOptions.Female,
                Address = "address of rahman",
                CountryID = country_response_2.CountryID,
                DateOfBirth = DateTime.Parse("1999-03-03"),
                ReceiveNewsLetters = true,
            };


            var person_requests = new List<PersonAddRequest>() { person_request_1, person_request_2, person_request_3 };
            var person_response_list_from_add = new List<PersonResponse>();
            foreach (var person_request in person_requests)
            {
                var person_response = _personService.AddPerson(person_request);
                person_response_list_from_add.Add(person_response);
            }

            //Print person_response_list_from_add
            _testOutputHelper.WriteLine("Expected:");
            foreach (var person_response_from_add in person_response_list_from_add)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }

            //Act
            var persons_list_from_search = _personService.GetFilteredPersons(nameof(Person.PersonName), string.Empty);

            //Print persons_list_from_search
            _testOutputHelper.WriteLine("Actual:");
            foreach (var person_response_from_get in persons_list_from_search)
            {
                _testOutputHelper.WriteLine(person_response_from_get.ToString());
            }

            //Assert
            foreach (var person_response_from_add in person_response_list_from_add)
            {
                Assert.Contains(person_response_from_add, persons_list_from_search);
            }
        }

        // First we will add a few persons; and then we will search based on PersonName with some search string. It should return the matching persons
        [Fact]
        public void GetFilteredPersons_SearchByPersonName()
        {
            //Arrange
            var country_request_1 = new CountryAddRequest() { CountryName = "USA" };
            var country_request_2 = new CountryAddRequest() { CountryName = "India" };

            var country_response_1 = _countryService.AddCountry(country_request_1);
            var country_response_2 = _countryService.AddCountry(country_request_2);

            var person_request_1 = new PersonAddRequest()
            {
                PersonName = "Smith",
                Email = "smith@example.com",
                Gender = ServiceContractsxUnit.Enums.GenderOptions.Male,
                Address = "address of smith",
                CountryID = country_response_1.CountryID,
                DateOfBirth = DateTime.Parse("2002-05-06"),
                ReceiveNewsLetters = true,
            };

            var person_request_2 = new PersonAddRequest()
            {
                PersonName = "Mary",
                Email = "mary@example.com",
                Gender = ServiceContractsxUnit.Enums.GenderOptions.Female,
                Address = "address of mary",
                CountryID = country_response_2.CountryID,
                DateOfBirth = DateTime.Parse("2000-02-02"),
                ReceiveNewsLetters = false,
            };

            var person_request_3 = new PersonAddRequest()
            {
                PersonName = "Rahman",
                Email = "rahman@example.com",
                Gender = ServiceContractsxUnit.Enums.GenderOptions.Female,
                Address = "address of rahman",
                CountryID = country_response_2.CountryID,
                DateOfBirth = DateTime.Parse("1999-03-03"),
                ReceiveNewsLetters = true,
            };


            var person_requests = new List<PersonAddRequest>() { person_request_1, person_request_2, person_request_3 };
            var person_response_list_from_add = new List<PersonResponse>();
            foreach (var person_request in person_requests)
            {
                var person_response = _personService.AddPerson(person_request);
                person_response_list_from_add.Add(person_response);
            }

            //Print person_response_list_from_add
            _testOutputHelper.WriteLine("All Persons:");
            foreach (var person_response_from_add in person_response_list_from_add)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }

            //Act
            var persons_list_from_search = _personService.GetFilteredPersons(nameof(Person.PersonName), "ma");

            //Print persons_list_from_search
            _testOutputHelper.WriteLine($"Matched Persons with SearchBy {nameof(Person.PersonName)} and searchString ma:");
            foreach (var person_response_from_get in persons_list_from_search)
            {
                _testOutputHelper.WriteLine(person_response_from_get.ToString());
            }

            //Assert
            foreach (var person_response_from_add in person_response_list_from_add)
            {
                if (person_response_from_add.PersonName != null)
                {
                    if (person_response_from_add.PersonName.Contains("ma", StringComparison.OrdinalIgnoreCase))
                    {
                        Assert.Contains(person_response_from_add, persons_list_from_search);
                    }
                }
            }
        }
        #endregion


        #region GetSortedPersons
        //When we sort based on PersonName in DESC, it should return persons list in descending on PersonName
        [Fact]
        public void GetSortedPersons_()
        {
            //Arrange
            var country_request_1 = new CountryAddRequest() { CountryName = "USA" };
            var country_request_2 = new CountryAddRequest() { CountryName = "India" };

            var country_response_1 = _countryService.AddCountry(country_request_1);
            var country_response_2 = _countryService.AddCountry(country_request_2);

            var person_request_1 = new PersonAddRequest()
            {
                PersonName = "Smith",
                Email = "smith@example.com",
                Gender = ServiceContractsxUnit.Enums.GenderOptions.Male,
                Address = "address of smith",
                CountryID = country_response_1.CountryID,
                DateOfBirth = DateTime.Parse("2002-05-06"),
                ReceiveNewsLetters = true,
            };

            var person_request_2 = new PersonAddRequest()
            {
                PersonName = "Mary",
                Email = "mary@example.com",
                Gender = ServiceContractsxUnit.Enums.GenderOptions.Female,
                Address = "address of mary",
                CountryID = country_response_2.CountryID,
                DateOfBirth = DateTime.Parse("2000-02-02"),
                ReceiveNewsLetters = false,
            };

            var person_request_3 = new PersonAddRequest()
            {
                PersonName = "Rahman",
                Email = "rahman@example.com",
                Gender = ServiceContractsxUnit.Enums.GenderOptions.Female,
                Address = "address of rahman",
                CountryID = country_response_2.CountryID,
                DateOfBirth = DateTime.Parse("1999-03-03"),
                ReceiveNewsLetters = true,
            };


            var person_requests = new List<PersonAddRequest>() { person_request_1, person_request_2, person_request_3 };
            var person_response_list_from_add = new List<PersonResponse>();
            foreach (var person_request in person_requests)
            {
                var person_response = _personService.AddPerson(person_request);
                person_response_list_from_add.Add(person_response);
            }

            //Print person_response_list_from_add
            _testOutputHelper.WriteLine("All Persons:");
            foreach (var person_response_from_add in person_response_list_from_add)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }
            var allPersons = _personService.GetAllPersons();

            //Act
            var persons_list_from_sort = _personService.GetSortedPersons(allPersons, nameof(Person.PersonName), SortOrderOptions.DESC);

            //Print persons_list_from_search
            _testOutputHelper.WriteLine($"Sorted Persons with SortBy {nameof(Person.PersonName)} in DESC order:");
            foreach (var person_response_from_get in persons_list_from_sort)
            {
                _testOutputHelper.WriteLine(person_response_from_get.ToString());
            }
            person_response_list_from_add = [..person_response_list_from_add.OrderByDescending(temp => temp.PersonName)];
            
            //Assert
            for (var i = 0; i < person_response_list_from_add.Count; i++)
            {
                Assert.Equal(person_response_list_from_add[i], persons_list_from_sort[i]);
            }
        }
        #endregion


        #region UpdatePerson
        //When we supply null as PersonUpdateRequest, it should throw ArgumentNullException
        [Fact]
        public void UpdatePerson_NullPerson()
        {
            //Arrange
            PersonUpdateRequest? person_update_request = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _personService.UpdatePerson(person_update_request);
            });
        }

        //When we supply invalid Person ID, it should throw ArgumentException
        [Fact]
        public void UpdatePerson_InValiPersonID()
        {
            //Arrange
            var person_update_request = new PersonUpdateRequest() { PersonID = Guid.NewGuid() };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _personService.UpdatePerson(person_update_request);
            });
        }

        //When Person Name is null, it should throw ArgumentException
        [Fact]
        public void UpdatePerson_PersonNameIsNull()
        {
            //Arrange
            var country_add_request = new CountryAddRequest() { CountryName = "UK" };
            var country_response_from_add = _countryService.AddCountry(country_add_request);

            var person_add_request = new PersonAddRequest()
            {
                PersonName = "John",
                Email ="john@example.com",
                CountryID = country_response_from_add.CountryID,
                Address = "address...",
            };
            var person_response_from_add = _personService.AddPerson(person_add_request);

            var person_update_request = person_response_from_add.ToPersonUpdaterequest();
            person_update_request.PersonName = null;


            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _personService.UpdatePerson(person_update_request);
            });
        }

        //First, add a new person and try to update the person name and email
        [Fact]
        public void UpdatePerson_PersonFullDetailsUpdation()
        {
            //Arrange
            var country_add_request = new CountryAddRequest() { CountryName = "UK" };
            var country_response_from_add = _countryService.AddCountry(country_add_request);

            var person_add_request = new PersonAddRequest()
            {
                PersonName = "John",
                CountryID = country_response_from_add.CountryID,
                Address = "Abc road",
                DateOfBirth = DateTime.Parse("2000-01-01"),
                Email = "abc@example.com",
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = true,
            };
            var person_response_from_add = _personService.AddPerson(person_add_request);

            var person_update_request = person_response_from_add.ToPersonUpdaterequest();
            person_update_request.PersonName = "William";
            person_update_request.Email = "william@example.com";


            //Act
            var person_response_from_update = _personService.UpdatePerson(person_update_request);
            var person_response_from_get = _personService.GetPersonByPersonID(person_response_from_update.PersonID);

            //Assert
            Assert.Equal(person_response_from_get, person_response_from_update);
        }
        #endregion


        #region DeletePerson
        //If we supply a valid PersonID, it should return true
        [Fact]
        public void DeletePerson_ValidPersonID()
        {
            //Arrange
            var country_add_request = new CountryAddRequest() { CountryName = "USA" };
            var country_response_from_add = _countryService.AddCountry(country_add_request);

            var person_add_request = new PersonAddRequest()
            {
                PersonName = "Jones",
                Email = "jones@example.com",
                Address = "address",
                CountryID = country_response_from_add.CountryID,
                DateOfBirth = Convert.ToDateTime("2010-01-01"),
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = true,
            };

            var person_response_from_add = _personService.AddPerson(person_add_request);

            //Act
            bool isDeleted = _personService.DeletePerson(person_response_from_add.PersonID);

            //Assert
            Assert.True(isDeleted);
        }

        //If we supply an invalid PersonID, it should return false
        [Fact]
        public void DeletePerson_InvalidPersonID()
        {
            //Arrange            

            //Act
            bool isDeleted = _personService.DeletePerson(Guid.NewGuid());

            //Assert
            Assert.False(isDeleted);
        }
        #endregion
    }
}
