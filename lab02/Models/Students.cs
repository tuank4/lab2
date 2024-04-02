using System.ComponentModel.DataAnnotations;

namespace lab02.Models
{
    public class Student
    {
        [Key]
        public Guid StId { get; set; }
       public string? Name {  get; set; }

        public List<StudentCourse>? StudentCourses { get; set; }

    }
}
