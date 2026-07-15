using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;
using Project.Model.Enums;

namespace Project.Model.Admin.Operation.ViewTeacher
{
    public class DeleteTeacher : IViewTeacherOperation
    {
        private readonly SchoolContext _context;
        public DeleteTeacher(SchoolContext context)
        {
            _context = context;
        }
        public bool Operation()
        {
            Console.WriteLine("Provide following information to delete a teacher:");
            Console.Write("Teacher name:");
            var teacher_name = Console.ReadLine();
            var remove_teacher = _context.Users.FirstOrDefault(c => c.Name == teacher_name && c.Type == UserType.Teacher);
            if (remove_teacher != null)
            {
                var assignments = _context.TeacherAssignments
                                  .Where(a => a.TeacherId == remove_teacher.Id)
                                  .ToList();

                if (assignments.Count > 0)
                    _context.TeacherAssignments.RemoveRange(assignments);
                
                _context.Users.Remove(remove_teacher);
                _context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
