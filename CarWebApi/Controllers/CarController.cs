using CarWebApi.Data;
using CarWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CarWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {

        private readonly ILogger<CarController> _logger;

        private readonly MyAplicationContext _context;

        public CarController(ILogger<CarController> logger, MyAplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<CarGet> Get()
        {
            _logger.LogInformation("Получаю список авто");

            return _context.Cars
                .Select(x => new CarGet
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model
                })
                .ToList();
        }

        [HttpGet("{id}")]
        public Car? Get(int id)
        {
            return _context.Cars
                .FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public IEnumerable<Car> Post(string? brand, string? model)
        {
            _logger.LogInformation("Получаю список авто с фильтром");

            var query = _context.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(brand))
            {
                query = query.Where(x => x.Brand == brand);
            }
            if (!string.IsNullOrEmpty(model))
            {
                query = query.Where(x => x.Model.Contains(model));
            }

            var cars = query.ToList();

            return cars;
        }

        [HttpPut]
        public Car Put(CarAdd request)
        {
            _logger.LogInformation("Добавляю новое авто");

            var car = new Car
            {
                Brand = request.Brand,
                Model = request.Model,
                Password = request.Password,
                GroupId = request.GroupId
            };

            _context.Cars.Add(car);
            _context.SaveChanges();

            return car;
        }

        [HttpDelete]
        public IActionResult Delete(int carId)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == carId);

            if(car != null)
            {
                _context.Remove(car);
                _context.SaveChanges();

                return Ok();
            }

            return NotFound();
        }

        [HttpPatch]
        public IActionResult Patch(Car model)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == model.Id);

            if (car != null)
            {
                car.Brand = model.Brand;
                car.Model = model.Model;
                car.Password = model.Password;

                _context.Update(car);
                _context.SaveChanges();

                return Ok();
            }

            return NotFound();
        }

    }
}
