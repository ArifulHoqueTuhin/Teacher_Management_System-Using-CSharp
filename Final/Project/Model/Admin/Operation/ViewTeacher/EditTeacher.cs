using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;
using Project.Model.Enums;

namespace Project.Model.Admin.Operation.ViewTeacher
{
    public class EditTeacher : IViewTeacherOperation
    {
        private readonly SchoolContext _context;
        public EditTeacher(SchoolContext context)
        {
            _context = context;
        }

        public bool Operation()
        {
            Console.WriteLine("Provide information to edit a teacher:");
            Console.Write("Current teacher name:");
            var current_name = Console.ReadLine();
            Console.Write("New teacher name:");
            var new_name = Console.ReadLine();

            var update_teacher = _context.Users.FirstOrDefault(c => c.Name == current_name && c.Type == UserType.Teacher);
            if (update_teacher != null)
            {
                update_teacher.Name = string.IsNullOrWhiteSpace(new_name) ? "new name is invalid" : new_name;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
