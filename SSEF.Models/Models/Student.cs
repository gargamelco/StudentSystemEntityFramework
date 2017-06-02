using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SSEF.Models.Models
{
    public class Student
    {

        [Key]
        public int ID { get; set; }

        public string Email { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public string Secret { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
