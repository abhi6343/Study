using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    public class FileController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Route("File/Download-File")]
        public VirtualFileResult Index()
        {
            return new VirtualFileResult("/reena.pdf", "application/pdf");
        }

        [Route("File/Download-File2")]
        public PhysicalFileResult FileDownload()
        {
            return PhysicalFile("D:\\Study\\ASP.NET Core\\WebApplication1\\Controller\\wwwroot\\Samples\\reena.pdf", "application/pdf");
        }

        [Route("File/Download-File3")]
        public FileContentResult FileDownload2()
        {
            // Fully-qualify System.IO.File so it doesn't resolve to the controller's File(...) method
            byte[] bytes = System.IO.File.ReadAllBytes(@"D:\Study\ASP.NET Core\WebApplication1\Controller\wwwroot\Samples\reena.pdf");
            return File(bytes, "application/pdf");
        }
    }
}
