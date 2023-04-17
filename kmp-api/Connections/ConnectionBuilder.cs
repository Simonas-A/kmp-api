using Microsoft.Data.SqlClient;

namespace kmp_api.Connections
{
    public static class ConnectionBuilder
    {
        public static SqlConnectionStringBuilder BuildConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "";
            builder.UserID = "";
            builder.Password = "";
            builder.InitialCatalog = "";
            return builder;
        }
    }
}
