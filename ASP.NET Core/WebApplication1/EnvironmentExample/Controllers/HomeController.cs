using Microsoft.AspNetCore.Mvc;

namespace EnvironmentExample.Controllers
{
    public class HomeController : Controller
    {
        readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;            
        }

        [HttpGet]
        [Route("/")]
        //[Route("some-route")]
        public IActionResult Index()
        {
            ViewBag.CurrentEnvironment = _webHostEnvironment.EnvironmentName;
            return View();
        }

        //[HttpGet]
        //[Route("some-route")]
        //public IActionResult Other()
        //{
        //    return View();
        //}
    }
}
