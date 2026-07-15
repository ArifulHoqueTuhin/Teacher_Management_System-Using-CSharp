
using Project.Data;
using Project.Model.Domain;

namespace Project.Model.Admin.Operation.ViewSubject
{
    public class AssignTeacher : IViewSubjectOperation
    {
        private readonly SchoolContext _context;
        public AssignTeacher(SchoolContext schoolContext)
        {
            _context = schoolContext;
        }
        public bool Operation()
        {
            Console.WriteLine("Provide following information to assign a teacher:");
            Console.Write("Class name:");
            var class_name = Console.ReadLine();
            Console.Write("Subject name:");
            var suject_name = Console.ReadLine();
            
            Console.Write("Teacher name:");
            var teacher_name = Console.ReadLine();
            var class_ = _context.Classes
            .FirstOrDefault(c => c.Name == class_name);
            if (class_ == null)
            {
                Console.WriteLine("class is not exists");
                return false;
            }

            var subject_ = _context.Subjects
            .FirstOrDefault(c => c.Name == suject_name);
            if (subject_ == null)
            {
                Console.WriteLine("subject is not exists");
                return false;
            }
            var teacher_ = _context.Users
            .FirstOrDefault(c => c.Name == teacher_name);

            if (teacher_ == null)
            {
                Console.WriteLine("teacher is not exists");
                return false;
            }

            var already = _context.TeacherAssignments.Find(teacher_.Id, class_.Id, subject_.Id);
            if (already != null)
            {
                Console.WriteLine("This assignment already exists.");
                return false;
            }
            var class_teacher = new TeacherAssignment
            {
                TeacherId = teacher_.Id,
                ClassId = class_.Id,
                SubjectId = subject_.Id
            };

            _context.TeacherAssignments.Add(class_teacher);
            _context.SaveChanges();
            return true;
        }
    }
}
