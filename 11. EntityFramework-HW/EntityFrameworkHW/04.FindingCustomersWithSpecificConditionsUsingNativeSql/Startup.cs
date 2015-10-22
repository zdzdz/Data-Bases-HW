namespace FindingCustomersWithSpecificConditionsUsingNativeSql
{
    using System;

    using CreateDbContextForNorthwind;

    public class Startup
    {
        public static void Main()
        {
            const string nativeSqlQuery =
                "SELECT c.ContactName AS [Customer], o.OrderDate [Order Year], o.ShipCountry " +
                "FROM Customers c " +
                "JOIN Orders o " +
                "ON c.CustomerID = o.CustomerID " +
                "WHERE YEAR(o.OrderDate) = 1997 AND o.ShipCountry = 'Canada'";

            using (var db = new NorthwindEntities())
            {
                var customers = db.Database.SqlQuery<View>(nativeSqlQuery);
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }
        }
    }
}
