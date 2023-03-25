﻿using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data.Common;

namespace kmp_api.Connections
{
    public static class DatabaseConnect
        
    {
        public static IEnumerable<Listing> GetListings()
        {
            List<Listing> listings = new List<Listing>();

            try
            {
                var builder = ConnectionBuilder.BuildConnection();

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

        public static IEnumerable<CarListing> GetCarListings()
        {
            List<CarListing> listings = new List<CarListing>();

            try
            {
                var builder = ConnectionBuilder.BuildConnection();


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = "SELECT l.id, c.id, c.brand, c.model, c.year, c.mileage, l.price FROM listings l LEFT JOIN cars c ON l.carId = c.id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listings.Add(new CarListing(
                                    reader.GetGuid(0),
                                    reader.GetGuid(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetInt32(4),
                                    reader.GetInt32(5),
                                    reader.GetDecimal(6)
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

        public static Guid AddListing (decimal price, Guid carId)
        {
            try
            {
                var builder = ConnectionBuilder.BuildConnection();


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    Guid id = Guid.NewGuid();

                    String sql = String.Format("INSERT INTO Listings (id, carId, price) VALUES ('{0}', '{1}', {2})",
                        id, carId, price);

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        int q = command.ExecuteNonQuery();

                        if (q != 1)
                            return Guid.Empty;

                        return id;

                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return Guid.Empty;
            }
        }

        public static Guid AddCar(int year, int mileage, string brand, string model)
        {
            try
            {
                var builder = ConnectionBuilder.BuildConnection();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    Guid id = Guid.NewGuid();

                    String sql = String.Format("INSERT INTO Cars (id, year, mileage, brand, model) VALUES ('{0}', {1}, {2}, '{3}', '{4}')",
                        id, year, mileage, brand, model);

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        int q = command.ExecuteNonQuery();

                        if (q != 1)
                            return Guid.Empty;

                        return id;

                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return Guid.Empty;
            }
        }

        public static IEnumerable<Car> GetCars()
        {
            List<Car> cars = new List<Car>();

            //var con = new SqlConnection(

            try
            {
                var builder = ConnectionBuilder.BuildConnection();


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
                return null;
            }
            return cars;
        }

        internal static Car GetCar(Guid id)
        {
            try
            {
                var builder = ConnectionBuilder.BuildConnection();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = String.Format("SELECT id, brand, model, year, mileage FROM cars WHERE id = '{0}'", id.ToString());

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            Car car = new Car(
                                reader.GetGuid(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetInt32(3),
                                reader.GetInt32(4)
                            );

                            return car;

                        }
                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        internal static Listing GetListing(Guid id)
        {
            try
            {
                var builder = ConnectionBuilder.BuildConnection();


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = "SELECT l.id, l.carId, l.price FROM listings l WHERE l.id = '" + id.ToString() + "'";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            Listing listing = new Listing(
                                reader.GetGuid(0),
                                reader.GetGuid(1),
                                reader.GetDecimal(2)
                            );
                            reader.Read();
                            return listing;
                        }
                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        internal static CarListing GetCarListing(Guid id)
        {
            try
            {
                var builder = ConnectionBuilder.BuildConnection();


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = "SELECT l.id, c.id, c.brand, c.model, c.year, c.mileage, l.price FROM listings l LEFT JOIN cars c ON l.carId = c.id AND l.id = '" + id.ToString() + "'";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            CarListing listing = new CarListing(
                                reader.GetGuid(0),
                                reader.GetGuid(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetInt32(4),
                                reader.GetInt32(5),
                                reader.GetDecimal(6)
                            );
                            return listing;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }
    }
}