﻿using CarRental.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Help()
        {
            return View();
        }
       
    }
}
