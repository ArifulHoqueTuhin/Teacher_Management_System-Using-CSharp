
using Project.Data;

namespace Project.Model.Admin.Operation.ViewClass
{
    public class ViewClass : IAdminOperationType
    {
        private readonly SchoolContext _context;
        private readonly IViewClassOptionType _viewClassOptionType;

        public ViewClass(SchoolContext context, IViewClassOptionType viewClassOptionType)
        {
            _context = context;
            _viewClassOptionType = viewClassOptionType;

        }

        public bool Type()
        {
            Console.WriteLine("Following classes are present in the system:");
            var classes = _context.Classes.ToList();
            if (classes.Any())
            {
                foreach (var item in classes)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("What you want to do?");
                var choices = new List<string>
                                        {
                                           "1) Edit class",
                                           "2) Delete class",
                                           "3) Assign Subject"
                                        };

                foreach (var item in choices)
                {
                    Console.WriteLine(item);
                }

                Console.Write("\nEnter your choice (1-3): ");
                var chose_option = Console.ReadLine();

                var operation_chose = _viewClassOptionType.OptionType(chose_option);
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
