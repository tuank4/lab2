using lab02.Data;
using lab02.Models;
using Microsoft.EntityFrameworkCore;



namespace lab02.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly AppDbContext _db;

        public LibraryService(AppDbContext db)
        {
            _db = db;
        }

        #region Authors

        public async Task<List<Courses>> GetCoursesAsync()
        {
            try
            {
                return await _db.Courses.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Courses> GetCourseAsync(Guid id, bool includeCourses)
        {
            try
            {
                if (includeCourses) // books should be included
                {
                    return await _db.Courses.Include(b => b.StudentCourses)
                        .FirstOrDefaultAsync(i => i.CId == id);
                }

                // Books should be excluded
                return await _db.Courses.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Courses> AddCourseAsync(Courses courses)
        {
            try
            {
                await _db.Courses.AddAsync(courses);
                await _db.SaveChangesAsync();
                return await _db.Courses.FindAsync(courses.CId); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Courses> UpdateCourseAsync(Courses courses)
        {
            try
            {
                _db.Entry(courses).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return courses;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteCourseAsync(Courses courses)
        {
            try
            {
                var dbAuthor = await _db.Courses.FindAsync(courses.CId);

                if (dbAuthor == null)
                {
                    return (false, "Author could not be found");
                }

                _db.Courses.Remove(courses);
                await _db.SaveChangesAsync();

                return (true, "Author got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion Authors

        #region Books

        public async Task<List<Student>> GetStudentsAsync()
        {
            try
            {
                return await _db.Students.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Student> GetStudentAsync(Guid id, bool includeStudents)
        {
            try
            {
                return await _db.Students.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            try
            {
                await _db.Students.AddAsync(student);
                await _db.SaveChangesAsync();
                return await _db.Students.FindAsync(student.StId); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            try
            {
                _db.Entry(student).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return student;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteStudentAsync(Student student)
        {
            try
            {
                var dbBook = await _db.Students.FindAsync(student.StId);

                if (dbBook == null)
                {
                    return (false, "Book could not be found.");
                }

                _db.Students.Remove(student);
                await _db.SaveChangesAsync();

                return (true, "Book got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion Books
    }
}