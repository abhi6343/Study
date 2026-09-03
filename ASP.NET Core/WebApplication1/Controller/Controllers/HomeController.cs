using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    //[Controller]
    //public class Home
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Route("Home")]
        [Route("/")]
        //public string Index()
        //{
        //    return "Welcome from ASP.NET Core application!";
        //}
        public ContentResult Index()
        {
            return Content("<h1>Welcome from ASP.NET Core application!</h1>", "text/html");
            //return new ContentResult() {Content = "<h1>Welcome from ASP.NET Core application!</h1>", ContentType = "text/html"};
        }

        [Route("About")]
        public string About()
        {
            return "This is the About page.";
        }

        [Route("Contact")]
        [Route("Contact-Us")]
        public string Contact()
        {
            return "This is the Contact page.";
        }

        [Route("/Products/{id:int:min(1000):max(9999)}")]
        public string Products()
        {
            return "This is the Products page.";
        }

        //[Route("Employee/John")]
        //public ContentResult Employee()
        //{            
        //    return Content("{\"name\" : \"John\"}", "application/json");
        //}

        [Route("Employee/John")]
        public JsonResult Employee()
        {
            var emp = new Models.Employee
            {
                ID = 101,
                Name = "John",
                Salary = 10000,
                Age = 28
            };

            return Json(emp); //new JsonResult(emp);
        }
    }
}
