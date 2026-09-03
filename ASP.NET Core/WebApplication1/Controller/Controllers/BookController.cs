using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    public class BookController : Microsoft.AspNetCore.Mvc.Controller
    {
        // /Book?id=123&IsLoggedIn=true
        // /Book?id=123&author=steve
        [Route("Book")]
        //[Route("/Book/{Author}")]
        //public IActionResult Book()
        public IActionResult Book(int id, string author)
        {
            //if (Request.Query.ContainsKey("IsLoggedIn"))
            //{
            //    bool isLoggedIn = Convert.ToBoolean(Request.Query["IsLoggedIn"]);
            //    if (!isLoggedIn)
            //    {
            //        //return Unauthorized("You must be logged in to view book details.");
            //        //return new StatusCodeResult(401); // Unauthorized
            //        //return StatusCode(401); // Unauthorized
            //        return StatusCode(StatusCodes.Status401Unauthorized); // Unauthorized
            //    }
            //}

            //if (Request.Query.ContainsKey("id"))
            //{
            //    int id = Convert.ToInt32(Request.Query["id"]);
            //    if (id < 1 || id > 1000)
            //    {
            //        return NotFound();
            //    }
            //    //return Content($"Book ID: {id}");
            //}
            //else
            //{
            //    //Response.StatusCode = 400; // Bad Request
            //    //return Content("No Book ID provided.");
            //    //return new BadRequestResult();
            //    return BadRequest("Invalid Book ID.");
            //}

            //return File("/reena.pdf", "application/pdf");

            //return RedirectToAction("Book", "Store", new { });
            //int id = Convert.ToInt32(Request.Query["id"]);
            bool isLoggedIn = Convert.ToBoolean(Request.Query["IsLoggedIn"]);
            return new LocalRedirectResult($"/Category/Book/{id}/{isLoggedIn}");
            //return new RedirectResult("https://www.google.com");

            //int id = Convert.ToInt32(Request.Query["id"]);
            //var author = Convert.ToString(Request.Query["author"]);
            //return Content($"Book ID is:  {id} Author is: {author}");
        }
    }
}
