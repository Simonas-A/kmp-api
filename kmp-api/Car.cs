using Newtonsoft.Json;

namespace kmp_api
{
    public class Car
    {
        public Car(Guid id, string brand, string model, int year, int mileage, decimal price, string owner, string phoneNumber, string[] images)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Mileage = mileage;
            Price = price;
            Owner = owner;
            PhoneNumber = phoneNumber;
            Images = images;
        }

		public Car(Car car)
		{
			Id = car.Id;
			Brand = car.Brand;
			Model = car.Model;
			Year = car.Year;
			Mileage = car.Mileage;
			Price = car.Price;
			Owner = car.Owner;
			PhoneNumber = car.PhoneNumber;
			Images = car.Images;
		}

		[JsonConstructor]
		public Car()
        {
			Id = new Guid();
			Brand = "";
			Model = "";
			Year = 10;
			Mileage = 10;
			Price = 102;
			Owner = "";
			PhoneNumber = "";
			Images = new string[]{ };
		}
		
		public Guid? Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }
        public string Owner { get; set; }
        public string PhoneNumber { get; set; }
        public string[] Images { get; set; }

    }
}
