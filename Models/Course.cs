using System;
using System.Collections.Generic;

namespace WebApplication16.Models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string? Name { get; set; }
        public int? Credits { get; set; }
    }
}
