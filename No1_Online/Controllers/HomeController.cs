﻿using Microsoft.AspNetCore.Mvc;
using No1_Online.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace No1_Online.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            ViewData["ShowSecondNavbar"] = false;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}