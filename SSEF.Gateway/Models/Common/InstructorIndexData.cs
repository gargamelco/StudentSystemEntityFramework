using SSEF.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSEF.Gateway.Models.Common
{
    public class InstructorIndexData
    {
        public IEnumerable<Instructors> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}