using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using No1_Online.Data;
using No1_Online.Models;

using No1_Online.ViewModels;
using System.Security.Claims;

namespace No1_Online.Controllers
{
    public class CompanyController : Controller
    {
        private readonly AppDbContext _context;
        
        
        public CompanyController(AppDbContext context)
        {
            this._context = context;
           
          
        }

        [HttpGet]
        public async Task<IActionResult> SearchCompany(string searchBox)
        {
            if (string.IsNullOrEmpty(searchBox))
            {
                return PartialView("Company", new CompanyVM()); // Return the partial view with an empty ViewModel
            }

            var company = await _context.Companies
                .Include(c => c.Address)
                .Include(c => c.Note)
                .FirstOrDefaultAsync(c => c.Name.Contains(searchBox));

            if (company == null)
            {
                return NotFound(); // Or handle the case where the company is not found
            }

            var viewModel = new CompanyVM(company);

            // Retrieve contacts with matching CompanyId and add them to the ViewModel
            viewModel.contacts = await _context.Contacts
                .Where(c => c.CompanyId == company.Id)
                .ToListAsync();

            return PartialView("Company", viewModel); // Return the partial view with the populated ViewModel
        }


        [HttpGet]
        public  IActionResult AutoSearchCompany(string term) 
        {
            var companies = _context.Companies
                .Where(c => EF.Functions.Like(c.Name, $"%{term}%"))
                .ToList();

            return Json(companies.Select(c => c.Name));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyVM companyVm)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(companyVm.company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Company));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Address1", companyVm.company.AddressId);
            ViewData["NoteId"] = new SelectList(_context.Notes, "Id", "Description", companyVm.company.NoteId);
            return RedirectToAction(nameof(Company));
        }
        public async Task<IActionResult> Company()
        {
            
          
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var viewModel = new CompanyVM();
                viewModel.company.ProfileId = userId;
                
                viewModel.company.Note.Revision = DateTime.Now;

                return PartialView("Company",viewModel);
            
           
            
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyPartial()
        {
            string companyName = HttpContext.Session.GetString("SelectedCompanyName");
            if (string.IsNullOrEmpty(companyName))
            {
                return NotFound();
            }

            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Name == companyName);

            if (company == null)
            {
                return NotFound();
            }

            var viewModel = new CompanyVM(company);
            return PartialView("Company", viewModel);
        }


    }
}
