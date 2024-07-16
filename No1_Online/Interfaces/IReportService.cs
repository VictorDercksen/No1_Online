using No1_Online.ViewModels;
using System.Composition;

namespace No1_Online.Interfaces
{
    public interface IReportService
    {
        Task<ReportsVM> GetIncomeAllVehiclesAsync(DateTime startDate, DateTime endDate, string transporter);
    }
}
