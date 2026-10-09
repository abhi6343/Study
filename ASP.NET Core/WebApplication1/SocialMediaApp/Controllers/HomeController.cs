using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.ConfigurationModels;

namespace SocialMediaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this._configuration = configuration;
            this._webHostEnvironment = webHostEnvironment;
        }

        [Route("/")]
        public IActionResult Index()
        {
            var options = new List<SocialMediaLinksOptions>()
            {
                new (){ Name = "Facebook", Url = new ("http://www.facebook.com/microsoft") },
                new (){ Name = "Twitter", Url = new ("http://www.twitter.com/microsoft") },
                new (){ Name = "Youtube", Url = new ("http://www.youtube.com/microsoft") },
            };
            
            if (_webHostEnvironment.IsDevelopment())
            {
                options.Add(new () { Name = "Instagram", Url = new Uri("http://www.instagram.com/microsoft") });
            }

            return View(options);
        }
    }
}
