namespace CreateDaoDatabaseClass
{
    using System;
    using CreateDbContextForNorthwind;

    public class Startup
    {
        public static void Main()
        {
            var newCustomer = new Customer
            {
                CustomerID = "test",
                CompanyName = "Royal-Dutsch Shell"
            };

            TestInsertACustomer(newCustomer);

            TestMoodifyCustomer(newCustomer.CustomerID);

            TestDeleteCustomer(newCustomer.CustomerID);
        }

        private static void TestInsertACustomer(Customer newCustomer)
        {
            var newId = CustomersFunctionality.InsertNewCustomer(newCustomer);

            Console.WriteLine("Added new customer with id {0}", newId);
        }

        private static void TestMoodifyCustomer(string customerID)
        {
            CustomersFunctionality.ModifyCustomerCompanyName(customerID, "British Petroleum");

            var updatedCustomer = CustomersFunctionality.GetCustomerById(new NorthwindEntities(), customerID);

            Console.WriteLine("The new company name is {0}", updatedCustomer.CompanyName);
        }

        private static void TestDeleteCustomer(string customerID)
        {
            CustomersFunctionality.DeleteCustomer(customerID);

            var nullCustomer = CustomersFunctionality.GetCustomerById(new NorthwindEntities(), customerID);

            Console.WriteLine("There is no longer a customer with ID {0} - {1} !", customerID, nullCustomer == null ? "True" : "False");
        }
    }
}
