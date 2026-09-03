using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        List<CityWeather> Cities =
        [
            new() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 8:00"),  TemperatureFahrenheit = 33 },
            new() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = DateTime.Parse("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
            new() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"),  TemperatureFahrenheit = 82},
        ];

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Title = "Weather App";
            ViewBag.Cities = Cities;
            return View(Cities);
        }

        [Route("weather/{cityName}")]
        public IActionResult City(string cityName)
        {
            var city = Cities.FirstOrDefault(c => c.CityName == cityName);
            return View(city);
        }
    }
}
