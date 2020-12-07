using System;
using System.Collections.Generic;

namespace CourseStore.Core.Domain
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime StartDate { get; set; }
        //public virtual Discount Discount { get; set; }
        //public virtual ICollection<CourseTeacher> Teachers { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }
        //public virtual ICollection<Tag> Tags { get; set; }

        public  Discount Discount { get; set; }
        public  ICollection<CourseTeacher> Teachers { get; set; }
        public  ICollection<Comment> Comments { get; set; }
        public  ICollection<Tag> Tags { get; set; }

    }
}
