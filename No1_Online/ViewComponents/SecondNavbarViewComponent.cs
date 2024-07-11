using Microsoft.AspNetCore.Mvc;
using No1_Online.Models;
using No1_Online.ViewModels;

namespace No1_Online.ViewComponents
{
    public class SecondNavbarViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecondNavbarViewComponent(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public  IViewComponentResult Invoke(SecondNavbarViewModel model)
        {
            

            return View(model);
        }
    }
}
