using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstWebApp.Data;
using MyFirstWebApp.Models;
using System.Diagnostics;

namespace MyFirstWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MyAplicationContext _context;

       public HomeController(ILogger<HomeController> logger, MyAplicationContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Index(InputModel model)
        {
            return View();
        }

            [HttpGet]
        public IActionResult Index()
        {
            var cars = _context.Cars.ToList();

            return View(cars);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}