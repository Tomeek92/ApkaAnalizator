using ApkaAnalizator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ApkaAnalizator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Analizator()
        {
            return View();
        }

        public IActionResult Hl7()
        {
            return View();
        }
        public IActionResult Page()
        {
            return View();
        }
    }
}
