namespace kmp_api
{
    public class CarListing
    {
        public CarListing(Guid id, Guid carId, string brand, string model, int year, int mileage, decimal price)
        {
            Id = id;
            CarId = carId;
            Brand = brand;
            Model = model;
            Year = year;
            Mileage = mileage;
            Price = price;
        }

        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }
    }
}
