using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationDemo.Controllers
{
    public class HomeController : Controller
    {
        //readonly IConfiguration _configuration;
        readonly WeatherAPIOptions _options;
        public HomeController(IOptions<WeatherAPIOptions> weatherApiOptions)
        {
            _options = weatherApiOptions.Value;
        }

        [Route("/")]
        public IActionResult Index()
        {
            //ViewBag.MyKey =_configuration["mykey"];
            //ViewBag.MyIntKey =_configuration.GetValue("x", 50);
            //ViewBag.MyAPIKey =_configuration.GetValue("MyAPIKey", "the default key");

            //ViewBag.ClientID = _configuration["weatherapi:Clientid"];
            //ViewBag.ClientSecret = _configuration.GetValue("weatherapi:ClientSecret", "the default secret");

            //ViewBag.ClientID = _configuration.GetSection("weatherapi")["Clientid"];            
            //ViewBag.ClientSecret = _configuration.GetSection("weatherapi")["ClientSecret"];

            //IConfigurationSection weatherapiSection = _configuration.GetSection("weatherapi");
            //ViewBag.ClientID = weatherapiSection["Clientid"];
            //ViewBag.ClientSecret = weatherapiSection["ClientSecret"];

            //Bind loads configuration object values into a new options object
            //var options = _configuration.GetSection("weatherapi").Get<WeatherAPIOptions>();

            //var options = new WeatherAPIOptions();
            //Bind loads configuration object values into existing options object
            //_configuration.GetSection("weatherapi").Bind(options);
            //ViewBag.ClientID = options.ClientID;
            //ViewBag.ClientSecret = options.ClientSecret;

            ViewBag.ClientID = _options.ClientID;
            ViewBag.ClientSecret = _options.ClientSecret;

            return View();
        }
    }
}
