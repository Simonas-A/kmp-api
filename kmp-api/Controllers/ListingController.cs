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
        private readonly DatabaseConnect _databaseConnect;

        public ListingController(ILogger<ListingController> logger)
        {
            _logger = logger;
            _databaseConnect = new DatabaseConnect();
        }

        [HttpGet("GetListings")]
        public IEnumerable<Listing> Get()
        {
            return _databaseConnect.GetListings();
        }

        [HttpGet("GetListing/{id}")]
        public Listing GetListing(Guid id)
        {
            return _databaseConnect.GetListing(id);
        }

        [HttpPost("AddListing")]
        public Guid Post(decimal price, Guid carId)
        {
            return _databaseConnect.AddListing(price, carId);
        }
    }
}