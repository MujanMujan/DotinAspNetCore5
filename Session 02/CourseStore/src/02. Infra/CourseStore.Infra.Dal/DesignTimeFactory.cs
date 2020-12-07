using Microsoft.EntityFrameworkCore.Design;

namespace CourseStore.Infra.Dal
{
    public class DesignTimeFactory : IDesignTimeDbContextFactory<CourseDbContext>
    {
        public CourseDbContext CreateDbContext(string[] args)
        {
            return CourseDbContextFactory.GetSQLCourseContext();
        }
    }
}
