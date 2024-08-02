using No1_Online.Models;

namespace No1_Online.ViewModels
{
    public class TransporterPaymentInputViewModel
    {
        public Remitance Remitance { get; set; }

        public TransporterPaymentInputViewModel()
        {
            Remitance = new Remitance();
        }
    }
}
