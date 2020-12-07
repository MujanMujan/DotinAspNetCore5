using Microsoft.EntityFrameworkCore;
using System;
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
            });
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
            ctx.Courses.Where(x => EF.Functions.Collate(x.Title, "Latin1_General_CS_AS") == "HELP")

        }
    }
}
