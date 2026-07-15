using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;
using Project.Model.Domain;

namespace Project.Model.Teacher
{
    public class EditStudent : ITeacherOperationType
    {
        private readonly SchoolContext _context;
        private readonly User _currentUser;

        public EditStudent(SchoolContext schoolContext, User currentUser)
        {
            _context = schoolContext;
            _currentUser = currentUser;
        }

        public bool Type()
        {
            Console.WriteLine("Please provide following information to edit student:");
            Console.Write("Class name: ");
            var class_name = Console.ReadLine();

            Console.Write("Subject name: ");
            var subject_name = Console.ReadLine();

            Console.Write("Current student name: ");
            var student_name = Console.ReadLine();

            Console.Write("New student name: ");
            var new_name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(class_name) ||
                string.IsNullOrWhiteSpace(subject_name) ||
                string.IsNullOrWhiteSpace(student_name) ||
                string.IsNullOrWhiteSpace(new_name))
            {
                Console.WriteLine("Invalid input.");
                return true;
            }

           
            var _class = _context.Classes
                .FirstOrDefault(c => c.Name == class_name);
            if (_class == null)
            {
                Console.WriteLine("Class not found.");
                return true;
            }

            
            var subject = _context.Subjects
                .FirstOrDefault(s => s.Name == subject_name
                                  && s.ClassId == _class.Id);
            if (subject == null)
            {
                Console.WriteLine("Subject not found in the specified class.");
                return true;
            }

            
            var isAssigned = _context.TeacherAssignments
                .Any(a => a.TeacherId == _currentUser.Id
                       && a.ClassId == _class.Id
                       && a.SubjectId == subject.Id);

            if (!isAssigned)
            {
                Console.WriteLine("You are not assigned to this Class + Subject.");
                return true;
            }

            
            var student = _context.Students
                .FirstOrDefault(s => s.ClassId == _class.Id
                                  && s.Name == student_name);

            if (student == null)
            {
                Console.WriteLine("Student not found in this class.");
                return true;
            }

            
            var duplicate = _context.Students
                .Any(s => s.ClassId == _class.Id
                       && s.Name == new_name);

            if (duplicate)
            {
                Console.WriteLine("A student with the new name already exists in this class.");
                return true;
            }

            
            student.Name = new_name;
            _context.SaveChanges();

            Console.WriteLine($"Student '{student_name}' has been renamed to '{new_name}'.");
            return true;
        }

    }

}
