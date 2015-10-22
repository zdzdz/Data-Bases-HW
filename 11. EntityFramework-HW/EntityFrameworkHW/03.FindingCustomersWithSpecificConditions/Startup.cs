namespace FindingCustomersWithSpecificConditions
{
    using System;
    using System.Linq;

    using CreateDbContextForNorthwind;

    public class Startup
    {
        public static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                var customers = db.Customers
                    .Join(db.Orders,
                        (c => c.CustomerID),
                        (o => o.CustomerID),
                        (c, o) => new
                        {
                            CustomerName = c.ContactName,
                            OrderYear = o.OrderDate.Value.Year,
                            o.ShipCountry
                        })
                    .ToList()
                    .FindAll(c => c.OrderYear == 1997 && c.ShipCountry == "Canada")
                    .ToList();

                foreach (var cust in customers)
                {
                    Console.WriteLine(cust);
                }
            }
        }
    }
}
