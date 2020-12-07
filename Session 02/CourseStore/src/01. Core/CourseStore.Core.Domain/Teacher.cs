using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseStore.Core.Domain
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{ FirstName}, {LastName}";
            }
        }
        public List<CourseTeacher> Courses { get; set; }
    }
}
