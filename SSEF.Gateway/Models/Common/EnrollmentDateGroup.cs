using System;
using System.ComponentModel.DataAnnotations;

namespace SSEF.Gateway.Models.Common
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}