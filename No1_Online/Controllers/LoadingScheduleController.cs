using Microsoft.AspNetCore.Mvc;

namespace No1_Online.Controllers
{
    public class LoadingScheduleController : Controller
    {
        public IActionResult LoadingSchedule()
        {
            return PartialView("LoadingSchedule");
        }
    }
}
