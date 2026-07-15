
using Project.Data;

namespace Project.Model.Admin.Operation.ViewSubject
{
    public class EditSubject : IViewSubjectOperation
    {
        private readonly SchoolContext _context;
        public EditSubject(SchoolContext context)
        {
            _context = context;
        }

        public bool Operation()
        {
            Console.WriteLine("Provide information to edit a subject:");
            Console.Write("Current subject name:");
            var current_name = Console.ReadLine();
            Console.Write("New subject name:");
            var new_name = Console.ReadLine();

            var update_subject = _context.Subjects.FirstOrDefault(c => c.Name == current_name);
            if (update_subject != null)
            {
                update_subject.Name = string.IsNullOrWhiteSpace(new_name) ? "new name is invalid" : new_name;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
