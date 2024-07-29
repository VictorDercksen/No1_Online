using No1_Online.Classes;
using No1_Online.Models;

namespace No1_Online.ViewModels
{

    public class ReportsVM
    {
        private IEnumerable<LoadingSchedule> loadingSchedules1;

        public  List<LoadingSchedule> loadingSchedules { get; set; } = new List<LoadingSchedule>();
        public Dictionary<Vehicle, decimal> vehicleTotals { get; set; }
        public Calculations Calculations { get; set; }
        public List<TransportedProduct> transportedProducts { get; set; }  = new List<TransportedProduct>();      
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public ReportsVM(List<TransportedProduct> _transportedProducts,Dictionary<Vehicle,decimal> _vehicleTotals,List<LoadingSchedule> _loadingSchedules,DateTime _startDate, DateTime _endDate)
        { 
            this.loadingSchedules = _loadingSchedules;
            this.vehicleTotals = _vehicleTotals;
            this.Calculations = new Calculations(_transportedProducts,_vehicleTotals,_loadingSchedules);
            this.startDate = _startDate;
            this.endDate = _endDate;
        }

        public ReportsVM(Vehicle? vehicle, IEnumerable<LoadingSchedule> loadingSchedules1)
        {
            this.loadingSchedules1 = loadingSchedules1;
        }
        public ReportsVM()
        {
            
        }

        public void GenerateReport()
        {

        }
    }

    
}
