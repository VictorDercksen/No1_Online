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
        
        private  IHttpContextAccessor _httpContextAccessor;
        public CompanyController(AppDbContext context,  IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
           
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> SearchCompany(string searchBox)
        {
            if (string.IsNullOrEmpty(searchBox))
            {
                // Handle empty search box (e.g., return BadRequest())
                return BadRequest();
            }

            // Fetch the company from the database
            Company selectedCompany = await _context.Companies.FirstOrDefaultAsync(c => c.Name == searchBox);

            if (selectedCompany == null)
            {
                // Company not found, handle accordingly (e.g., return NotFound())
                return NotFound();
            }

            // Store the selected company in session
            _httpContextAccessor.HttpContext.Session.SetString("SelectedCompanyName", selectedCompany.Name);
            //Console.WriteLine(_httpContextAccessor.HttpContext.Session.GetString("SelectedCompanyName"));

            // Redirect to the desired page
            return RedirectToAction("Index", "Home"); // Change this to your desired action and controller
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyVM companyVm)
        {
            //foreach (var val in ModelState.Values)
            //{
            //    Console.WriteLine(val.AttemptedValue);
            //}
            //Console.WriteLine();
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
                viewModel.company.Note.Date = DateTime.Now;
                viewModel.company.Note.Revision = DateTime.Now;

                return PartialView("Company",viewModel);
            
           
            
        }

    }
}
