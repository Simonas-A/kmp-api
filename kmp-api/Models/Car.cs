using System.Text.Json.Serialization;

namespace kmp_api.Models
{
	public class Car
	{
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public bool IsReserved { get; set; }
        public bool IsActive { get; set; }
        public int? Year { get; set; }
        public string? Fuel { get; set; }
        public string? BodyType { get; set; }
        public bool? PlugIn { get; set; }
        public string? DrivenWheels { get; set; }
        public int? Power { get; set; }
        public int? EngineCapacity { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Description { get; set; }
        //Need image and user to which belongs
    }
}
