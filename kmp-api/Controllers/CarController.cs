using kmp_api.Connections;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace kmp_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<ListingController> _logger;

        public CarController(ILogger<ListingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetCars")]
        public IEnumerable<Car> Get()
        {
            return DatabaseConnect.GetCars();
        }

        [HttpGet("GetCar/{id}")]
        public Car Get(Guid id)
        {
            return DatabaseConnect.GetCar(id);
        }

        [HttpPost("AddCar")]
        public Guid Post(int year, int mileage, string brand, string model, decimal price, string owner, string phone)
        {
            return DatabaseConnect.AddCar(year, mileage, brand, model, price, owner, phone);
        }
    }
}