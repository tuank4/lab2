using System.ComponentModel.DataAnnotations;

namespace lab02.Models
{
    public class Courses
    { 
            [Key]
            public Guid CId { get; set; }
            public string? CName { get; set; }
            public string? Desciption { get; set; }

           
            public List<StudentCourse>? StudentCourses { get; set; }
    }
}
