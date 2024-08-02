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
    }
}
