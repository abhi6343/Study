using ServiceContractsxUnit;
using ServiceContractsxUnit.DTO;
using ServicesxUnit;
using System.Net.WebSockets;

namespace CRUDTests
{
    public class CountriesServiceTest
    {
        readonly ICountriesService _countriesService;
        public CountriesServiceTest()
        {
            _countriesService = new CountriesService(false);
        }

        #region AddCountry
        //When CountryAddRequest is null, it should throw ArgumentNullException
        [Fact]
        public void AddCountry_NullCountry()
        {
            //Arrange
            CountryAddRequest? request = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _countriesService.AddCountry(request);
            }); 
        }

        //When the CountryName is null, it should throw ArgumentException
        [Fact]
        public void AddCountry_CountryNameIsNull()
        {
            //Arrange
            CountryAddRequest? request = new() { CountryName = null };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countriesService.AddCountry(request);
            });
        }

        //When the Contryname is duplicate, it should throw ArgumentException
        [Fact]
        public void AddCountry_DuplicateCountryName()
        {
            //Arrange
            CountryAddRequest? request1 = new() { CountryName = "USA" };
            CountryAddRequest? request2 = new() { CountryName = "USA" };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countriesService.AddCountry(request1);
                _countriesService.AddCountry(request2);
            });
        }

        //When you supply proper country name, it should insert (add) the country to the existing list of countries
        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            //Arrange
            CountryAddRequest? request = new() { CountryName = "Japan" };
            
            //Act
            var response = _countriesService.AddCountry(request);
            var countries_from_GetAllCountries = _countriesService.GetAllCountries();

            //Assert
            Assert.True(response.CountryID != Guid.Empty);
            Assert.Contains(response, countries_from_GetAllCountries);
        }
        #endregion


        #region GetAllCountries
        //The list of countries should be empty by default (before adding any countries)
        [Fact]
        public void GetAllCountries_EmptyList()
        {
            //Acts
            var actual_country_response_list = _countriesService.GetAllCountries();

            //Assert
            Assert.Empty(actual_country_response_list);
        }

        //
        [Fact]
        public void GetAllCountryDetails_AddFewcountries()
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
                country_list_from_add_country.Add(_countriesService.AddCountry(country_request));
            }

            var actualCountryResponseList = _countriesService.GetAllCountries();

            //Read each element from country_list_from_add_country
            foreach(var expected_country in country_list_from_add_country)
            {
                Assert.Contains(expected_country, actualCountryResponseList);
            }
        }
        #endregion


        #region GetCountryByCopuntryID
        //If we supply null as CountryID, it should return null as CountryResponse
        [Fact]
        public void GetCountryByCopuntryID_NullCountryID()
        {
            //Arrange
            Guid? countryID = null;

            //Act
            var country_reponse_from_get_method = _countriesService.GetCountryByCopuntryID(countryID);

            //Assert
            Assert.Null(country_reponse_from_get_method);
        }

        //If we supply a valid countryID, it should treturn the matching country details as CountryResponse object
        [Fact]
        public void GetCountryByCopuntryID_validCountryID()
        {
            //Arrange
            var country_add_request = new CountryAddRequest() { CountryName = "China" };
            var country_respnse_from_add = _countriesService.AddCountry(country_add_request);

            //Act
            var country_response_from_get = _countriesService.GetCountryByCopuntryID(country_respnse_from_add.CountryID);

            //Assert
            Assert.Equal(country_respnse_from_add, country_response_from_get);
        }
        #endregion
    }
}
