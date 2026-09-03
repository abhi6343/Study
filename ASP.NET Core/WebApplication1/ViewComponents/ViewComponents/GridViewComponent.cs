using Microsoft.AspNetCore.Mvc;
using ViewComponents.Models;

namespace ViewComponents.ViewComponents
{
    //[ViewComponent]
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PersonGridModel grid)
        {
            //PersonGridModel personGridModel = new()
            //{
            //    GridTitle = "Persons List",
            //    Persons =
            //    [
            //        new() {Name = "John", JobTitle = "Manager"},
            //        new() {Name = "Jones", JobTitle = "Asst. Manager"},
            //        new() {Name = "William", JobTitle = "Clerk"},
            //    ]
            //};

            //ViewBag.Grid = personGridModel;
            return View("Sample", grid); // invoked a partial view Views/Shared/Components/Grid/Sample.cshtml
            //return View("Sample", personGridModel); // invoked a partial view Views/Shared/Components/Grid/Sample.cshtml
            //return View(); // invoked a partial view Views/Shared/Components/Grid/Default.cshtml
        }
    }
}
