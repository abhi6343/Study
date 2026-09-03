using Microsoft.AspNetCore.Mvc;
using OrderApp.Models;
using System.Security.Cryptography;

namespace OrderApp.Controllers
{
    public class OderController : Controller
    {
        [HttpGet("/order")]
        public IActionResult Index()
        {
            return Content("This is the order page.");
        }
        [HttpPost("/order")]
        public IActionResult Index([FromForm] Order _)
        {
            List<string> errors = [];
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
            }
            if (errors.Count != 0)
            { 
                string err = errors.Select(x => x).Aggregate((a, b) => a + "\n" + b);
                Response.StatusCode = 400;
                return Content(err);
            }
            return Json(new { OrderNumber = RandomNumberGenerator.GetInt32(99999) + 1 });
        }
        [HttpGet("/")]
        public IActionResult Home()
        {
            return Content("Welcome to the home page!");
        }
    }
}
