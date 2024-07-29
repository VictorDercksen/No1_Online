using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using No1_Online.Data;
using No1_Online.Models;
using No1_Online.ViewModels;

namespace No1_Online.Controllers
{
    public class LoadingScheduleController : Controller
    {
        private readonly AppDbContext _context;

        public LoadingScheduleController(AppDbContext context)
        {
            this._context = context;   
        }
        public IActionResult LoadingSchedule()
        {       
            List<TransportedProduct> transportedProducts = new List<TransportedProduct>();  
            LoadingSchedule loadingSchedule = new LoadingSchedule();
            ClientPayment clientPayment = new ClientPayment();
            Remitance remitance = new Remitance();
            var  viewModel =  new LoadingScheduleVM(loadingSchedule,transportedProducts, clientPayment, remitance );
            return PartialView("LoadingSchedule",viewModel);
        }

        

       
    }
}
