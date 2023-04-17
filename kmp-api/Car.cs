namespace kmp_api
{
    public class Car
    {
        public Car(Guid id, string brand, string model, int year, int mileage, decimal price, string owner, string phoneNumber)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Mileage = mileage;
            Price = price;
            Owner = owner;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }
        public string Owner { get; set; }
        public string PhoneNumber { get; set; }

    }
}
