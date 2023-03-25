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

        [HttpGet("GetCarListings")]
        public IEnumerable<CarListing> GetCarListings()
        {
            return DatabaseConnect.GetCarListings();
        }

        [HttpGet("GetCarListing/{id}")]
        public CarListing GetCarListing(Guid id)
        {
            return DatabaseConnect.GetCarListing(id);
        }
    }
}
