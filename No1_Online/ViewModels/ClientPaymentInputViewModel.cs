using No1_Online.Models;

namespace No1_Online.ViewModels
{
    public class ClientPaymentInputViewModel
    {
        public ClientPayment ClientPayment { get; set; }

        public ClientPaymentInputViewModel()
        {
            ClientPayment = new ClientPayment();
        }
    }
}
