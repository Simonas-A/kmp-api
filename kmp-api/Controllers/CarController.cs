using kmp_api.Connections;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace kmp_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarListingsController> _logger;

        public CarController(ILogger<CarListingsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCars")]
        public IEnumerable<Car> Get()
        {
            return ListingsDatabase.GetCars();
        }

        //[HttpGet(Name = "GetCarListings")]
        //public IEnumerable<CarListing> GetCarListings()
        //{
        //    return ListingsDatabase.GetCarListings();
        //}

        [HttpPost(Name = "AddCar")]
        public bool Post(int year, int mileage, string brand, string model)
        {
            return ListingsDatabase.AddCar(year, mileage, brand, model);
        }
    }
}