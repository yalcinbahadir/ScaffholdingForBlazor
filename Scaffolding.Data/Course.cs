using System;
using System.Collections.Generic;

#nullable disable

namespace Scaffolding.Data
{
    public partial class Course
    {
        public Course()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }
        public int StudyPoints { get; set; }
        public int Treshold { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
