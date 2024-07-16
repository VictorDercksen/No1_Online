using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using No1_Online.Classes.Reports;
using No1_Online.Interfaces;
using No1_Online.Services;
using No1_Online.ViewModels;
using System;
using System.Threading.Tasks;

namespace No1_Online.Pages
{
    public class IncomeAllVehiclesModel : PageModel
    {
        [BindProperty]
        public ReportsVM reportsVM { get; set; }

        private readonly IReportService _reportService;
        private readonly GoogleCloudStorageService _googleCloudStorageService;
        public IncomeAllVehiclesModel(IReportService reportService)
        {
            _reportService = reportService;
            reportsVM = new ReportsVM();
            string bucketName = "no1-online-reports-bucket";
            _googleCloudStorageService = new GoogleCloudStorageService(bucketName);
        }

        public async Task<IActionResult> OnGetAsync(DateTime startDate, DateTime endDate, string transporter)
        {
            TempData["StartDate"] = startDate;
            TempData["EndDate"] = endDate;
            TempData["Transporter"] = transporter;

            reportsVM = await _reportService.GetIncomeAllVehiclesAsync(startDate, endDate, transporter);
            return Page();
        }

        public async Task<IActionResult> OnPostReport()
        {
            var startDate = (DateTime)TempData["StartDate"];
            var endDate = (DateTime)TempData["EndDate"];
            var transporter = TempData["Transporter"].ToString();

            reportsVM = await _reportService.GetIncomeAllVehiclesAsync(startDate, endDate, transporter);

            try
            {
                if (reportsVM == null || !reportsVM.loadingSchedules.Any())
                {
                    return NotFound("No data found for the given criteria.");
                }

                var document = new IncomeAllVehiclesDocument(reportsVM, "Transporter: " + reportsVM.loadingSchedules[0].CompanyTrans.Name);

                // Generate the PDF as a byte array
                byte[] pdfBytes = document.GeneratePdf();
                string reportName = $"IncomeAllVehiclesReport_{reportsVM.loadingSchedules[0].CompanyTrans.Name}.pdf";
                string reportUrl = await _googleCloudStorageService.UploadReportAsync(reportName, pdfBytes);
                return new FileContentResult(pdfBytes, "application/pdf")
                {
                    FileDownloadName = "IncomeAllVehiclesReport_" + reportsVM.loadingSchedules[0].CompanyTrans.Name + ".pdf"
                };
            }
            catch (Exception ex)
            {
                // Log the exception and return an error response
                return StatusCode(500, new { message = "An error occurred while generating the report.", error = ex.Message });
            }
        }
    }
}
