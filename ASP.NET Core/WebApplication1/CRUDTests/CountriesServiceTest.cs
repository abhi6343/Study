using Entities;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using ServiceContractsxUnit;
using ServiceContractsxUnit.DTO;
using ServicesxUnit;

namespace CRUDTests
{
    public class CountriesServiceTest
    {
        readonly ICountriesService _countriesService;
        public CountriesServiceTest()
        {
            //_countriesService = new CountriesService(false);
            //_countriesService = new CountriesService(new PersonsDbContext( new DbContextOptionsBuilder<PersonsDbContext>().Options));
            //var dbContext = new PersonsDbContext(new DbContextOptionsBuilder<PersonsDbContext>().Options);
            //_countriesService = new CountriesService(dbContext);

            var countriesInitialData = new List<Country>() { };
            var dbContextMock = new DbContextMock<ApplicationDbContext>(new DbContextOptionsBuilder<ApplicationDbContext>().Options);
            var dbContext = dbContextMock.Object;
            dbContextMock.CreateDbSetMock(temp => temp.Countries, countriesInitialData);
            //_countriesService = new CountriesService(dbContext);
            _countriesService = new CountriesService(null);
        }

        #region AddCountry
        //When CountryAddRequest is null, it should throw ArgumentNullException
        [Fact]
        //public void AddCountry_NullCountry()
        public async Task AddCountry_NullCountry()
        {
            //Arrange
            CountryAddRequest? request = null;

            //Assert
            //Assert.Throws<ArgumentNullException>(() =>
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                //Act
                //_countriesService.AddCountry(request);
                await _countriesService.AddCountry(request);
            }); 
        }

        //When the CountryName is null, it should throw ArgumentException
        [Fact]
       // public void AddCountry_CountryNameIsNull()
        public async Task AddCountry_CountryNameIsNull()
        {
            //Arrange
            CountryAddRequest? request = new() { CountryName = null };

            //Assert
            //Assert.Throws<ArgumentException>(() =>
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                //_countriesService.AddCountry(request);
                await _countriesService.AddCountry(request);
            });
        }

        //When the Contryname is duplicate, it should throw ArgumentException
        [Fact]
        //public void AddCountry_DuplicateCountryName()
        public async Task AddCountry_DuplicateCountryName()
        {
            //Arrange
            CountryAddRequest? request1 = new() { CountryName = "USA" };
            CountryAddRequest? request2 = new() { CountryName = "USA" };

            //Assert
            //Assert.Throws<ArgumentException>(() =>
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                //_countriesService.AddCountry(request1);
                //_countriesService.AddCountry(request2);
                await _countriesService.AddCountry(request1);
                await _countriesService.AddCountry(request2);
            });
        }

        //When you supply proper country name, it should insert (add) the country to the existing list of countries
        [Fact]
        //public void AddCountry_ProperCountryDetails()
        public async Task AddCountry_ProperCountryDetails()
        {
            //Arrange
            CountryAddRequest? request = new() { CountryName = "Japan" };
            
            //Act
            //var response = _countriesService.AddCountry(request);
            //var countries_from_GetAllCountries = _countriesService.GetAllCountries();
            var response = await _countriesService.AddCountry(request);
            var countries_from_GetAllCountries = await _countriesService.GetAllCountries();

            //Assert
            Assert.True(response.CountryID != Guid.Empty);
            Assert.Contains(response, countries_from_GetAllCountries);
        }
        #endregion


        #region GetAllCountries
        //The list of countries should be empty by default (before adding any countries)
        [Fact]
        //public void GetAllCountries_EmptyList()
        public async Task GetAllCountries_EmptyList()
        {
            //Acts
            var actual_country_response_list = await _countriesService.GetAllCountries();

            //Assert
            Assert.Empty(actual_country_response_list);
        }

        //
        [Fact]
        //public void GetAllCountryDetails_AddFewcountries()
        public async Task GetAllCountryDetails_AddFewcountries()
        {
            //Arrange
            var country_request_list = new List<CountryAddRequest>
            {
                new() { CountryName  = "USA" },
                new() { CountryName  = "UK" },
            };

            //Act
            var country_list_from_add_country = new List<CountryResponse>();
            foreach (var country_request in country_request_list)
            {
                //country_list_from_add_country.Add(_countriesService.AddCountry(country_request));
                country_list_from_add_country.Add(await _countriesService.AddCountry(country_request));
            }

            //var actualCountryResponseList = _countriesService.GetAllCountries();
            var actualCountryResponseList = await _countriesService.GetAllCountries();

            //Read each element from country_list_from_add_country
            foreach (var expected_country in country_list_from_add_country)
            {
                Assert.Contains(expected_country, actualCountryResponseList);
            }
        }
        #endregion


        #region GetCountryByCopuntryID
        //If we supply null as CountryID, it should return null as CountryResponse
        [Fact]
        //public void GetCountryByCopuntryID_NullCountryID()
        public async Task GetCountryByCopuntryID_NullCountryID()
        {
            //Arrange
            Guid? countryID = null;

            //Act
            var country_reponse_from_get_method = await _countriesService.GetCountryByCopuntryID(countryID);

            //Assert
            Assert.Null(country_reponse_from_get_method);
        }

        //If we supply a valid countryID, it should treturn the matching country details as CountryResponse object
        [Fact]
        //public void GetCountryByCopuntryID_validCountryID()
        public async Task GetCountryByCopuntryID_validCountryID()
        {
            //Arrange
            var country_add_request = new CountryAddRequest() { CountryName = "China" };
            var country_respnse_from_add = await _countriesService.AddCountry(country_add_request);

            //Act
            var country_response_from_get = await _countriesService.GetCountryByCopuntryID(country_respnse_from_add.CountryID);

            //Assert
            Assert.Equal(country_respnse_from_add, country_response_from_get);
        }
        #endregion
    }
}
