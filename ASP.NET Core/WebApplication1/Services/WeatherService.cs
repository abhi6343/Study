// <copyright file="WeatherService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Services
{
    using ServiceContracts;
    using ServiceContracts.DTO;

    /// <summary>
    /// 
    /// </summary>
    public class WeatherService : IWeatherService
    {
        private readonly List<CityWeather> cities =
        [
            new () { CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 8:00"),  TemperatureFahrenheit = 33 },
            new () { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = DateTime.Parse("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
            new () { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"),  TemperatureFahrenheit = 82},
        ];

        /// <inheritdoc/>
        public CityWeather? GetWeatherByCityCode(string cityCode)
        {
            if (string.IsNullOrEmpty(cityCode))
            {
                return null;
            }

            return this.cities.FirstOrDefault(c => c.CityName == cityCode);
        }

        /// <inheritdoc/>
        public List<CityWeather> GetWeatherDetails()
        {
            return this.cities;
        }
    }
}
