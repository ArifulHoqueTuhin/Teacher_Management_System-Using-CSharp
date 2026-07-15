using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int ClassId { get; set; }
        public SchoolClass Class { get; set; } = default!;
        public List<Grade> Grades { get; set; } = new();

    }
}
