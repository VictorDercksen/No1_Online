using Microsoft.AspNetCore.Mvc;
using No1_Online.Interfaces;

namespace No1_Online.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsManagementController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsManagementController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("search")]
        public IActionResult SearchReports(string query)
        {
            var reports = _reportService.SearchReports(query);
            return Ok(reports);
        }

       
    }
}
