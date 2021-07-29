using System;
using System.Collections.Generic;

#nullable disable

namespace Scaffolding.Data
{
    public partial class Location
    {
        public Location()
        {
            Departments = new HashSet<Department>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; }
        public int Distance { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
