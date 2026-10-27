using CarClientApp.Data;
using CarClientApp.Models;
using CarClientApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace CarClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly CarClientService _carClientService;

        public HomeController(ILogger<HomeController> logger, CarClientService carClientService)
        {
            _logger = logger;
            _carClientService = carClientService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(string brand, string model)
        {
            var responseData = await _carClientService.SearchCars(brand, model);

            return View(responseData);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var carData = await _carClientService.GetCarAll();

            return View(carData);
        }

        #region -- Добавление
        [HttpPost]
        public async Task<IActionResult> Add(CarAddDto request)
        {
            await _carClientService.AddCar(request);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var groups = await _carClientService.GetGroupAll();

            return View(groups);
        }
        #endregion

        #region -- Редактирование
        [HttpPost]
        public async Task<IActionResult> Edit(CarEditDto request)
        {
            await _carClientService.Edit(request);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var responseData = await _carClientService.GetCarById(id);

            return View(responseData);
        }
        #endregion

        #region -- Удаление
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            await _carClientService.Remove(id);

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