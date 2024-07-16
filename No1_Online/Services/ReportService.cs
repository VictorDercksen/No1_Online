using Microsoft.EntityFrameworkCore;
using No1_Online.Data;
using No1_Online.Interfaces;
using No1_Online.Models;
using No1_Online.ViewModels;

namespace No1_Online.Services
{
    public class ReportService : IReportService
    {
        private readonly AppDbContext _context;

        public ReportService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ReportsVM> GetIncomeAllVehiclesAsync(DateTime startDate, DateTime endDate, string transporter)
        {
            var vehicleTotals = new Dictionary<Vehicle, decimal>();

            var loadingSchedules = await _context.LoadingSchedules
                .Include(c => c.Company)
                .Include(c => c.CompanyTrans)
                .Include(c => c.Vehicle)
                .Include(c => c.LoadingPointLoad)
                .Include(c => c.LoadingPointOff)
                .Where(c => c.CompanyTrans.Name == transporter && c.Date >= startDate && c.Date <= endDate)
                .ToListAsync();

            var transportedProducts = await _context.TransportedProducts
                .Include(c => c.LoadingSchedule)
                .Where(c => c.LoadingSchedule.CompanyTrans.Name == transporter).ToListAsync();

            foreach (var load in loadingSchedules)
            {
                if (!vehicleTotals.ContainsKey(load.Vehicle))
                {
                    vehicleTotals.Add(load.Vehicle, 0);
                }
                else
                {
                    continue;
                }
            }

            var viewModel = new ReportsVM(transportedProducts, vehicleTotals, loadingSchedules, startDate, endDate);
            return viewModel;
        }
    }

}
