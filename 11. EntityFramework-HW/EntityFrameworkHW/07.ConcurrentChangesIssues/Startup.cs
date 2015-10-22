namespace ConcurrentChangesIssues
{
    using System;
    using System.Linq;

    using CreateDbContextForNorthwind;

    public class Startup
    {
        /// <summary>
        /// Problem solved by only using only one connection or introducing transactions isolation levels
        /// </summary>
        public static void Main()
        {
            var firstConection = new NorthwindEntities();
            var secondConection = new NorthwindEntities();

            var customerFromFirstCon = firstConection.Customers.First();
            var customerFromSecondCon = secondConection.Customers.First();

            Console.WriteLine("Inital Name FisrtCon: {0} - SecondCon: {1}", customerFromFirstCon.CompanyName, customerFromSecondCon.CompanyName);

            customerFromFirstCon.CompanyName = "Mercedes";

            customerFromSecondCon.CompanyName = "Jaguar";

            firstConection.SaveChanges();
            secondConection.SaveChanges();

            var result = new NorthwindEntities().Customers.First();
            Console.WriteLine("Name After Change {0}", result.CompanyName);
        }
    }
}
