namespace SearchingInATable
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    public class Startup
    {
        private static void Main()
        {
            Console.Write("Please enter a serch word: ");
            var searchWord = Console.ReadLine();

            FindProductByGivenSearchWord(searchWord);
        }

        private static void FindProductByGivenSearchWord(string searchWord)
        {
            var dbConnectionString = ConfigurationManager.ConnectionStrings["SQLDB"];
            using (var dbConnection = new SqlConnection(dbConnectionString.ConnectionString))
            {
                dbConnection.Open();
                var cmd = GetSearchByPatternSqlCommand(dbConnection, searchWord);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productName = reader["ProductName"];
                        Console.WriteLine(" - " + productName);
                    }
                }
            }
        }

        private static SqlCommand GetSearchByPatternSqlCommand(SqlConnection sqlConnection, string pattern)
        {
            var cmd = new SqlCommand(@"SELECT ProductName
                                       FROM Products
                                       WHERE CHARINDEX(@pattern, ProductName) > 0", sqlConnection);
            cmd.Parameters.AddWithValue("@pattern", pattern);
            return cmd;
        }
    }
}
