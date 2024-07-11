
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

namespace No1_Online.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;

        private IHttpContextAccessor _httpContextAccessor;
       
        public ReportsController(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
          
        }
        


        [HttpGet]
        public async Task<IActionResult> IncomeAllVehicles(DateTime startDate, DateTime endDate, string transporter) 
        {


            ReportsVM viewModel = await GetIncomeAllVehicles(startDate, endDate, transporter);
            
            return PartialView("IncomeAllVehicles",viewModel);



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
        [HttpGet]
        public async Task<IActionResult> GenerateReport(DateTime startDate, DateTime endDate, string transporter)
        {
            try
            {
                ReportsVM viewModel = await GetIncomeAllVehicles(startDate, endDate, transporter);
                if (viewModel == null || !viewModel.loadingSchedules.Any())
                {
                    return NotFound("No data found for the given criteria.");
                }

                var document = new IncomeAllVehiclesDocument(viewModel, "Transporter: " + viewModel.loadingSchedules[0].CompanyTrans.Name);

                // Generate the PDF as a byte array
                byte[] pdfBytes = document.GeneratePdf();

                return new FileContentResult(pdfBytes, "application/pdf")
                {
                    FileDownloadName = "IncomeAllVehiclesReport_"+ viewModel.loadingSchedules[0].CompanyTrans.Name + ".pdf"
                };
            }
            catch (Exception ex)
            {
                // Log the exception and return an error response
                return StatusCode(500, new { message = "An error occurred while generating the report.", error = ex.Message });
            }
        }

        [HttpGet]
        public  IActionResult SecondNavbar(string transporter, DateTime startDate, DateTime endDate)
        {
            var viewModel = new SecondNavbarViewModel
            {
                _startDate = startDate,
                _endDate = endDate,
                _transporter = transporter
            };
            return ViewComponent("SecondNavbar", viewModel);
        }
    }

    
}


