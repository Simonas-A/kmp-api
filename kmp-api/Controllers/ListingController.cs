using kmp_api.Connections;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace kmp_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListingController : ControllerBase
    {
        private readonly ILogger<ListingController> _logger;

        public ListingController(ILogger<ListingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetListings")]
        public IEnumerable<Listing> Get()
        {
            return DatabaseConnect.GetListings();
        }

        [HttpGet("GetListing/{id}")]
        public Listing GetListing(Guid id)
        {
            return DatabaseConnect.GetListing(id);
        }

        [HttpPost("AddListing")]
        public Guid Post(decimal price, Guid carId)
        {
            return DatabaseConnect.AddListing(price, carId);
        }
    }
}