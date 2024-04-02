using lab02.Models;
using lab02.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab02.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class StudentController : ControllerBase
        {
            private readonly ILibraryService _libraryService;

            public StudentController(ILibraryService libraryService)
            {
                _libraryService = libraryService;
            }

            [HttpGet]
            public async Task<IActionResult> GetStudents()
            {
                var students = await _libraryService.GetStudentsAsync();

                if (students == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "No authors in database");
                }

                return StatusCode(StatusCodes.Status200OK, students);
            }

            [HttpGet("id")]
            public async Task<IActionResult> GetStudent(Guid id, bool includeStudents = false)
            {
                Student student = await _libraryService.GetStudentAsync(id, includeStudents);

                if (student == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"No Author found for id: {id}");
                }

                return StatusCode(StatusCodes.Status200OK, student);
            }

            [HttpPost]
            public async Task<ActionResult<Student>> AddStudent(Student student)
            {
                var dbStudent = await _libraryService.AddStudentAsync(student);

                if (dbStudent == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"{student.Name} could not be added.");
                }

                return CreatedAtAction("GetStudent", new { id = student.StId }, student);
            }

            [HttpPut("id")]
            public async Task<IActionResult> UpdateStudent(Guid id, Student student)
            {
                if (id != student.StId)
                {
                    return BadRequest();
                }

                Student dbStudent = await _libraryService.UpdateStudentAsync(student);

                if (dbStudent == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"{student.Name} could not be updated");
                }

                return NoContent();
            }

            [HttpDelete("id")]
            public async Task<IActionResult> DeleteStudent(Guid id)
            {
                var student = await _libraryService.GetStudentAsync(id, false);
                (bool status, string message) = await _libraryService.DeleteStudentAsync(student);

                if (status == false)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, message);
                }

                return StatusCode(StatusCodes.Status200OK, student);
            }
        }
    }