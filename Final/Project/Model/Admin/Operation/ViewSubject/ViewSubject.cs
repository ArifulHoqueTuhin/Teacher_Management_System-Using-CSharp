using System;
using System.Collections.Generic;
using System.Linq;

using Project.Data;

namespace Project.Model.Admin.Operation.ViewSubject
{
    public class ViewSubject : IAdminOperationType
    {
        private readonly SchoolContext _context;
        private readonly IViewSubjectOptionType _viewSubjectOptionType;
        
        public ViewSubject(SchoolContext context, IViewSubjectOptionType viewSubjectOptionType)
        {
            _context = context;
            _viewSubjectOptionType = viewSubjectOptionType;
            
        }
        public bool Type()
        {
            Console.WriteLine("Following subjects are present in the system:");
            var subjects = _context.Subjects.ToList();
            if (subjects.Any())
            {
                foreach (var item in subjects)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine("What you want to do?");
                var choices = new List<string>
                        {
                           "1) Edit subject",
                           "2) Delete subject",
                           "3) Assign teacher"
                        };

                foreach (var item in choices)
                {
                    Console.WriteLine(item);
                }

                Console.Write("\nEnter your choice (1-3): ");
                var option_chose = Console.ReadLine();
                var operation_chose = _viewSubjectOptionType.OptionType(option_chose);
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
