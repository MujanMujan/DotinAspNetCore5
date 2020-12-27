using CourseStore.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseStore.Infra.Dal
{
    public class DataClass
    {
        public static void LoadEager01()
        {
            using var ctx = CourseDbContextFactory.GetSQLCourseContext();

            var data = ctx.Courses.Where(c => c.Price > 100)
                .Include(c => c.Discount)
                .Include(c => c.Comments.Take(10))
                .Include(c => c.Teachers).ThenInclude(c => c.Teacher)
                .Include(c => c.Tags).ToList();

        }

        public static void LoadExplicti01()
        {
            using var ctx = CourseDbContextFactory.GetSQLCourseContext();
            var courses = ctx.Courses.Where(c => c.Price > 100).ToList();

            foreach (var course in courses)
            {
                ctx.Entry(course).Reference(c => c.Discount).Load();
                ctx.Entry(course).Collection(c => c.Comments).Query();
            }
        }

        public static void LoadSelection()
        {

            using var ctx = CourseDbContextFactory.GetSQLCourseContext();
            var result = ctx.Courses.Select(c => new
            {
                c.CourseId,
                c.Title,
                commentCount = c.Comments.Count,
            }).ToList();
        }

        public static void voidClientVsServer()
        {
            using var ctx = CourseDbContextFactory.GetSQLCourseContext();
            //ctx.Teachers.OrderBy(c => c.FullName).Take(10); Error

            var course = ctx.Courses.Select(c => new
            {
                c.Title,
                TagsString = string.Join(',', c.Tags.Select(t=>t.Title))
            });
        }

        public static void Collate()
        {
            using var ctx = CourseDbContextFactory.GetSQLCourseContext();
            ctx.Courses.Where(x => EF.Functions.Collate(x.Title, "Latin1_General_CS_AS") == "HELP");

        }

        public static void SeedData()
        {
            using var ctx = CourseDbContextFactory.GetSQLCourseContext();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var course01 = new Course()
            {
                Title = "Pro ASP.NET 5",
                Description = "Advanced Course About .NET 5 Platform",
                Price = 12_000_000,
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        CommentBy = "Mr. Alaki",
                        CommentText = "It's Nice!"
                    },
                    new Comment()
                    {
                        CommentBy = "Ms. Palaki",
                        CommentText = "Wow! Amazing!"
                    }
                },
                StartDate = DateTime.Now
            };

            var course02 = new Course()
            {
                Title = "DevOps in Action",
                Description = "Advanced Course About DevOps World!",
                Price = 120_000_000,
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        CommentBy = "Mr. Alaki",
                        CommentText = "Nice course about devops!"
                    },
                    new Comment()
                    {
                        CommentBy = "Ms. Palaki",
                        CommentText = "Wonderful!"
                    }
                },
                StartDate = DateTime.Now
            };

            var teacher01 = new Teacher()
            {
                FirstName = "Alireza",
                LastName = "Oroumand",
            };

            var teacher02 = new Teacher()
            {
                FirstName = "Mohamad",
                LastName = "Abbasi",
            };

            var tag01 = new Tag()
            {
                Title = "programming",
                Courses = new List<Course>()
                {
                    course01
                }
            };
            var tag02 = new Tag()
            {
                Title = "infrastructure",
                Courses = new List<Course>()
                {
                    course02
                }
            };
            var courseTeacher01 = new CourseTeacher()
            {
                Course = course01,
                Teacher = teacher01
            };
            var courseTeacher02 = new CourseTeacher()
            {
                Course = course02,
                Teacher = teacher02
            };
            ctx.Add(course01);
            ctx.Add(course02);
            ctx.Add(teacher01);
            ctx.Add(teacher02);
            ctx.Add(courseTeacher01);
            ctx.Add(courseTeacher02);
            ctx.Add(tag01);
            ctx.Add(tag02);
            ctx.SaveChanges();
        }
    }
}
