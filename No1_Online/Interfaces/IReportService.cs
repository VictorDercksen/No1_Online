using System.Composition;

namespace No1_Online.Interfaces
{
    public interface IReportService
    {
        IEnumerable<String> SearchReports(string query);
    }
}
