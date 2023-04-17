using Microsoft.Data.SqlClient;

namespace kmp_api.Connections
{
    public static class ConnectionBuilder
    {
        public static SqlConnectionStringBuilder BuildConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "mysqlserver9798.database.windows.net";
            builder.UserID = "azureuser";
            builder.Password = "mypassword123?";
            builder.InitialCatalog = "mySampleDatabase";
            return builder;
        }
    }
}
