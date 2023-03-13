using kmp_api.Models;
using kmp_api.Repositories;

namespace kmp_api.Services
{
	public class CarService
	{
		private readonly ICarRepository _carRepository;

		public CarService(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}


		public async Task<IEnumerable<Car>> GetCarsAsync()
		{
			return await _carRepository.GetCarsAsync();
		}

		public async Task CreateCarAsync(Car car)
		{
			await _carRepository.AddCarAsync(car);
		}
	}
}
