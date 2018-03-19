using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCnewAppi.Models.DTOs
{
    public class CourseDTO
    {
        public CourseDTO() { }

        public CourseDTO(int courseID, string title)
        {
            CourseID = courseID;
            Title = title;
        }

        public int CourseID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<String> StudentsNames { get; set; }

    }
}