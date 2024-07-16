using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Globalization;
using No1_Online.ViewModels;

namespace No1_Online.Controllers
{
    public class CsvController : Controller
    {
        public CsvController()
        {
            
        }

        [HttpPost]
        public IActionResult Upload(IFormFile csvFile)
        {
            if (csvFile == null || csvFile.Length == 0)
            {
                // Handle invalid file
                return RedirectToAction("");
            }

            var records = new List<CsvVM>();

            // Read the content of the CSV file
            using (var reader = new StreamReader(csvFile.OpenReadStream()))
            {
                // Use CsvHelper to parse the CSV content
                using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    records = csv.GetRecords<CsvVM>().ToList();
                }
            }

            // Display the parsed data using Bootstrap in the view
            return PartialView("UploadSuccess", records);
        }

    }
}
