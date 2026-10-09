// <copyright file="CityViewComponent.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WeatherApp.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using WeatherApp.Models;

    /// <summary>
    /// 
    /// </summary>
    public class CityViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CityWeather city)
        {
            this.ViewBag.CityCssClass = GetCssClassByFahrenheit(city.TemperatureFahrenheit);

            return this.View(city);
        }

        private static string GetCssClassByFahrenheit(int temperatureFahrenheit) => temperatureFahrenheit switch
        {
            (< 44) => "blue-back",
            (>= 44) and(< 75) => "green-back",
            (>= 75) => "orange-back"
        };
    }
}
