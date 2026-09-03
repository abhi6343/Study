using Microsoft.AspNetCore.Mvc;
using ViewsDemo.Models;

namespace ViewsDemo.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "ASP.NET Core MVC";
            List<Person> people =
            [
                new() { Id = 1, Name = "John Doe", DateOfBirth = new DateTime(1990, 1, 1), Gender = Gender.Male },
                new() { Id = 2, Name = "Joe Smith", DateOfBirth = new DateTime(1990, 1, 1), Gender = Gender.Male },
                new() { Id = 3, Name = "Scott Trump", DateOfBirth = new DateTime(1990, 1, 1), Gender = Gender.Male },
                new() { Id = 4, Name = "Theresa May", DateOfBirth = new DateTime(1990, 1, 1), Gender = Gender.Female }
            ];

            //ViewData["people"] = people;
            ViewBag.People = people;

            //return View("abc"); // Views/Home/abc.cshtml is the default view for this action, but you can specify a different view name if needed.
            return View("Index", people); // This will return the default view for the action, which is Views/Home/Index.cshtml in this case.
            //return new ViewResult
            //{
            //    ViewName = "abc"
            //};
        }

        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if (name == null)
            {
                return Content("Name parameter is missing.");
            }
            List<Person> people =
            [
                new() { Id = 1, Name = "John Doe", DateOfBirth = new DateTime(1990, 1, 1), Gender = Gender.Male },
                new() { Id = 2, Name = "Joe Smith", DateOfBirth = new DateTime(1990, 1, 1), Gender = Gender.Male },
                new() { Id = 3, Name = "Scott Trump", DateOfBirth = new DateTime(1990, 1, 1), Gender = Gender.Male },
                new() { Id = 4, Name = "Theresa May", DateOfBirth = new DateTime(1990, 1, 1), Gender = Gender.Female }
            ];

            var matchingPerson = people.Where(temp => temp.Name == name).FirstOrDefault();
            return View(matchingPerson);
        }

        [Route("person-with-product")]
        public IActionResult PersonWithProduct()
        {
            var person = new Person() { Name="Sara", Gender = Gender.Female, DateOfBirth = new DateTime(2004,7,1) };
            var product = new Product() { ProductId = 1, ProductName = "Air Conditioner" };
            var personAndProductWrapperModel = new PersonAndProductWrapperModel() { PersonData = person, ProductData = product };
            return View(personAndProductWrapperModel);
        }

        [Route("home/all-products")]
        public IActionResult All()
        {
            return View();
            //Views/Products/All.cshtml
            //Views/Shared/All.cshtml
        }
    }
}
