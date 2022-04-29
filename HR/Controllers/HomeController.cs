﻿using HR.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HR.Controllers
{
    public class HomeController : Controller
    {  
        public IActionResult Index()
        {
            return View();
        }
         
        public IActionResult Hr()
        {
            return View();
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}