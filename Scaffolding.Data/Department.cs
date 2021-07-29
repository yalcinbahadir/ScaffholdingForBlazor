using System;
using System.Collections.Generic;

#nullable disable

namespace Scaffolding.Data
{
    public partial class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
