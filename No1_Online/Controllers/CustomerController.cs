using Microsoft.AspNetCore.Mvc;
using No1_Online.ViewModels;

namespace No1_Online.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Customer()
        {
            return View();
        }
    }
}
