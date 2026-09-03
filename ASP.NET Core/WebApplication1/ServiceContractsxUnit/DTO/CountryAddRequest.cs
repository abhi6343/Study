using Entities;

namespace ServiceContractsxUnit.DTO
{
    /// <summary>
    /// DTO class for adding a new country
    /// </summary>
    public class CountryAddRequest
    {
        public string? CountryName { get; set; }

        public Country ToCountry()
        {
            return new() { CountryName = CountryName };
        }
    }
}
