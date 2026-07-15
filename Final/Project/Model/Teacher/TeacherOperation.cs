using Project.Data;
using Project.Model.Domain;
using Project.Model.UserIdentity;

namespace Project.Model.Teacher
{
    public class TeacherOperation : IUserOperation
    {
        private readonly SchoolContext _context;
        private readonly ITeacherOption _teacherOption;
        private readonly User _user;
        public TeacherOperation(SchoolContext schoolContext, ITeacherOption teacherOption, User user)
        {
            _context = schoolContext;
            _teacherOption = teacherOption;
            _user = user;
        }

        public bool Operation()
        {
            bool isLoggedIn = true;

            while (isLoggedIn)
            {
                Console.WriteLine($"\n please select an option:");

                var choices = new List<string>
                {
                    "1) View grades",
                    "2) Insert grades",
                    "3) Add students",
                    "4) Edit students",
                    "5) Delete students",
                    "6) Log out"
                };

                foreach (var item in choices)
                {
                    Console.WriteLine(item);
                }

                Console.Write("\nEnter your choice (1-4): ");
                var chose_option = Console.ReadLine();

                if (chose_option == "4")
                {
                    Console.WriteLine("Logging out...");
                    isLoggedIn = false; 
                    return false;
                }

                
                var operationType = _teacherOption.OperationType(chose_option);
                var result = operationType.Type();

                if (!result)
                {
                    Console.WriteLine("Operation failed or cancelled.");
                }
                else
                {
                    Console.WriteLine("Operation completed successfully.");
                }
                
            }

            return true;
        }
    }
    
}
