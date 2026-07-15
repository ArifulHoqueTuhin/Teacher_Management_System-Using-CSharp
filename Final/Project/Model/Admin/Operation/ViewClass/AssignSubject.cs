using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;
using Project.Model.Domain;

namespace Project.Model.Admin.Operation.ViewClass
{
    public class AssignSubject : IViewClassOperation
    {
        private readonly SchoolContext _context;
        public AssignSubject(SchoolContext context)
        {
            _context = context;
        }

        public bool Operation()
        {
            Console.WriteLine("Provide information to assign a subject to class:");
            Console.Write("Class name:");
            var class_name = Console.ReadLine();
            Console.Write("Subject name:");
            var subject_name = Console.ReadLine();
            var class_ = _context.Classes
            .FirstOrDefault(c => c.Name == class_name);
            if (class_ != null)
            {
                var new_subject = new Subject
                {
                    Name = string.IsNullOrWhiteSpace(subject_name) ? "invalid subject name" : subject_name,
                    ClassId = class_.Id 
                };

                _context.Subjects.Add(new_subject);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
