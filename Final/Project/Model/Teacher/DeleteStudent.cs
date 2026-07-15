
using Project.Data;
using Project.Model.Domain;

namespace Project.Model.Teacher
{
    public class DeleteStudent : ITeacherOperationType
    {
        private readonly SchoolContext _context;
        private readonly User _currentUser;

        public DeleteStudent(SchoolContext schoolContext, User currentUser)
        {
            _context = schoolContext;
            _currentUser = currentUser;
        }

        public bool Type()
        {
            Console.WriteLine("Please provide following information to delete student:");

            Console.Write("Class name: ");
            var class_name = Console.ReadLine();

            Console.Write("Subject name: ");
            var subject_name = Console.ReadLine();

            Console.Write("Student name: ");
            var student_name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(class_name) ||
                string.IsNullOrWhiteSpace(subject_name) ||
                string.IsNullOrWhiteSpace(student_name))
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

            var grades = _context.Grades
                .Where(g => g.StudentId == student.Id)
                .ToList();

            if (grades.Count > 0)
                _context.Grades.RemoveRange(grades);

            _context.Students.Remove(student);
            _context.SaveChanges();

            Console.WriteLine("Student deleted.");
            return true;
        }

    }
}

