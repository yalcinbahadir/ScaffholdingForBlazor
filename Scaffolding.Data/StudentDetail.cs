using System;
using System.Collections.Generic;

#nullable disable

namespace Scaffolding.Data
{
    public partial class StudentDetail
    {
        public int StudentDetailId { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public bool HasScholarship { get; set; }
        public decimal Income { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
