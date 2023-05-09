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
        private readonly ImageService _imageService;

        public CarController(ILogger<ListingController> logger, ImageService imageService)
        {
            _logger = logger;
            _imageService = imageService;
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

        [HttpPut("UpdateCar")]
        public void Put(Guid id, int year, int mileage, string brand, string model, decimal price, string owner, string phone)
        {
            DatabaseConnect.UpdateCar(id, year, mileage, brand, model, price, owner, phone);
        }

        [HttpDelete("DeleteCar/{id}")]
        public void Delete(Guid id)
        {
            DatabaseConnect.DeleteCar(id);
        }

        [HttpPost]
        public async Task<string> Post([FromBody] string image) {
            string url = await _imageService.UploadImage(image);
            return url;
        }
    }
}