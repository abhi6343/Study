using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    public class StoreController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Route("/Category/Book/{id}/{IsLoggedIn}")]
        public IActionResult Book()
        {
            if (Request.Query.ContainsKey("IsLoggedIn"))
            {
                bool isLoggedIn = Convert.ToBoolean(Request.Query["IsLoggedIn"]);
                if (!isLoggedIn)
                {
                    //return Unauthorized("You must be logged in to view book details.");
                    //return new StatusCodeResult(401); // Unauthorized
                    //return StatusCode(401); // Unauthorized
                    return StatusCode(StatusCodes.Status401Unauthorized); // Unauthorized
                }
            }

            if (Request.Query.ContainsKey("id"))
            {
                int id = Convert.ToInt32(Request.Query["id"]);
                if (id < 1 || id > 1000)
                {
                    return NotFound();
                }
                //return Content($"Book ID: {id}");
            }
            else
            {
                //Response.StatusCode = 400; // Bad Request
                //return Content("No Book ID provided.");
                //return new BadRequestResult();
                return BadRequest("Invalid Book ID.");
            }
            return Content($"User logged in: {Request.Query["IsLoggedIn"]}, Id: {Request.Query["id"]}", "text/plain");
        }
    }
}
