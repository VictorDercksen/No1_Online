using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using No1_Online.Interfaces;
using No1_Online.ViewModels;
using Microsoft.AspNetCore.Components;

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
            loadingScheduleVM = new LoadingScheduleVM();
        }

        public async Task<IActionResult> OnGetAsync(int? id = null)
        {
            loadingScheduleVM = await _loadingScheduleService.GetLoadingSchedule(id);

            if (loadingScheduleVM == null)
            {
                return NotFound();
            }

            

            return Page();
        }

        public EventCallback<LoadingScheduleDetailsViewModel> OnLoadingScheduleSave => EventCallback.Factory.Create<LoadingScheduleDetailsViewModel>(this, async (viewModel) =>
        {
            loadingScheduleVM.LoadingScheduleDetails = viewModel;
            await _loadingScheduleService.UpdateLoadingSchedule(loadingScheduleVM);
        });

        public EventCallback<ClientPaymentInputViewModel> OnClientPaymentSave => EventCallback.Factory.Create<ClientPaymentInputViewModel>(this, async (viewModel) =>
        {
            loadingScheduleVM.ClientPaymentInput = viewModel;
            await _loadingScheduleService.UpdateLoadingSchedule(loadingScheduleVM);
        });

        public EventCallback<TransporterPaymentInputViewModel> OnTransporterPaymentSave => EventCallback.Factory.Create<TransporterPaymentInputViewModel>(this, async (viewModel) =>
        {
            loadingScheduleVM.TransporterPaymentInput = viewModel;
            await _loadingScheduleService.UpdateLoadingSchedule(loadingScheduleVM);
        });

        public EventCallback<InvoicesComponentViewModel> OnInvoiceSave => EventCallback.Factory.Create<InvoicesComponentViewModel>(this, async (viewModel) =>
        {
            loadingScheduleVM.InvoicesComponent = viewModel;
            await _loadingScheduleService.UpdateLoadingSchedule(loadingScheduleVM);
        });

        public EventCallback<NotesComponentViewModel> OnNoteSave => EventCallback.Factory.Create<NotesComponentViewModel>(this, async (viewModel) =>
        {
            loadingScheduleVM.NotesComponent = viewModel;
            await _loadingScheduleService.UpdateLoadingSchedule(loadingScheduleVM);
        });

        public EventCallback<ProductTableViewModel> OnProductTableSave => EventCallback.Factory.Create<ProductTableViewModel>(this, async (viewModel) =>
        {
            loadingScheduleVM.ProductTable = viewModel;
            await _loadingScheduleService.UpdateLoadingSchedule(loadingScheduleVM);
        });
    }
}