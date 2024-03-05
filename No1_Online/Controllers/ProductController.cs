using Microsoft.AspNetCore.Mvc;
using No1_Online.Models; // Assuming your Product model is in this namespace
using No1_Online.Data; // Assuming your AppDbContext is in this namespace
using No1_Online.ViewModels;

namespace No1_Online.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var products =  _context.Products.ToList();
            var viewModel = new ProductVM
            {
                Products = products
            };
            return PartialView("Product",viewModel);
        }
    }
}
