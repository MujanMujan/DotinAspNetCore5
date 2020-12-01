using Dotin.Session01.HelloEF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Dotin.Session01.HelloEF.DataLayer
{
    public class DataClass
    {
        public static void CreateDatabase()
        {
            using var dbContext = new HelloEfDbContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            dbContext.Courses.Add(new Course
            {
                Teacher = new Teacher
                {
                    FirstName = "Alireza",
                    LastNAme = "Oroumand"
                },
                Titile = "Pro ASP.NET Core 5"
            });


            dbContext.Courses.Add(new Course
            {
                Teacher = new Teacher
                {
                    FirstName = "Mohammad",
                    LastNAme = "Abbasi"
                },
                Titile = "Linux For Developers"
            });

            dbContext.SaveChanges();
        }

        public static void ReadAllData()
        {
            using var dbContext = new HelloEfDbContext();
            var query = dbContext.Courses.Include(c => c.Teacher).AsNoTracking();
            var queryString = query.ToQueryString();

            System.Console.WriteLine(queryString);
            System.Console.WriteLine();

            foreach (var item in query.ToList())
            {
                System.Console.WriteLine($"{item.CourseId}: {item.Titile} -- {item.Teacher.FirstName} {item.Teacher.LastNAme}");
            }
            System.Console.ReadLine();

        }

        public static void UpdateCourse(int courseId)
        {
            using var dbContext = new HelloEfDbContext();
            var course = dbContext.Courses.Include(c => c.Teacher).FirstOrDefault(c=>c.CourseId == courseId);

            course.Titile = $"{course.Titile} {DateTime.Now.Ticks}";
            course.Teacher.FirstName = $"{course.Teacher.FirstName} {DateTime.Now.Ticks}";
            dbContext.SaveChanges();
            System.Console.ReadLine();

        }
    }
}
