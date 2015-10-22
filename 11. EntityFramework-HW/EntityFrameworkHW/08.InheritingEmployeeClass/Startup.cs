namespace InheritingEmployeeClass
{
    using System;
    using System.Data.Linq;
    using System.Linq;

    using CreateDbContextForNorthwind;

    public class Startup
    {
        public static void Main()
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                var employee = northwindEntities.Employees.First();

                // The new model for the Employee is in 01.CreateDbContextForNorthwind
                // in the file EmployeeExtended.cs
                EntitySet<Territory> territories = employee.TerritoriesSet;

                Console.WriteLine("All territories for employee {0} are:", employee.FirstName);

                foreach (var territory in territories)
                {
                    Console.WriteLine(territory.TerritoryDescription);
                }
            }
        }
    }
}
