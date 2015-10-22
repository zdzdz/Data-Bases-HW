namespace CreateDbContextForNorthwind
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                var categories = db.Categories.Count();

                Console.WriteLine(categories);
            }
        }
    }
}
