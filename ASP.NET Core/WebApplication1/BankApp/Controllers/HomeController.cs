using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    //[Controller]
    public class HomeController : Controller
    {
        readonly dynamic bankAccount = new { accountNumber = "1001", accountHoldername = "Example Name", currentBalance = 5000 };
        [Route("/")]
        [Route("Home")]
        public IActionResult Index()
        {
            return new ContentResult() { Content = "Welcome to the Best Bank" };
        }

        [Route("About")]
        public IActionResult About()
        {
            return new ContentResult() { Content = "This is the About page of the Best Bank" };
        }

        [Route("Contact")]
        [Route("Contact-us")]
        public IActionResult Contact()
        {
            return new ContentResult() { Content = "This is the Contact page of the Best Bank" };
        }

        [HttpGet("Account-Details")]
        public IActionResult AccountDetails()
        {
            return new JsonResult(bankAccount);
        }

        [HttpGet("Account-Statement")]
        public IActionResult AccountStatement()
        {
            return new VirtualFileResult("OD338191161608675100.pdf", "application/pdf");
        }

        [HttpGet("get-current-balance/{accountNumber:int}")]
        public IActionResult GetCurrentBalance(string accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber))
            {
                return new BadRequestObjectResult("Account Number should be supplied");
            }
            if(accountNumber != "1001")
            {
                return new BadRequestObjectResult("Account Number should be 1001");
            }
            return new ContentResult() { Content = $"Current balance for account {accountNumber}: {((dynamic)bankAccount).currentBalance}" };
        }
        [Route("a")]
        public IActionResult A()
        {
            return new LocalRedirectResult("Contact", permanent: true);
        }
    }
}
