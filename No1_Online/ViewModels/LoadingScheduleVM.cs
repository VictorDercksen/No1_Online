using No1_Online.Models;
using No1_Online.ViewModels;

public class LoadingScheduleVM
{
    public LoadingScheduleDetailsViewModel LoadingScheduleDetails { get; set; }
    public ClientPaymentInputViewModel ClientPaymentInput { get; set; }
    public TransporterPaymentInputViewModel TransporterPaymentInput { get; set; }
    public InvoicesComponentViewModel InvoicesComponent { get; set; }
    public NotesComponentViewModel NotesComponent { get; set; }
    public ProductTableViewModel ProductTable { get; set; }

    public LoadingScheduleVM()
    {
        LoadingScheduleDetails = new LoadingScheduleDetailsViewModel();
        ClientPaymentInput = new ClientPaymentInputViewModel();
        TransporterPaymentInput = new TransporterPaymentInputViewModel();
        InvoicesComponent = new InvoicesComponentViewModel();
        NotesComponent = new NotesComponentViewModel();
        ProductTable = new ProductTableViewModel();
    }

    public void Initialize(LoadingSchedule loadingSchedule, List<TransportedProduct> transportedProducts, ClientPayment clientPayment, Remitance remitance)
    {
        LoadingScheduleDetails.LoadingSchedule = loadingSchedule ?? new LoadingSchedule();
        ClientPaymentInput.ClientPayment = clientPayment ?? new ClientPayment();
        TransporterPaymentInput.Remitance = remitance ?? new Remitance();
        ProductTable.TransportedProducts = transportedProducts ?? new List<TransportedProduct>();
        ProductTable.UpdateCalculations();
    }
}