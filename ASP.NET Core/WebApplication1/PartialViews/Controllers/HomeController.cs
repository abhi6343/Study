using Microsoft.AspNetCore.Mvc;
using PartialViews.Models;

namespace PartialViews.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            //ViewData["ListTitle"] = "Cities";
            //ViewData["ListItems"] = new List<string>()
            //{
            //    "London", "Paris", "New York", "New Mumbai", "Rome"
            //};
            return View();
        }
        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("programming-languages")]
        public IActionResult ProgrammingLanguages()
        {
            ListModel listModel = new()
            {
                ListTitle = "Programming Languages",
                ListItems =
                [
                    "Python", "C#", "Go"
                ]
            };
            return PartialView("_ListPartialView", listModel);
        }
    }
}
