
using Microsoft.AspNetCore.Mvc;

using No1_Online.Data;
using Microsoft.EntityFrameworkCore;
using No1_Online.ViewModels;
using No1_Online.Models;
using No1_Online.Classes;

using QuestPDF.Helpers;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using No1_Online.Classes.Reports;
using No1_Online.Interfaces;
using static No1_Online.Views.Shared.Component.IncomeAllVehiclesForm;

namespace No1_Online.Controllers
{

    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;

        
       
        public ReportsController(AppDbContext context)
        {
            this._context = context;
           
          
        }
        


       
        [HttpGet]
        public async Task<ReportsVM> GetIncomeAllVehicles(DateTime startDate, DateTime endDate, string transporter)
        {


            var vehicleTotals = new Dictionary<Vehicle, decimal>();

            var loadingSchedules = await _context.LoadingSchedules
                .Include(c => c.Company)
                .Include(c => c.CompanyTrans)
                .Include(c => c.Vehicle)
                .Include(c => c.LoadingPointLoad)
                .Include(c => c.LoadingPointOff)
                .Where(c => c.CompanyTrans.Name == transporter && c.Date >= startDate && c.Date <= endDate)
                .ToListAsync();
            var transportedProducts = await _context.TransportedProducts
                .Include(c => c.LoadingSchedule)
                .Where(c => c.LoadingSchedule.CompanyTrans.Name == transporter).ToListAsync();

            foreach (var load in loadingSchedules)
            {
                if (!vehicleTotals.ContainsKey(load.Vehicle))
                {
                    vehicleTotals.Add(load.Vehicle, 0);
                }
                else
                {
                    continue;
                }
            }

            var viewModel = new ReportsVM(transportedProducts, vehicleTotals, loadingSchedules, startDate, endDate);
            
            return viewModel;



        }
        [HttpPost("IncomeAllVehicles")]
        public async Task<IActionResult> OnPostIncomeAllVehiclesAsync(IncomeAllVehiclesFormModel incomeAllVehiclesFormModel)
        {
            var reportsVM = await GetIncomeAllVehicles(
                incomeAllVehiclesFormModel.StartDate,
                incomeAllVehiclesFormModel.EndDate,
                incomeAllVehiclesFormModel.Transporter
            );

            // Assuming you have a Razor partial view to render this data
            return new JsonResult(reportsVM);
        }
        


        //[HttpGet]
        //public  IActionResult SecondNavbar(string transporter, DateTime startDate, DateTime endDate)
        //{
        //    var viewModel = new SecondNavbarViewModel
        //    {
        //        _startDate = startDate,
        //        _endDate = endDate,
        //        _transporter = transporter
        //    };
        //    return ViewComponent("SecondNavbar", viewModel);
        //}


    }

    
}


