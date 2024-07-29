using No1_Online.Classes;
using No1_Online.Models;

namespace No1_Online.ViewModels
{
    public class LoadingScheduleVM
    {
        public LoadingSchedule loadingSchedule = new LoadingSchedule();
        public List<TransportedProduct> transportedProducts { get; set; } = new List<TransportedProduct>();  
        public ClientPayment clientPayment { get; set; } = new ClientPayment();
        public Remitance remitance { get; set; } = new Remitance();
        public Calculations calculations { get; set; }
        public LoadingScheduleVM(LoadingSchedule _loadingSchedule, List<TransportedProduct>  _transportedProducts, ClientPayment _clientPayment, Remitance _remitance)
        {
            this.loadingSchedule = _loadingSchedule;
            this.transportedProducts = _transportedProducts; 
            this.calculations = new Calculations(_transportedProducts);
            this.clientPayment = _clientPayment;
            this.remitance = _remitance;
        }

        public LoadingScheduleVM()
        {
            this.loadingSchedule = new LoadingSchedule();
            this.clientPayment = new ClientPayment();
            this.remitance = new Remitance();
        }

    }

    
}
