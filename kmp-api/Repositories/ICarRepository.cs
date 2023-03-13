using static System.Net.Mime.MediaTypeNames;
using kmp_api.Models;

namespace kmp_api.Repositories
{
	public interface ICarRepository
	{
		Task<IEnumerable<Car>> GetCarsAsync();
		Task<Car> AddCarAsync(Car vehicle);
		Car UpdateCarAsync(Car vehicle);
		void DeleteAsync();
	}
}
