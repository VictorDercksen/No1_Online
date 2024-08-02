using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using No1_Online.Services;

namespace No1_Online.Pages
{
    public class ReportsManagementModel : PageModel
    {
        private readonly GoogleCloudStorageService _googleCloudStorageService;

        public List<string>? Reports { get; set; }

        public ReportsManagementModel(GoogleCloudStorageService googleCloudStorageService)
        {
            _googleCloudStorageService = googleCloudStorageService;
        }

        public async Task OnGetAsync()
        {
            Reports = await _googleCloudStorageService.ListReportsAsync();
        }

        public async Task<IActionResult> OnGetDownloadReportAsync(string reportName)
        {
            var reportData = await _googleCloudStorageService.DownloadReportAsync(reportName);
            if (reportData == null)
            {
                return NotFound();
            }
            return File(reportData, "application/pdf", reportName);
        }
    }
}
