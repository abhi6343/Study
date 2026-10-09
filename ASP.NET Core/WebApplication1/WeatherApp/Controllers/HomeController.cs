// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WeatherApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ServiceContracts;


    /// <summary>
    /// ff.
    /// </summary>
    public class HomeController : Controller
    {
        //private readonly List<CityWeather> cities =
        //[
        //    new () { CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 8:00"),  TemperatureFahrenheit = 33 },
        //    new () { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = DateTime.Parse("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
        //    new () { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"),  TemperatureFahrenheit = 82},
        //];

        private readonly IWeatherService _weatherService;
        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            var cities = this._weatherService.GetWeatherDetails();
            this.ViewBag.Title = "Weather App";
            this.ViewBag.Cities = cities;
            return this.View(cities);
        }

        [Route("weather/{cityCode}")]
        public IActionResult City(string cityCode)
        {
            if (string.IsNullOrEmpty(cityCode))
            {
                return this.View();
            }

            var city = this._weatherService.GetWeatherByCityCode(cityCode);

            // return View(city);
            //return PartialView("_CityPartialView", city);
            return this.View(city);
        }
    }
}
