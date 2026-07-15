using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Enums;

namespace Project.Model.Domain
{
    public class Grade
    {
        [Required]
        public int Id { get; set; }
        public int ClassId { get; set; }
        [Required]
        public SchoolClass SchoolClass { get; set; } = default!;
        public int StudentId { get; set; }
        [Required]
        public Student Student { get; set; } = default!;
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = default!;
        public double Score { get; set; }
        public Term Term { get; set; } = default!;

    }
}
