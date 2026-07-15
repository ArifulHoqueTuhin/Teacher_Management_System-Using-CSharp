using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Domain
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int ClassId { get; set; }
        public SchoolClass Class { get; set; } = default!;
        public List<TeacherAssignment> TeachingAssignments { get; set; } = new();
        public List<Grade> Grades { get; set; } = new();
    }
}
