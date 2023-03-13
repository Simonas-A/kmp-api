using kmp_api.Services;
using kmp_api.Models;
using kmp_api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace kmp_api.Controllers
{
	[Route("Car")]
	[ApiController]
	public class CarController : Controller
	{
		private readonly CarService _carService;
		private readonly IMapper _mapper;

		public CarController (CarService carService, IMapper mapper)
		{
			_carService = carService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<CarView>> GetRentalItems()
		{
			var cars = await _carService.GetCarsAsync();


			var carView = _mapper.Map<IEnumerable<Car>>(cars);
			return Ok(carView);
		}
	}
}
