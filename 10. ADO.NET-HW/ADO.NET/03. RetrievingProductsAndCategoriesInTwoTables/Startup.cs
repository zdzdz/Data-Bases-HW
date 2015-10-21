namespace RetrievingProductsAndCategoriesInTwoTables
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    class Startup
    {
        private static SqlConnection dbConnection;

        private static void Main()
        {
            EstablishConnectionToDb();
            using (dbConnection)
            {
                var cmd = new SqlCommand(@"SELECT p.ProductName AS [Product], c.CategoryName AS [Category]
                                           FROM Products p
                                           JOIN Categories c
                                           ON p.CategoryID = c.CategoryID", dbConnection);
                ExecuteSqlDataReader(cmd);
            }
        }

        private static void ExecuteSqlDataReader(SqlCommand cmd)
        {
            var reader = cmd.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    var product = (string)reader["Product"];
                    var category = (string)reader["Category"];
                    Console.WriteLine("Product : {0}, Category: {1}", product, category);
                    Console.WriteLine(new string('-', 70));
                }
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
