using kmp_api.Connections;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace kmp_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarListingsController : ControllerBase
    {
        private readonly ILogger<CarListingsController> _logger;

        public CarListingsController(ILogger<CarListingsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetListings")]
        public IEnumerable<Listing> Get()
        {
            return ListingsDatabase.GetListings();
        }

        [HttpPost(Name = "AddListing")]
        public bool Post(decimal price, Guid carId)
        {
            return ListingsDatabase.AddListing(price, carId);
        }
    }
}