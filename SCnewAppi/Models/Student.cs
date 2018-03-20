using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCnewAppi.Models
{
    public class Student
    {
        public Student() {}

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;  
        }

        public int ID { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
       
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}