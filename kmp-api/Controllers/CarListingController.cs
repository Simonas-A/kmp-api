using kmp_api.Connections;
using Microsoft.AspNetCore.Mvc;

namespace kmp_api.Controllers
{
    public class CarListingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly DatabaseConnect _databaseConnect;

        [HttpGet("GetCarListings")]
        public IEnumerable<CarListing> GetCarListings()
        {
            return _databaseConnect.GetCarListings();
        }

        [HttpGet("GetCarListing/{id}")]
        public CarListing GetCarListing(Guid id)
        {
            return _databaseConnect.GetCarListing(id);
        }
    }
}
