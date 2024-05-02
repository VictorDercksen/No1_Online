using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using  Org.BouncyCastle;
using No1_Online.Data;
using Microsoft.EntityFrameworkCore;
using No1_Online.ViewModels;
using No1_Online.Models;

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
        public IActionResult GeneratePDF(Object object_selected)
        {
            
            if (object_selected is List<LoadingSchedule> schedules)
            {
                

                using (var stream = new MemoryStream())
                {
                    using (var writer = new PdfWriter(stream))
                    {
                        using (var pdf = new PdfDocument(writer))
                        {
                            var document = new Document(pdf);

                            // Define the table with a number of columns
                            Table table = new Table(13); // Adjust the number of columns based on your data needs

                            // Add headers to the table
                            table.AddHeaderCell("Id");
                            table.AddHeaderCell("Date");
                            table.AddHeaderCell("PurchaseOrder");
                            table.AddHeaderCell("SubReg");
                            table.AddHeaderCell("Value");
                            table.AddHeaderCell("ProfileId");
                            table.AddHeaderCell("Podnum");
                            table.AddHeaderCell("PayTerms");
                            table.AddHeaderCell("Selfload");
                            table.AddHeaderCell("Company");
                            table.AddHeaderCell("Transporter");
                            table.AddHeaderCell("Loading Point");
                            table.AddHeaderCell("Offload Point");
                           

                            // Populate the table with data from each schedule
                            foreach (var schedule in schedules)
                            {
                                table.AddCell(schedule.Id.ToString());
                                table.AddCell(schedule.Date.ToString("dd-mm-yyyy")); 
                                table.AddCell(schedule.PurchaseOrder); 
                                table.AddCell(schedule.SubReg); 
                                table.AddCell(schedule.Value.ToString());
                                table.AddCell(schedule.ProfileId);
                                table.AddCell(schedule.Podnum);
                                table.AddCell(schedule.PayTerms);
                                table.AddCell(schedule.SelfLoad.ToString());
                                table.AddCell(schedule.Company.Name);
                                table.AddCell(schedule.CompanyTrans.Name);
                                table.AddCell(schedule.LoadingPointLoad.City);
                                table.AddCell(schedule.LoadingPointOff.City);
                            }

                            // Add the table to the document
                            document.Add(table);
                        }
                    }

                    var content = stream.ToArray();
                    return File(content, "application/pdf", "IncomePerVehicle.pdf");
                }
            }
            return PartialView("ErrorView"); // Provide a fallback view in case of type mismatch
        }


        [HttpGet]
        public async Task<IActionResult> IncomePerVehicle(DateTime startDate, DateTime endDate, string transporter) 
        {
           
            
            var vehicleTotals = new Dictionary<Vehicle,decimal>();

            var loadingSchedules = await _context.LoadingSchedules
                .Include(c  => c.Company)
                .Include(c => c.CompanyTrans)
                .Include(c => c.Vehicle)
                .Include(c => c.LoadingPointLoad)
                .Include(c => c.LoadingPointOff)
                .Where(c => c.CompanyTrans.Name == transporter && c.Date >=  startDate && c.Date <= endDate)
                .ToListAsync();
            var  transportedProducts = await _context.TransportedProducts
                .Include(c => c.LoadingSchedule)
                .Where(c => c.LoadingSchedule.CompanyTrans.Name == transporter).ToListAsync();

            foreach(var load in loadingSchedules)
            {
                if (!vehicleTotals.ContainsKey(load.Vehicle))
                {
                    vehicleTotals.Add(load.Vehicle,0);
                }
                else
                {
                    continue;
                }
            }    

            var viewModel = new ReportsVM(transportedProducts,vehicleTotals,loadingSchedules,startDate,endDate);
        
            
            return PartialView("IncomePerVehicle",viewModel);
        }  
        public IActionResult Reports()
        {
            return PartialView("Reports");
        }
    }
}
