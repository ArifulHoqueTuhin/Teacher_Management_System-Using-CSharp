using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;
using Project.Model.Admin;
using Project.Model.Domain;

namespace Project.Model.Admin.Operation
{
    public class CreateClass : IAdminOperationType
    {
        private readonly SchoolContext _schoolContext;
        public CreateClass(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }
        public bool Type()
        {
            Console.WriteLine("Please provide a following information to create a new class :");
            Console.Write("Class name :");
            var classname = Console.ReadLine();
            var newclass = new SchoolClass
            {
                Name = classname != null ? classname : "invalid class name"
            };
            _schoolContext.Classes.Add(newclass);
            _schoolContext.SaveChanges();
            return true;
        }
    }
}
