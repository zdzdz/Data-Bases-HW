

namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Data;
    using Data.Migrations;
    using Models;

    public class Startup
    {
        static void Main()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());

            using (var db = new StudentSystemDbContext())
            {
                var student = new Student
                {
                    FirstName = "Sam",
                    LastName = "Jones",
                    Number = 5203
                };

                var course = new Course
                {
                    Name = "Math",
                    Description = "Stereometrics",
                    Materials = "http://math.com"
                };
                
                var homework = new Homework
                {
                    Content = "Done",
                    TimeSent = new DateTime(2015, 8, 15)
                };

                db.Homeworks.Add(homework);
                student.Courses.Add(course);
                db.Students.Add(student);
                db.Courses.Add(course);
                db.SaveChanges();

                Console.WriteLine(db.Students.Count());
                Console.WriteLine(db.Courses.Count());
            }
        }
    }
}
