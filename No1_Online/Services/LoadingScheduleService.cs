using Microsoft.EntityFrameworkCore;
using No1_Online.Data;
using No1_Online.Interfaces;
using No1_Online.Models;
using No1_Online.ViewModels;
using System.Web.Mvc;

namespace No1_Online.Services
{
    public class LoadingScheduleService : ILoadingScheduleService
    {
        private readonly AppDbContext _context;

        public LoadingScheduleService(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<LoadingScheduleVM> GetLoadingSchedule(int? searchId)
        {
            if (searchId == null) { return null; }


            var loadingSchedule = await _context.LoadingSchedules
                .Include(c => c.Company)
                .Include(c => c.LoadingPointLoad)
                .Include(c => c.LoadingPointOff)
                .Include(c => c.Note)
                .Include(c => c.Vehicle)
                .Include(c => c.CompanyTrans)
                .FirstOrDefaultAsync(c => c.Id == searchId); // Compare integer IDs

            if (loadingSchedule == null)
            {
                return null; // Or handle the case where the loading schedule is not found
            }
            var transportedProduct = await _context.TransportedProducts
                .Include(c => c.Product)
                .Where(c => c.LoadingScheduleId == loadingSchedule.Id).ToListAsync();

            var clientPayment = await _context.ClientPayments
                .FirstOrDefaultAsync(c => c.LoadingScheduleId.Equals(loadingSchedule.Id));
            var remitance = await _context.Remitances
                .FirstOrDefaultAsync(c => c.LoadingScheduleId.Equals(loadingSchedule.Id));

            var viewModel = new LoadingScheduleVM(loadingSchedule, transportedProduct, clientPayment, remitance);


            return viewModel; // Return the partial view with the populated ViewModel
        }
    }
}
