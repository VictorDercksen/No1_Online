using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using No1_Online.Interfaces;
using No1_Online.Models;
using No1_Online.ViewModels;

namespace No1_Online.Pages
{
    public class loadingscheduleModel : PageModel
    {
        [BindProperty]
        public LoadingScheduleVM loadingScheduleVM { get; set; }

        private readonly ILoadingScheduleService _loadingScheduleService;

        public loadingscheduleModel(ILoadingScheduleService loadingScheduleService)
        {
            _loadingScheduleService = loadingScheduleService;
        }

        public async Task<IActionResult> OnGetAsync(int? id = null)
        {
            if (id == null)
            {
                // Return an empty LoadingSchedule for a new schedule
                loadingScheduleVM = new LoadingScheduleVM();
                return Page();
            }

            loadingScheduleVM = await _loadingScheduleService.GetLoadingSchedule(id);
            if (loadingScheduleVM == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}