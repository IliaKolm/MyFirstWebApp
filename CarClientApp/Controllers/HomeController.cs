using CarClientApp.Data;
using CarClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace CarClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Index(string brand, string model)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:5090/Car");
            var responseText = await response.Content.ReadAsStringAsync();
            var jsonOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var responseData = JsonSerializer.Deserialize<List<Car>>(responseText, jsonOptions);

            return View(responseData);
        }

        #region -- Добавление
        [HttpPost]
        public async Task<IActionResult> Add(CarAddDto request)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync("http://localhost:5090/Car", request);

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
        public async Task<IActionResult> Edit(CarEditDto request)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PatchAsJsonAsync("http://localhost:5090/Car", request);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5090/Car/{id}");
            var responseText = await response.Content.ReadAsStringAsync();
            var jsonOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var responseData = JsonSerializer.Deserialize<Car>(responseText, jsonOptions);

            return View(responseData);
        }
        #endregion

        #region -- Удаление
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync($"http://localhost:5090/Car?carId={id}");

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