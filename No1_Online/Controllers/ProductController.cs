using Microsoft.AspNetCore.Mvc;

namespace No1_Online.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Product()
        {
            return PartialView("Product");
        }
    }
}
