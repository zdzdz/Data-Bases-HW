namespace RetrievingCategoriesNameAndDescriptionInCertainTable
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    public class Program
    {
        private static SqlConnection dbConnection;

        static void Main()
        {
            EstablishConnectionToDb();
            using (dbConnection)
            {
                var cmd = new SqlCommand("SELECT * FROM Categories", dbConnection);
                ExecuteSqlDataReader(cmd);
            }
        }

        private static void ExecuteSqlDataReader(SqlCommand cmd)
        {
            var reader = cmd.ExecuteReader();
            using (reader)
            {
                Console.WriteLine("CATEGORIES:");
                while (reader.Read())
                {
                    var categoryName = (string)reader["CategoryName"];
                    var categoryDescription = (string)reader["Description"];
                    Console.WriteLine(" * Category Name: {0}", categoryName);
                    Console.WriteLine(" * Category Description: {0}", categoryDescription);
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
