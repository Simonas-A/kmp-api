namespace kmp_api
{
    public class Car
    {
        public Car(Guid id, string brand, string model, int year, int mileage)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Mileage = mileage;
        }

        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }

    }
}
