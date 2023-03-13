using AutoMapper;
using kmp_api.Models;
using kmp_api.ViewModels;

namespace kmp_api.Mapping
{
	public class CarMapping : Profile
	{
		public CarMapping()
		{
			CreateMap<Car, CarView>();
			CreateMap<CarView, Car>();
		}
		
	}
}
