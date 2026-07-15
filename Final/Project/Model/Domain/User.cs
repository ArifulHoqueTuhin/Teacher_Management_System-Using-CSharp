

using System.ComponentModel.DataAnnotations;
using Project.Model.Enums;

namespace Project.Model.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        [Required]
        public UserType Type { get; set; }
        public List<TeacherAssignment> TeachingAssignments { get; set; } = new();
    }
}
