using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotin.Session01.HelloEF.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Titile { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
