using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SCnewAppi.DAL;
using SCnewAppi.Models;
using SCnewAppi.Models.DTOs;

namespace SCnewAppi.Controllers
{
    public class CoursesController : ApiController
    {
        private DBServices dbs = DBServices.getInstance();

        // GET: api/Courses
        public HttpResponseMessage GetCourses()
        {
            return Request.CreateResponse<IEnumerable<CourseDTO>>(HttpStatusCode.OK, dbs.GetAllCourses());
        }

        // GET: api/Courses/5
        [ResponseType(typeof(CourseDTO))]
        public IHttpActionResult GetCourse(int id)
        {
            CourseDTO course = dbs.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // PUT: api/Courses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourse(int id, Course course)
        {
            if (!ModelState.IsValid || course == null)
            {
                return BadRequest(ModelState);
            }

            if (id != course.CourseID)
            {
                return BadRequest();
            }

            CourseDTO addet = dbs.EditCourse(course);

            if (addet != null)
            {
                return Ok(addet);
            }
            else
            {
                return InternalServerError();
            }
        }

        // POST: api/Courses
        [ResponseType(typeof(CourseDTO))]
        public IHttpActionResult PostCourse(Course course)
        {
            if (!ModelState.IsValid || course == null)
            {
                return BadRequest(ModelState);
            }

            CourseDTO addet = dbs.AddCourse(course);

            if (addet != null)
            {
                CreatedAtRoute("DefaultApi", new { id = addet.CourseID }, addet);
                return Ok(addet);
            }
            else
            {
                return InternalServerError();
            }

        }

        // DELETE: api/Courses/5
        [ResponseType(typeof(CourseDTO))]
        public IHttpActionResult DeleteCourse(int id)
        {

            CourseDTO course = dbs.GetCourse(id);
            if (dbs.DeleteCourse(id) == null)
            {
                return NotFound();
            }

            return Ok(course);
        }
    }
}