using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;
using Project.Model.Admin.Operation.ViewTeacher;
using Project.Model.Domain;
using Project.Model.Enums;

namespace Project.Model.Teacher
{
    public class InsertGrade : ITeacherOperationType
    {
        private readonly SchoolContext _context;
        public InsertGrade(SchoolContext schoolContext)
        {
            _context = schoolContext;
        }
        public bool Type()
        {
            Console.WriteLine("Please provide following information to insert grades:");
            Console.Write("Class name:");
            var class_name = Console.ReadLine();
            var class_ = _context.Classes.FirstOrDefault(c => c.Name == class_name);
            if (class_ == null) { Console.WriteLine("Class not found."); return true; }

            Console.Write("Subject name:");
            var subject_name = Console.ReadLine();
            var subject_ = _context.Subjects.FirstOrDefault(s => s.Name == subject_name && s.ClassId == class_.Id);
            if (subject_ == null) { Console.WriteLine("Subject not found in class."); return true; }

            Console.Write("Student name:");
            var student_name = Console.ReadLine();
            var student_ = _context.Students.FirstOrDefault(s => s.Name == student_name && s.ClassId == class_.Id);
            if (student_ == null) { Console.WriteLine("Student not found in class."); return true; }

            Console.Write("Term name (1st, mid, final):");
            var term_name = Console.ReadLine();
            Console.Write("Grade (0.00 to 5.00):");
            if (!double.TryParse(Console.ReadLine(), out var grade_value) || grade_value < 0 || grade_value > 5)
            {
                Console.WriteLine("Invalid grade.");
                return false;
            }

            if (!Enum.TryParse<Term>(term_name, true, out var termParsed))
            {

                termParsed = term_name?.Trim().ToLower() switch
                {
                    "1st" => Term.First,
                    "mid" => Term.Mid,
                    "final" => Term.Final,
                    _ => Term.First
                };
            }

            var existing = _context.Grades
           .FirstOrDefault(g => g.StudentId == student_.Id && g.SubjectId == subject_.Id
            && g.ClassId == class_.Id && g.Term == termParsed);
            if (existing == null)
            {
                var new_grade = new Grade
                {
                    ClassId = class_.Id,
                    SubjectId = subject_.Id,
                    StudentId = student_.Id,
                    Term = termParsed,
                    Score = grade_value
                };

                _context.Grades.Add(new_grade);
            }
            else
            {
                existing.Score = grade_value;
            }
            _context.SaveChanges();
            Console.WriteLine("Grade saved.");
            return true;
        }
    }
}
