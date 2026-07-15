using Project.Data;
using Project.Model.Admin.Operation.ViewSubject;
using Project.Model.Enums;

namespace Project.Model.Admin.Operation.ViewTeacher
{
    public class ViewTeacher : IAdminOperationType
    {
        private readonly SchoolContext _context;
        private readonly IViewTeacherOptionType _optionType;
        public ViewTeacher(SchoolContext context, IViewTeacherOptionType optionType)
        {
            _context = context;
            _optionType = optionType;
        }

        public bool Type()
        {
            Console.WriteLine("Following teachers are present in the system:");
            var teachers = _context.Users.Where(u => u.Type == UserType.Teacher).ToList();

            if (teachers.Any())
            {
                foreach (var teacher in teachers)
                {
                    Console.WriteLine(teacher.Name);
                }
                Console.WriteLine("What you want to do?");
                var choices = new List<string>
                                    {
                                       "1) Edit teacher",
                                       "2) Delete teacher"
                                    };

                foreach (var item in choices)
                {
                    Console.WriteLine(item);
                }

                Console.Write("\nEnter your choice (1-2): ");
                var choise_option = Console.ReadLine();
                var operation_chose = _optionType.OperationType(choise_option);
                var res = operation_chose.Operation();
                if (res)
                    return true;
                else
                    return false;

            }
            return false;

        }
    }
}

