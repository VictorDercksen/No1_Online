using No1_Online.Classes;
using No1_Online.Models;

namespace No1_Online.ViewModels
{
    public class ProductTableViewModel
    {
        public List<TransportedProduct> TransportedProducts { get; set; }
        public Calculations Calculations { get; set; }

        public ProductTableViewModel()
        {
            TransportedProducts = new List<TransportedProduct>();
           
        }

        public void UpdateCalculations()
        {
            Calculations = new Calculations(TransportedProducts);
        }
    }
}
