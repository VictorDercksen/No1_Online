using No1_Online.Models;

namespace No1_Online.Classes
{
    public class Calculations
    {
        public decimal LoadTotal { get; private set; }
        public decimal Load { get; private set; }
        public decimal SubTotal { get; private set; }
        public decimal Sub { get; private set; }
        public const decimal VAT = 0.15m;
        public decimal LoadVAT { get; private set; }
        public decimal SubVAT { get; private set; }
        public decimal Profit { get; private set; }
        public decimal ProfitVAT { get; private set; }
        public Dictionary<Vehicle, decimal> vehicleTotals { get; private set; }
        public decimal VehicleTotalTransPorted { get; private set; }
        public Calculations(List<TransportedProduct> transportedProducts = null,Dictionary<Vehicle,decimal> vehicleTotals = null, List<LoadingSchedule> loadingSchedules = null) 
        {
            if (transportedProducts != null && vehicleTotals  != null)
            {
                
                CalculateVehiclesTotals(transportedProducts, vehicleTotals, loadingSchedules);
            }
        }

        public Calculations(List<TransportedProduct> transportedProducts = null)
        {
            CalculateTransPortedProducts(transportedProducts);
        }
        private void CalculateVehiclesTotals(List<TransportedProduct> transportedProducts, Dictionary<Vehicle, decimal> vehicleTotals, List<LoadingSchedule> loadingSchedules)
        {
            foreach(var product in transportedProducts)
            {
               foreach(var load in loadingSchedules)
                {
                    if(product.LoadingSchedule.Id == load.Id)
                    {
                        vehicleTotals[load.Vehicle] += product.PaymentRate * product.Quantity;
                    }
                }
            }

            this.vehicleTotals = vehicleTotals;
        }

        

        //private void CalculateVehicleTotal(List<LoadingSchedule> loadingSchedules)
        //{
        //    foreach(var schedule in loadingSchedules) 
        //    {
        //        VehicleTotalTransPorted += schedule.Value;
        //    }
        //}

        private void CalculateTransPortedProducts(List<TransportedProduct> transportedProducts)
        {
            foreach (var product in transportedProducts)
            {
                Load += product.LoadRate * product.Quantity;
                Sub += product.PaymentRate * product.Quantity;
            }
            ComputeVATAndTotals();
        }

        private void ComputeVATAndTotals()
        {
            LoadVAT = VAT * Load;
            SubVAT = VAT * Sub;

            LoadTotal = Load + LoadVAT;
            SubTotal = Sub + SubVAT;

            Profit = Load - Sub;
            ProfitVAT = VAT * Profit;
        }
    }
}
