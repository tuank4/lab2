using lab02.Models;

namespace lab02.Services
{
    public interface ILibraryService
    {
        Task<Courses> AddCourseAsync(Courses courses);
        Task<Student> AddStudentAsync(Student student);
        Task<(bool, string)> DeleteCourseAsync(Courses courses);
        Task<(bool, string)> DeleteStudentAsync(Student student);
        Task<Courses> GetCourseAsync(Guid id, bool includeCourses = false);
        Task<List<Courses>> GetCoursesAsync();
        Task<Student> GetStudentAsync(Guid id, bool includeStudents = false);
        Task<List<Student>> GetStudentsAsync();
        Task<Courses> UpdateCourseAsync(Courses courses);
        Task<Student> UpdateStudentAsync(Student student);
    }
}