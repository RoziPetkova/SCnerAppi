using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCnewAppi.Models
{
    public class Course
    {
        public Course() {}

        public Course(int courseID, string title)
        {
            CourseID = courseID;
            Title = title;
        }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        [Required]
        public string Title { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}