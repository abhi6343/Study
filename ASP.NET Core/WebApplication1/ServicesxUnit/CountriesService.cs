using Entities;
using ServiceContractsxUnit;
using ServiceContractsxUnit.DTO;

namespace ServicesxUnit
{
    public class CountriesService : ICountriesService
    {
        readonly List<Country> _countries;
        public CountriesService(bool initialize = true)
        {
            _countries = [];
            if (initialize)
            {
                //47F7853F-85A4-4C32-A2EC-DEA7E0E30C94
                //BADD5A24-E691-4B86-A56A-43583D37FC4B
                //ACA7FED4-04CF-48F7-8A1D-044F618E06E4
                //60ED85A5-73BB-4838-A5F0-ECE7AC373DDD
                //C4B876D6-72C4-4FC6-A7B9-46F38ABF10DC
                _countries.Add(new Country() { CountryID = Guid.Parse("47F7853F-85A4-4C32-A2EC-DEA7E0E30C94"), CountryName = "USA" });
                _countries.Add(new Country() { CountryID = Guid.Parse("BADD5A24-E691-4B86-A56A-43583D37FC4B"), CountryName = "Canada" });
                _countries.Add(new Country() { CountryID = Guid.Parse("ACA7FED4-04CF-48F7-8A1D-044F618E06E4"), CountryName = "UK" });
                _countries.Add(new Country() { CountryID = Guid.Parse("60ED85A5-73BB-4838-A5F0-ECE7AC373DDD"), CountryName = "India" });
                _countries.Add(new Country() { CountryID = Guid.Parse("C4B876D6-72C4-4FC6-A7B9-46F38ABF10DC"), CountryName = "Australia" });
            }
        }

        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            //Validation: countryAddRequest parameter can't be null
            //if (countryAddRequest == null) 
            //{ 
            //    throw new ArgumentNullException(nameof(countryAddRequest));
            //}
            ArgumentNullException.ThrowIfNull(countryAddRequest);

            //Validation: CountryName can't be null
            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            //Validation: CountryName can't be duplicate
            if (_countries.Any(temp => temp.CountryName == countryAddRequest.CountryName))
            {
                throw new ArgumentException("Given country name already exists");
            }

            //Convert objet from CountryAddRequest to Country type
            var country = countryAddRequest.ToCountry();


            //Generate CountryID
            country.CountryID = Guid.NewGuid();
            //Add country object into _countries
            _countries.Add(country);

            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
            return [.. _countries.Select(country => country.ToCountryResponse())];
        }

        public CountryResponse? GetCountryByCopuntryID(Guid? countryID)
        {
            if (countryID == null)
            {
                return null;
            }

            var country_response_from_list = _countries.FirstOrDefault(temp => temp.CountryID == countryID);
            if (country_response_from_list == null)
            {
                return null;
            }

            return country_response_from_list.ToCountryResponse();
        }
    }
}
