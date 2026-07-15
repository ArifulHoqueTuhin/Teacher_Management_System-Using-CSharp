
using System.ComponentModel.DataAnnotations;

namespace Project.Model.Domain
{
    public class SchoolClass
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public List<Subject> Subjects { get; set; } = new();
        public List<TeacherAssignment> TeachingAssignments { get; set; } = new();
        public List<Student> Students { get; set; } = new();
        public List<Grade> Grades { get; set; } = new();
    }
}
