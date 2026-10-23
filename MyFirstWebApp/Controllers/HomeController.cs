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
        public IActionResult Index(string brand, string model)
        {
            var query = _context.Cars.AsQueryable();

            if(!string.IsNullOrEmpty(brand))
            {
                query = query.Where(x => x.Brand == brand);
            }
            if (!string.IsNullOrEmpty(model))
            {
                query = query.Where(x => x.Model.Contains(model));
            }

            var cars = query.ToList();

            return View(cars);
        }

            [HttpGet]
        public IActionResult Index()
        {
            var cars = _context.Cars.ToList();

            return View(cars);
        }

        #region -- Добавление
        [HttpPost]
        public IActionResult Add(string brand, string model)
        {
            var car = new Car
            {
                Brand = brand,
                Model = model
            };

            _context.Cars.Add(car);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        #endregion

        #region -- Редактирование
        [HttpPost]
        public IActionResult Edit(string brand, string model, int id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);

            if (car != null)
            {
                car.Brand = brand;
                car.Model = model;

                _context.Cars.Update(car);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);

            return View(car);
        }
        #endregion

        #region -- Удаление
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);

            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

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