using Project.Data;
using Project.Model.Admin;
using Project.Model.Domain;
using Project.Model.Teacher;

namespace Project.Model.UserIdentity
{
    public class UserIdentifier : IUserIdentifier
    {
        private readonly AdminOption _adminoption;
        private readonly TeacherOption _teacheroption;
        private readonly SchoolContext _schoolContext;
        private readonly User _user;

        public UserIdentifier(AdminOption adminoption, TeacherOption teacherOption, SchoolContext schoolContext, User user)
        {
            _adminoption = adminoption;
            _teacheroption = teacherOption;
            _schoolContext = schoolContext;
            _user = user;
        }
        public IUserOperation User(string usertype)
        {
            return usertype switch
            {
                "Admin" => new AdminOperation(_adminoption),
                "Teacher" => new TeacherOperation(_schoolContext,_teacheroption,_user),
                _ => throw new ArgumentException("Invalid user type")
            };
        }
    }
}
