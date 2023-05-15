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
        private readonly DatabaseConnect _databaseConnect;

        public CarController(ILogger<ListingController> logger, ImageService imageService)
        {
            _logger = logger;
            _imageService = imageService;
            _databaseConnect = new DatabaseConnect();
        }

        [HttpGet("GetCars")]
        public IEnumerable<Car> Get()
        {
            return _databaseConnect.GetCars();
        }

        [HttpGet("GetCar/{id}")]
        public Car Get(Guid id)
        {
            return _databaseConnect.GetCar(id);
        }

        [HttpPost("AddCar")]
        public async Task<Guid> Post(Car listing)
        {
			//return Guid.NewGuid();
			Guid carId = _databaseConnect.AddCar(listing);

			ImageService imageService = new ImageService();

			foreach (var image in listing.Images)
			{
				string imageUrl = await imageService.UploadImage(image);
                _databaseConnect.AddImage(imageUrl, carId);
			}

			return carId;

			//ImageService.UploadImage(listing.Image, carId);
			//return DatabaseConnect.AddCar(listing);
		}

        //[HttpPost("AddCar")]
        //public Guid Post(int year, int mileage, string brand, string model, decimal price, string owner, string phone)
        //{
        //    return DatabaseConnect.AddCar(year, mileage, brand, model, price, owner, phone);
        //}

        [HttpPut("UpdateCar/{id}")]
        public void Put(Guid id, [FromBody] Car car)
        {
            _databaseConnect.UpdateCar(id, car);
        }

        [HttpDelete("DeleteCar/{id}")]
        public void Delete(Guid id)
        {
            _databaseConnect.DeleteCar(id);
        }

        [HttpPost]
        public async Task<string> Post([FromBody] string image) {
            string url = await _imageService.UploadImage(image);
            return url;
        }
    }
}