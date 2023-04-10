using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SimpleLMSWebApi.Models;

namespace SimpleLMSWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private static readonly List<Course> courses = new List<Course> {
            new Course { Id = 1, Name = "Math" },
            new Course { Id = 2, Name = "History" },
            new Course { Id = 3, Name = "Science" },
            new Course { Id = 4, Name = "English" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            return courses.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourse(int id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        [HttpPost]
        public ActionResult<Course> AddCourse(Course course)
        {
            if (courses.Any(c => c.Id == course.Id))
            {
                return Conflict();
            }

            courses.Add(course);

            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, Course course)
        {
            var existingCourse = courses.FirstOrDefault(c => c.Id == id);

            if (existingCourse == null)
            {
                return NotFound();
            }

            existingCourse.Name = course.Name;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var courseToRemove = courses.FirstOrDefault(c => c.Id == id);

            if (courseToRemove == null)
            {
                return NotFound();
            }

            courses.Remove(courseToRemove);

            return NoContent();
        }
    }
}

