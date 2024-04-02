using lab02.Models;
using lab02.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab02.Controllers
{
    public class CoursesController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class CourseController : ControllerBase
        {
            private readonly ILibraryService _libraryService;

            public CourseController(ILibraryService libraryService)
            {
                _libraryService = libraryService;
            }

            [HttpGet]
            public async Task<IActionResult> GetCourses()
            {
                var authors = await _libraryService.GetCoursesAsync();

                if (authors == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "No authors in database");
                }

                return StatusCode(StatusCodes.Status200OK, authors);
            }

            [HttpGet("id")]
            public async Task<IActionResult> GetCourse(Guid id, bool includeCourses = false)
            {
                Courses courses = await _libraryService.GetCourseAsync(id, includeCourses);

                if (courses == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"No Author found for id: {id}");
                }

                return StatusCode(StatusCodes.Status200OK, courses);
            }

            [HttpPost]
            public async Task<ActionResult<Courses>> AddCourse(Courses courses)
            {
                var dbAuthor = await _libraryService.AddCourseAsync(courses);

                if (dbAuthor == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"{courses.CName} could not be added.");
                }

                return CreatedAtAction("GetCourse", new { id = courses.CId }, courses);
            }

            [HttpPut("id")]
            public async Task<IActionResult> UpdateCourse(Guid id, Courses courses)
            {
                if (id != courses.CId)
                {
                    return BadRequest();
                }

                Courses dbCourse = await _libraryService.UpdateCourseAsync(courses);

                if (dbCourse == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"{courses.CName} could not be updated");
                }

                return NoContent();
            }

            [HttpDelete("id")]
            public async Task<IActionResult> DeleteCourse(Guid id)
            {
                var courses = await _libraryService.GetCourseAsync(id, false);
                (bool status, string message) = await _libraryService.DeleteCourseAsync(courses);

                if (status == false)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, message);
                }

                return StatusCode(StatusCodes.Status200OK, courses);
            }
        }
    }
}