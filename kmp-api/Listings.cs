namespace kmp_api
{
    public class Listings
    {
        public Listings(Guid id, Guid carId, decimal price)
        {
            Id = id;
            CarId = carId;
            Price = price;
        }
        
        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        public decimal Price { get; set; }

    }
}
