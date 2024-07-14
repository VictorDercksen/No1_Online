using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using No1_Online.Models;
using No1_Online.ViewModels;

namespace No1_Online.Pages
{
    public class loadingscheduleModel : PageModel
    {
        public LoadingScheduleVM loadingScheduleVM;

        
        public void OnGet()
        {
            loadingScheduleVM = new LoadingScheduleVM();
        }
    }
}
