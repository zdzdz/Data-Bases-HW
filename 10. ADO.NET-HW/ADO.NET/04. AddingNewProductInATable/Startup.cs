namespace AddingNewProductInATable
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    public class Startup
    {
        private static SqlConnection dbConnection;

        private static void Main()
        {
            EstablishConnectionToDb();
            using (dbConnection)
            {
                var cmdInsertProduct = new SqlCommand(@"INSERT INTO Products 
                                                        VALUES (@name, @supplierId, @categoryId, 
                                                                @quantityPerUnit, @unitPrice, 
                                                                @unitsInStock, @unitsInOrder, 
                                                                @reorderLevel, @discontinued)", dbConnection);
                ExecuteNonQueryAddingParametersWithValues(cmdInsertProduct);

                var insertedRecordId = GetInsertedRecordId();
                Console.WriteLine("New ProductID: {0}", insertedRecordId);
            }
        }

        private static int GetInsertedRecordId()
        {
            var cmdSelectIdentity = new SqlCommand("SELECT @@IDENTITY", dbConnection);
            var insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();
            return insertedRecordId;
        }

        private static void ExecuteNonQueryAddingParametersWithValues(SqlCommand cmdInsertProduct)
        {
            cmdInsertProduct.Parameters.AddWithValue("@name", "Xylitol");
            cmdInsertProduct.Parameters.AddWithValue("@supplierId", "1");
            cmdInsertProduct.Parameters.AddWithValue("@categoryId", "1");
            cmdInsertProduct.Parameters.AddWithValue("@quantityPerUnit", "20 boxes x 10 bags");
            cmdInsertProduct.Parameters.AddWithValue("@unitPrice", "15.00");
            cmdInsertProduct.Parameters.AddWithValue("@unitsInStock", "100");
            cmdInsertProduct.Parameters.AddWithValue("@unitsInOrder", "27");
            cmdInsertProduct.Parameters.AddWithValue("@reorderLevel", "10");
            cmdInsertProduct.Parameters.AddWithValue("@discontinued", "1");
            cmdInsertProduct.ExecuteNonQuery();
        }

        private static void EstablishConnectionToDb()
        {
            var dbConnectionString = ConfigurationManager.ConnectionStrings["SQLDB"];
            dbConnection = new SqlConnection(dbConnectionString.ConnectionString);
            dbConnection.Open();
        }
    }
}
