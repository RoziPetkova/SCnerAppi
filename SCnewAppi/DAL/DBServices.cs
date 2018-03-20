using SCnewAppi.Models;
using SCnewAppi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;


namespace SCnewAppi.DAL
{
    public class DBServices
    {
        private static DBServices instance;
        private DataBaseContext db;
        private DTOConvertor convertor;

        private DBServices()
        {
            this.db = new DataBaseContext();
            this.convertor = new DTOConvertor();
        }

        public static DBServices getInstance()
        {
            if (instance == null)
            {
                instance = new DBServices();
            }
            return instance;
        }

        public CourseDTO GetCourse(int id)
        {
            return convertor.courseConvertor(db.Courses.Find(id));
        }

        public List<CourseDTO> GetAllCourses()
        {
            return db.Courses.ToList().Select(c => convertor.courseConvertor(c)).ToList();
        }

        public Student getStudent(int id)
        {
            return db.Students.Find(id);
        }

        public List<Student> GetAllStudents()
        {
            return db.Students.ToList();
        }

        public CourseDTO AddCourse(Course course)
        {

            if (db.Courses.Any(x => x.CourseID == course.CourseID))
            {
                return null;
            }

            try
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return convertor.courseConvertor(course);
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public CourseDTO EditCourse(Course course)
        {
            try
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return convertor.courseConvertor(course);
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public void CreateNewStudent(String firstName, String lastName, DateTime enrollmentDate)
        {
            db.Students.Add(new Student(firstName, lastName));
            db.SaveChanges();
        }

        public void StudentEnrollourse(int studentID, int courseID)
        {
            db.Enrollments.Add(new Enrollment(studentID, courseID));
            db.SaveChanges();
        }

        public bool DeleteStudent(int studentID)
        {
            Student student = db.Students.Find(studentID);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public CourseDTO DeleteCourse(int courseID)
        {
            Course course = db.Courses.Find(courseID);
            if (course != null)
            {
                db.Courses.Remove(course);
                db.SaveChanges();
                return convertor.courseConvertor(course);
            }
            else
            {
                return null;
            }
        }

        public bool EditStudent(int studentID, String firstName, String lastName)
        {
            Student student = db.Students.Find(studentID);

            if (student != null)
            {
                student.FirstName = firstName;
                student.LastName = lastName;
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}