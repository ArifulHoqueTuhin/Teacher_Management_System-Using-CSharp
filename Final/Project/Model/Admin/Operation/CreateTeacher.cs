using Project.Data;
using Project.Model.Admin;
using Project.Model.Domain;
using Project.Model.Enums;

namespace Project.Model.Admin.Operation
{
    public class CreateTeacher : IAdminOperationType
    {
        private readonly SchoolContext _context;
        public CreateTeacher(SchoolContext context)
        {
            _context = context;
        }
        public bool Type()
        {
            Console.WriteLine("Please provide a following information to create a new teacher :");
            Console.Write("Teacher name :");
            var teachername = Console.ReadLine();
            Console.Write("Teacher username :");
            var username = Console.ReadLine();
            Console.Write("Teacher password :");
            var password = Console.ReadLine();

            var newteacher = new User
            {
                Name = teachername,
                UserName = username != null ? username : "invalid user name",
                PasswordHash = password != null ? password : "invalid password ",
                Type = UserType.Teacher
            };
            _context.Users.Add(newteacher);
            _context.SaveChanges();
            return true;
        }
    }
}
