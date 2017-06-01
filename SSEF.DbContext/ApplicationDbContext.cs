using SSEF.Models.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace SSEF.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Instructors> Instructors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        public ApplicationDbContext()
            : base("SSEF-DEV", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}
