namespace RetrievingNumberOfRowsInCertainTable
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    public class Stratup
    {
        private static SqlConnection dbConnection;

        private static void Main()
        {
            EstablishConnectionToDb();
            using (dbConnection)
            {
                var cmd = new SqlCommand("SELECT COUNT(*) FROM Categories", dbConnection);
                int categoriesCount = (int) cmd.ExecuteScalar();
                Console.WriteLine("Rows count: {0}", categoriesCount);
            }
        }

        private static void EstablishConnectionToDb()
        {
            var dbConnectionString = ConfigurationManager.ConnectionStrings["SQLDB"];
            dbConnection = new SqlConnection(dbConnectionString.ConnectionString);
            dbConnection.Open();
        }
    }
}
