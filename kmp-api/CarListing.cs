namespace kmp_api
{
    public class CarListing
    {
        public CarListing(string brand, string model, int year, decimal price)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
        }

        string Brand { get; set; }
        string Model { get; set; }
        int Year { get; set; }
        decimal Price { get; set; }
    }
}
