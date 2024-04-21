using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using No1_Online.Data;
using No1_Online.ViewModels;

namespace No1_Online.Controllers
{
    public class LoadingScheduleController : Controller
    {
        private readonly AppDbContext _context;

        public LoadingScheduleController(AppDbContext context)
        {
            this._context = context;   
        }
        public IActionResult LoadingSchedule()
        {
            return PartialView("LoadingSchedule");
        }

        [HttpGet]
        public async Task<IActionResult> SearchLoadingSchedule(string searchBox)
        {
            if (string.IsNullOrEmpty(searchBox))
            {
                return PartialView("LoadingSchedule", new LoadingScheduleVM()); // Return the partial view with an empty ViewModel
            }

            if (!int.TryParse(searchBox, out int searchId))
            {
                return NotFound(); // Or handle the case where the input is not a valid integer
            }


            var loadingSchedule = await _context.LoadingSchedules
                .Include(c => c.Company)
                .Include(c => c.LoadingPointLoad)
                .Include(c => c.LoadingPointOff)
                .Include(c => c.Note)
                .Include(c => c.Vehicle)
                .Include(c=> c.CompanyTrans)
                .FirstOrDefaultAsync(c => c.Id == searchId); // Compare integer IDs

            if (loadingSchedule == null)
            {
                return NotFound(); // Or handle the case where the loading schedule is not found
            }

            var viewModel = new LoadingScheduleVM(loadingSchedule);
            
            return PartialView("LoadingSchedule", viewModel); // Return the partial view with the populated ViewModel
        }


    }
}
