using Microsoft.AspNetCore.Mvc;
using ServiceContractsxUnit;

namespace CRUDExample.Controllers
{
    [Route("[controller]")]
    public class CountriesController : Controller
    {
        readonly ICountriesService _countriesService;
        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [Route("UploadFromExcel")]
        public IActionResult UploadFromExcel()
        {
            return View();
        }

        [Route("UploadFromExcel")]
        [HttpPost]
        public async Task<IActionResult> UploadFromExcel(IFormFile excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                //ModelState.AddModelError("excelFile", "Please select a valid Excel file.");
                ViewBag.ErrorMessage = "Please select a valid Excel file.";
                return View();
            }

            if (!Path.GetExtension(excelFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                ViewBag.ErrorMessage = "Please select a valid Excel file with .xlsx extension."; // "UnSupported file. 'xlsx file is expected";
                return View();
            }

            try
            {
                int countriesAdded = await _countriesService.UploadCountriesFromExcelFile(excelFile);
                ViewBag.Message = $"{countriesAdded} countries added successfully.";
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError(string.Empty, $"An error occurred while uploading: {ex.Message}");
                ViewBag.ErrorMessage = $"An error occurred while uploading: {ex.Message}";
            }
            return View();
        }
    }
}
