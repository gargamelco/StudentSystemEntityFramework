using SSEF.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SSEF.DAL
{
    class UniversityDbInitializer : DropCreateDatabaseIfModelChanges<UniversityDbContext>
    {
        protected override void Seed(UniversityDbContext context)
        {
            var students = new List<Student>
            {
                new Student { FirstName = "Petur",   LastName = "Ivanov",
                    EnrollmentDate = DateTime.Parse("2010-09-01"),Email="student1@gmail.com" },
                new Student { FirstName = "Ivan", LastName = "Petrov",
                    EnrollmentDate = DateTime.Parse("2012-09-01") ,Email="student2@gmail.com"},
                new Student { FirstName = "Georgi",   LastName = "Dimitrov",
                    EnrollmentDate = DateTime.Parse("2013-09-01") ,Email="student3@gmail.com"},
            };


            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var instructors = new List<Instructors>
            {
                new Instructors { FirstName = "Lyuben",     LastName = "Kikov",
                    HireDate = DateTime.Parse("2017-01-11") },
                new Instructors { FirstName = "Troqn",    LastName = "Betuhovski",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructors { FirstName = "Angel",   LastName = "Dimov",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructors { FirstName = "Dimitur", LastName = "Georgiev",
                    HireDate = DateTime.Parse("2001-01-15") }
            };
            instructors.ForEach(s => context.Instructors.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department { Name = "Programming",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Kikov").ID },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Betuhovski").ID },
                new Department { Name = "Philosophy", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Dimov").ID },
                new Department { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Georgiev").ID }
            };
            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course {CourseID = 1050, Title = "ASP.NET",      Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Programming").DepartmentID,
                  Instructors = new List<Instructors>()
                },
                new Course {CourseID = 4022, Title = "LAAG", Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
                  Instructors = new List<Instructors>()
                },
                new Course {CourseID = 4041, Title = "Freud's Theory", Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Philosophy").DepartmentID,
                  Instructors = new List<Instructors>()
                },
                new Course {CourseID = 1045, Title = "Macroeconomics",       Credits = 4,
                  DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID,
                  Instructors = new List<Instructors>()
                }
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseID, s));
            context.SaveChanges();

            var officeAssignments = new List<OfficeAssignment>
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Kikov").ID,
                    Location = "532" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Betuhovski").ID,
                    Location = "437" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Dimov").ID,
                    Location = "327" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Georgiev").ID,
                    Location = "244" },
            };
            officeAssignments.ForEach(s => context.OfficeAssignments.AddOrUpdate(p => p.InstructorID, s));
            context.SaveChanges();

            var course = context.Courses.SingleOrDefault(c => c.Title == "ASP.NET");
            var instance = course.Instructors.SingleOrDefault(i => i.LastName == "Kikov");
            if (instance == null)
                course.Instructors.Add(context.Instructors.Single(i => i.LastName == "Kikov"));
            context.SaveChanges();

            course = context.Courses.SingleOrDefault(c => c.Title == "LAAG");
            instance = course.Instructors.SingleOrDefault(i => i.LastName == "Betuhovski");
            if (instance == null)
                course.Instructors.Add(context.Instructors.Single(i => i.LastName == "Betuhovski"));
            context.SaveChanges();

            course = context.Courses.SingleOrDefault(c => c.Title == "Freud's Theory");
            instance = course.Instructors.SingleOrDefault(i => i.LastName == "Dimov");
            if (instance == null)
                course.Instructors.Add(context.Instructors.Single(i => i.LastName == "Dimov"));
            context.SaveChanges();

            course = context.Courses.SingleOrDefault(c => c.Title == "Macroeconomics");
            instance = course.Instructors.SingleOrDefault(i => i.LastName == "Georgiev");
            if (instance == null)
                course.Instructors.Add(context.Instructors.Single(i => i.LastName == "Georgiev"));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Ivanov").ID,
                    CourseID = courses.Single(c => c.Title == "ASP.NET" ).CourseID,
                    Grade = Grade.A
                },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Petrov").ID,
                    CourseID = courses.Single(c => c.Title == "LAAG" ).CourseID,
                    Grade = Grade.C
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Dimitrov").ID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    Grade = Grade.B
                 }
            };

            foreach (Enrollment enrollment in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                         s.Student.ID == enrollment.StudentID &&
                         s.Course.CourseID == enrollment.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(enrollment);
                }
            }
            context.SaveChanges();
        }

    }
}
