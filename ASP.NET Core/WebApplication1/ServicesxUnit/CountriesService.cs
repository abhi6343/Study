using Entities;
using Microsoft.Extensions.DependencyInjection;
using ServiceContractsxUnit;
using ServiceContractsxUnit.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using RepositoryContracts;

namespace ServicesxUnit
{
    public class CountriesService : ICountriesService
    {
        readonly List<Country> _countries;
        //readonly PersonsDbContext _db;
        //readonly ApplicationDbContext _db;
        readonly ICountriesRepository _countriesRepository;
        //[ActivatorUtilitiesConstructor]
        //public CountriesService(PersonsDbContext personsDbContext)
        //{
        //    _db = personsDbContext;
        //}
        //public CountriesService(ApplicationDbContext applicationDbContext)
        //{
        //    _db = applicationDbContext;
        //}
        public CountriesService(ICountriesRepository countriesRepository)
        {
            _countriesRepository = countriesRepository;
        }
        //public CountriesService(bool initialize = true)
        //{
        //    _countries = [];
        //    if (initialize)
        //    {
        //        //47F7853F-85A4-4C32-A2EC-DEA7E0E30C94
        //        //BADD5A24-E691-4B86-A56A-43583D37FC4B
        //        //ACA7FED4-04CF-48F7-8A1D-044F618E06E4
        //        //60ED85A5-73BB-4838-A5F0-ECE7AC373DDD
        //        //C4B876D6-72C4-4FC6-A7B9-46F38ABF10DC
        //        _countries.Add(new Country() { CountryID = Guid.Parse("47F7853F-85A4-4C32-A2EC-DEA7E0E30C94"), CountryName = "USA" });
        //        _countries.Add(new Country() { CountryID = Guid.Parse("BADD5A24-E691-4B86-A56A-43583D37FC4B"), CountryName = "Canada" });
        //        _countries.Add(new Country() { CountryID = Guid.Parse("ACA7FED4-04CF-48F7-8A1D-044F618E06E4"), CountryName = "UK" });
        //        _countries.Add(new Country() { CountryID = Guid.Parse("60ED85A5-73BB-4838-A5F0-ECE7AC373DDD"), CountryName = "India" });
        //        _countries.Add(new Country() { CountryID = Guid.Parse("C4B876D6-72C4-4FC6-A7B9-46F38ABF10DC"), CountryName = "Australia" });
        //    }
        //}

        //public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        public async Task<CountryResponse> AddCountry(CountryAddRequest? countryAddRequest)
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
            //if (_countries.Any(temp => temp.CountryName == countryAddRequest.CountryName))
            //{
            //    throw new ArgumentException("Given country name already exists");
            //}
            //if (await _db.Countries.AnyAsync(temp => temp.CountryName == countryAddRequest.CountryName))
            //{
            //    throw new ArgumentException("Given country name already exists");
            //}
            if (await _countriesRepository.GetCountryByCountryName(countryAddRequest.CountryName) != null)
            {
                throw new ArgumentException("Given country name already exists");
            }

            //Convert objet from CountryAddRequest to Country type
            var country = countryAddRequest.ToCountry();


            //Generate CountryID
            country.CountryID = Guid.NewGuid();
            //Add country object into _countries
            //_countries.Add(country);
            //_db.Countries.Add(country);
            //_db.SaveChanges();
            //await _db.SaveChangesAsync();
            await _countriesRepository.AddCountry(country);

            return country.ToCountryResponse();
        }

        //public List<CountryResponse> GetAllCountries()
        public async Task<List<CountryResponse>> GetAllCountries()
        {
            //return [.. _countries.Select(country => country.ToCountryResponse())];
            //return [.. _db.Countries.Select(country => country.ToCountryResponse())];
            //return await _db.Countries.Select(country => country.ToCountryResponse()).ToListAsync();
            return [.. (await _countriesRepository.GetAllCountries()).Select(country => country.ToCountryResponse())];
        }

        //public CountryResponse? GetCountryByCopuntryID(Guid? countryID)
        public async Task<CountryResponse?> GetCountryByCopuntryID(Guid? countryID)
        {
            if (countryID == null)
            {
                return null;
            }

            //var country_response_from_list = _countries.FirstOrDefault(temp => temp.CountryID == countryID);
            //var country_response_from_list = _db.Countries.FirstOrDefault(temp => temp.CountryID == countryID);
            //var country_response_from_list = await _db.Countries.FirstOrDefaultAsync(temp => temp.CountryID == countryID);
            var country_response_from_list = await _countriesRepository.GetCountryByCountryID(countryID.Value);
            if (country_response_from_list == null)
            {
                return null;
            }

            return country_response_from_list.ToCountryResponse();
        }

        public async Task<int> UploadCountriesFromExcelFile(IFormFile formfile)
        {
            var memoryStream = new MemoryStream();
            await formfile.CopyToAsync(memoryStream);
            using var excelPackage = new ExcelPackage(memoryStream);
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Countries"];

            int rowCount = worksheet.Dimension.Rows;
            int countriesAdded = 0;

            for (int i = 2; i <= rowCount; i++)
            {
                var countryName = worksheet.Cells[i, 1].Value?.ToString();
                if (string.IsNullOrEmpty(countryName))
                    continue;
                //if (await _db.Countries.AnyAsync(c => c.CountryName == countryName))
                //    continue;
                if (await _countriesRepository.GetCountryByCountryName(countryName) != null)
                    continue;

                var country = new Country
                {
                    CountryName = countryName
                };

                //_db.Countries.Add(country);
                //await _db.SaveChangesAsync();
                await _countriesRepository.AddCountry(country);

                countriesAdded++;
            }

            return countriesAdded;
        }
    }
}
