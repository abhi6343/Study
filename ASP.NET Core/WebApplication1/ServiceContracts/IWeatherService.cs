namespace ServiceContracts
{
    using System.Collections.Generic;
    using ServiceContracts.DTO;

    /// <summary>
    /// 
    /// </summary>
    public interface IWeatherService
    {
        /// <summary>
        /// Returns a list of CityWeather objects that contains weather details of cities
        /// </summary>
        /// <returns></returns>
        List<CityWeather> GetWeatherDetails();

        /// <summary>
        /// Returns an object of CityWeather based on the given city code
        /// </summary>
        /// <param name="CityCode"></param>
        /// <returns></returns>
        CityWeather? GetWeatherByCityCode(string CityCode);
    }
}
