using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using No1_Online.Models;
using No1_Online.ViewModels;
using No1_Online.Interfaces;
using System.Threading.Tasks;

namespace No1_Online.Pages
{
    public class loadingscheduleModel : PageModel
    {

        private readonly ICompanyService _companyService;
        private readonly ILoadingScheduleService _loadingScheduleService;

        [BindProperty]
        public LoadingScheduleVM loadingScheduleVM { get; set; }

        public loadingscheduleModel(ICompanyService companyService, ILoadingScheduleService loadingScheduleService)
        {
            _companyService = companyService;
            _loadingScheduleService = loadingScheduleService;
            loadingScheduleVM = new LoadingScheduleVM();
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id.HasValue)
            {
                loadingScheduleVM = await _loadingScheduleService.GetLoadingSchedule(id);
            }
            else
            {
                loadingScheduleVM = new LoadingScheduleVM();
            }

            return Page();
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        await PopulateViewModelAsync();
        //        return Page();
        //    }

        //    if (loadingScheduleVM.LoadingSchedule.Id == 0)
        //    {
        //        await _loadingScheduleService.CreateLoadingScheduleAsync(loadingScheduleVM.LoadingSchedule);
        //    }
        //    else
        //    {
        //        await _loadingScheduleService.UpdateLoadingScheduleAsync(loadingScheduleVM.LoadingSchedule);
        //    }

        //    return RedirectToPage("./Index");
        //}

        //private async Task PopulateViewModelAsync()
        //{
        //    loadingScheduleVM.Transporters = await _companyService.GetTransportersAsync();
        //    loadingScheduleVM.Marketers = await _companyService.GetMarketersAsync();
        //    loadingScheduleVM.Clients = await _companyService.GetClientsAsync();
        //    loadingScheduleVM.Vehicles = await _loadingScheduleService.GetVehiclesAsync();
        //    loadingScheduleVM.LoadingPoints = await _loadingScheduleService.GetLoadingPointsAsync();
        //}
    }
}