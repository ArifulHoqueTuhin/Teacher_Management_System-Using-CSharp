using Project.Data;
using Project.Model.Admin;
using Project.Model.Domain;

namespace Project.Model.Admin.Operation
{
    public class CreateSubject : IAdminOperationType
    {
        private readonly SchoolContext _context;
        public CreateSubject(SchoolContext context)
        {
            _context = context;
        }
        public bool Type()
        {
            Console.WriteLine("Please provide a following information to create a new subject :");
            Console.Write("Subject name :");
            var subjectname = Console.ReadLine();
            Console.Write("Class name :");
            var classNameForSubject = Console.ReadLine();

            var targetClass = _context.Classes.FirstOrDefault(c => c.Name == classNameForSubject);
            if (targetClass == null)
            {
                Console.WriteLine("Class not found. Create the class first.");
                return false;
            }
            var newsubject = new Subject
            {
                Name = string.IsNullOrWhiteSpace(subjectname) ? "Invalid Subject" : subjectname,
                ClassId = targetClass.Id
            };
            _context.Subjects.Add(newsubject);
            _context.SaveChanges();
            Console.WriteLine("Subject created and attached to class.");
            return true;
        }
    }
}
