﻿namespace kmp_api.ViewModels
{
	public class CarView
	{
		public Guid Id { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public int Price { get; set; }
		public bool IsActive { get; set; }
		public bool IsReserved { get; set; }
		public int? Year { get; set; }
		public string? Fuel { get; set; }
		public string? BodyType { get; set; }
		public bool? PlugIn { get; set; }
		public string? DrivenWheels { get; set; }
		public int? Power { get; set; }
		public int? EngineCapacity { get; set; }
		public string? Country { get; set; }
		public string? City { get; set; }
		public string? Thumbnail { get; set; }
		public string? Description { get; set; }
		//Need image
		public string PhoneNumber { get; set; }
		public Guid UserId { get; set; }
	}
}
