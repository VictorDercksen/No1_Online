using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using No1_Online.Controllers;
using No1_Online.ViewModels;
using System.Web.WebPages;

namespace No1_Online.Pages
{
    public class IncomeAllVehiclesModel : PageModel
    {
       public ReportsVM reportsVM { get; set; }
        ReportsController reportsController { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostIncomeAllVehiclesAsync(DateTime startDate, DateTime endDate, string transporter)
        {


            ReportsVM viewModel = await reportsController.GetIncomeAllVehicles(startDate, endDate, transporter);
            // Assuming you have a Razor partial view to render this data
            return Partial("_IncomePerVehicleResults", viewModel);
        }
    }
}
