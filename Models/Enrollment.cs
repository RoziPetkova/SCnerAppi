using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCnewAppi.Models
{
    public class Enrollment
    {
        public Enrollment() { }
        public Enrollment(int studentID, int courseID)
        {
            StudentID = studentID;
            CourseID = courseID;
        }

        public int ID { get; set; }
        [Required]
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        [Required]
        [ForeignKey("Student")]
        public int StudentID { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}