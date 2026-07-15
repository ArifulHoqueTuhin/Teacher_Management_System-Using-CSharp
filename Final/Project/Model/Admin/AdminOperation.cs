using Project.Data;
using Project.Model.Domain;
using Project.Model.UserIdentity;

namespace Project.Model.Admin
{
    public class AdminOperation : IUserOperation
    {
        private readonly AdminOption _adminoption;
        public AdminOperation(AdminOption adminoption)
        {
            _adminoption = adminoption;
        }
        public bool Operation()
        {
            bool isLoggedIn = true;

            while (isLoggedIn)
            {
                Console.WriteLine($"\n Please select an option:");

                var options = new List<string>
                {
                    "1) Create class",
                    "2) Create subject",
                    "3) Create teacher",
                    "4) View classes",
                    "5) View subjects",
                    "6) View teachers",
                    "7) Log out"
                };

                foreach (var item in options)
                {
                    Console.WriteLine(item);
                }

                Console.Write("\nEnter your choice (1-7): ");
                var optionChoose = Console.ReadLine();

                if (optionChoose == "7")
                {
                    Console.WriteLine("Logging out...");
                    isLoggedIn = false;
                    return false;
                }

                var operationType = _adminoption.OperationType(optionChoose);

                var result = operationType.Type();

                if (result)
                {
                    Console.WriteLine("Operation completed successfully.\n");
                }
                else
                {
                    Console.WriteLine("Operation failed or was cancelled.\n");
                }

                
            }

            return true;
        }
    }
    
}
