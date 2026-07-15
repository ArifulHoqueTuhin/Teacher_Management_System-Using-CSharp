using System;
using System.Collections.Generic;
using System.Linq;

using Project.Data;

namespace Project.Model.Admin.Operation.ViewClass
{
    public class DeleteClass : IViewClassOperation
    {
        private readonly SchoolContext _context;
        public DeleteClass(SchoolContext context)
        {
            _context = context;
        }

        public bool Operation()
        {
            Console.WriteLine("Provide information to delete class:");
            Console.Write("Class name:");
            var class_name = Console.ReadLine();
            var remove_class = _context.Classes.FirstOrDefault(c => c.Name == class_name);
            if (remove_class != null)
            {
                var assignments = _context.TeacherAssignments
                                  .Where(a => a.ClassId == remove_class.Id)
                                  .ToList();

                if (assignments.Count > 0)
                    _context.TeacherAssignments.RemoveRange(assignments);

                _context.Classes.Remove(remove_class);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}