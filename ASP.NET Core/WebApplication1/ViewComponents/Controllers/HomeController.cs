using Microsoft.AspNetCore.Mvc;
using ViewComponents.Models;

namespace ViewComponents.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("about")]
        public IActionResult About()
        {
            return View();
        }
        [Route("friends-list")]
        public IActionResult LoadFriendsList()
        {
            PersonGridModel personGridModel = new()
            {
                GridTitle = "Persons",
                Persons =
                [
                    new() {Name = "John", JobTitle = "Manager" },
                    new() {Name = "Jones", JobTitle = "Asst. Manager" },
                    new() {Name = "William", JobTitle = "Clerk" }
                ]
            };
            return ViewComponent("Grid", new { grid = personGridModel });
        }
    }
}
