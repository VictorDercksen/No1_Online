using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using No1_Online.ViewModels;

namespace No1_Online.Pages
{
    public class CompanyModel : PageModel
    {
        CompanyVM companyVM;
        public void OnGet()
        {
            companyVM = new CompanyVM();
        }
    }
}
