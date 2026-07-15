using System;
using System.ComponentModel.DataAnnotations;


namespace Project.Model.Domain
{
    public class TeacherAssignment
    {
        [Required]
        public int TeacherId { get; set; }
        public User Teacher { get; set; } = default!;
        [Required]
        public int ClassId { get; set; }
        public SchoolClass Class { get; set; } = default!;
        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = default!;
    }
}
