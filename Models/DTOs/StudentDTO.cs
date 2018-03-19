using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCnewAppi.Models
{
    public class StudentDTO
    {
        public StudentDTO() { }

        public StudentDTO(string firstName, string lastName, List<Enrollment> enrollments)
        {
            FirstName = firstName;
            LastName = lastName;

        }

        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public virtual ICollection<String> CoursesNames { get; set; }
    }
}