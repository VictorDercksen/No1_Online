using No1_Online.Interfaces;
using No1_Online.ViewModels;

namespace No1_Online.Services
{
    public class ReportsManagementService : IReportService
    {
        public Task<ReportsVM> GetIncomeAllVehiclesAsync(DateTime startDate, DateTime endDate, string transporter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> SearchReports(string query)
        {
            throw new NotImplementedException();
        }
    }
}
