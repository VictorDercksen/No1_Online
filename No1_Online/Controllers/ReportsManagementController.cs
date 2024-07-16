using Microsoft.AspNetCore.Mvc;
using No1_Online.Interfaces;

namespace No1_Online.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsManagementController : Controller
    {
        

        public ReportsManagementController()
        {
            
        }

        //[HttpGet("search")]
        //public IActionResult SearchReports(string query)
        //{
        //    var reports = _reportService.SearchReports(query);
        //    return Ok(reports);
        //}

       
    }
}
