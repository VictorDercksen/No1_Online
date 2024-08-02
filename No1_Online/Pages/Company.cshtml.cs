using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using No1_Online.Interfaces;
using No1_Online.Models;

namespace No1_Online.Pages
{
    public class CompanyModel : PageModel
    {
        [BindProperty]
        public Company Company { get; set; }
        [BindProperty]
        public List<Contact> Contacts { get; set; }

        private readonly ICompanyService _companyService;

        public CompanyModel(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<IActionResult> OnGetAsync(string company = null)
        {
            if (string.IsNullOrEmpty(company))
            {
                // Return an empty Company and Contacts list for a new company
                Company = new Company();
                Contacts = new List<Contact>();
                return Page();
            }

            TempData["company"] = company;

            Company = await _companyService.SearchCompany(company);
            if (Company == null)
            {
                return NotFound();
            }

            Contacts = await _companyService.SearchContacts(Company);

            return Page();
        }
    }
}