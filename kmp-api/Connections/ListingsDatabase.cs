using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data.Common;

namespace kmp_api.Connections
{
    public static class ListingsDatabase
    {
        public static IEnumerable<Listing> GetListings()
        {
            List<Listing> listings = new List<Listing>();

            //var con = new SqlConnection(
            
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "";
                builder.UserID = "";
                builder.Password = "";
                builder.InitialCatalog = "";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = "SELECT id, carId, price FROM listings";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listings.Add(new Listing(
                                    reader.GetGuid(0),
                                    reader.GetGuid(1),
                                    reader.GetDecimal(2)
                                ));
                                //listings.Add()
                                //Console.WriteLine("{0} {1} {2}", reader.GetString(0), reader.GetString(1), reader.GetString(2));
                            }
                        }
                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return listings;
            
            //Console.ReadLine();
            //var connection =
            //return new Listings[] { };
        }

        public static IEnumerable<CarListing> GetCarListings()
        {

            List<CarListing> listings = new List<CarListing>();


            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "";
                builder.UserID = "";
                builder.Password = "";
                builder.InitialCatalog = "";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = "SELECT c.brand, c.model, c.year, l.price FROM listings l LEFT JOIN cars c ON l.carId = c.id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listings.Add(new CarListing(
                                    reader.GetString(0),
                                    reader.GetString(1),
                                    reader.GetInt32(2),
                                    reader.GetDecimal(3)
                                ));
                            }
                        }
                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return listings;
        }

        public static bool AddListing (decimal price, Guid carId)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "";
                builder.UserID = "";
                builder.Password = "";
                builder.InitialCatalog = "";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = String.Format("INSERT INTO Listings (id, carId, price) VALUES (NEWID(), '{0}', {1})",
                        carId, price);

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        int q = command.ExecuteNonQuery();

                        if (q != 1)
                            return false;

                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public static bool AddCar(int year, int mileage, string brand, string model)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "";
                builder.UserID = "";
                builder.Password = "";
                builder.InitialCatalog = "";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = String.Format("INSERT INTO Cars (id, year, mileage, brand, model) VALUES (NEWID(), {0}, {1}, '{2}', '{3}')",
                        year, mileage, brand, model);

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        int q = command.ExecuteNonQuery();

                        if (q != 1)
                            return false;

                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public static IEnumerable<Car> GetCars()
        {
            List<Car> cars = new List<Car>();

            //var con = new SqlConnection(

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "";
                builder.UserID = "";
                builder.Password = "";
                builder.InitialCatalog = "";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = "SELECT id, brand, model, year, mileage FROM cars";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cars.Add(new Car(
                                    reader.GetGuid(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetInt32(3),
                                    reader.GetInt32(4)
                                ));
                                //listings.Add()
                                //Console.WriteLine("{0} {1} {2}", reader.GetString(0), reader.GetString(1), reader.GetString(2));
                            }
                        }
                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return cars;
        }
    }
}
