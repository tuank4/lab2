using System.ComponentModel.DataAnnotations;

namespace lab02.Models
{
    public class StudentCourse
    {
        [Key]

        public Guid StId {  get; set; }
        public Student? Student { get; set; }
        public Guid CId { get; set; }
        public Courses? Courses { get; set; }

    }
}
