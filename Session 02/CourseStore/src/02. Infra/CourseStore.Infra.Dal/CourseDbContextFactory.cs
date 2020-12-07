using Microsoft.EntityFrameworkCore;

namespace CourseStore.Infra.Dal
{
    public class CourseDbContextFactory
    {
        public static CourseDbContext GetSQLCourseContext()
        {
            DbContextOptionsBuilder<CourseDbContext> optionsBuilder = new DbContextOptionsBuilder<CourseDbContext>();
            optionsBuilder.UseSqlServer($"Server=.\\Sql2019; Database=CourseDb;Integrated Security=true ");
               // .UseLazyLoadingProxies();
            return new CourseDbContext(optionsBuilder.Options);
        }
    }
}
