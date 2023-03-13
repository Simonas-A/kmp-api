using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace kmp_api.Connections
{
    public static class ListingsDatabase
    {
        public static IEnumerable<Listings> GetListings()
        {
            List<Listings> listings = new List<Listings>();

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
                                listings.Add(new Listings(
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
    }
}
