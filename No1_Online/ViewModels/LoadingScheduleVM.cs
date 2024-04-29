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
            this.calculations = new Calculations(); 
        }

    }

    public class Calculations
    {
        public decimal loadTotal { get; set; }
        public  decimal load { get; set; }
        public decimal subTotal { get; set; }
        public decimal sub { get; set; }
        public decimal VAT = 0.15m;
        public decimal loadVAT { get; set; }    
        public decimal subVAT { get; set; }
        public decimal profit { get; set; }
        public decimal profitVAT { get; set; }
       
       public Calculations(List<TransportedProduct> _transportedProducts)
        {
            foreach(var  product in _transportedProducts)
            {
                load += product.LoadRate * product.Quantity;
                sub += product.PaymentRate * product.Quantity;
            }
            loadVAT = VAT * load;
            subVAT = VAT * sub;

            loadTotal = load + loadVAT;
            subTotal = sub + subVAT;

            profit = load - sub;
            profitVAT = VAT * profit;
        }

        public Calculations()
        {
            this.loadTotal = 0;
            this.subTotal = 0;
            this.load = 0;
            this.sub = 0;
            this.loadVAT = 0;   
            this.subVAT = 0;    
            this.profit = 0;
            this.profitVAT = 0;

        }
    }
}
