using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;

namespace Project.Model.Admin.Operation.ViewClass
{
    public class EditClass : IViewClassOperation
    {
        private readonly SchoolContext _context;
        public EditClass(SchoolContext context)
        {
            _context = context;
        }

        public bool Operation()
        {
            Console.WriteLine("Provide information to edit class:");
            Console.Write("Current class name:");
            var current_name = Console.ReadLine();
            Console.Write("New class name:");
            var new_name = Console.ReadLine();

            var class_update = _context.Classes.FirstOrDefault(c => c.Name == current_name);
            if (class_update != null)
            {
                class_update.Name = new_name != null ? new_name : "invalid namae";
                _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

