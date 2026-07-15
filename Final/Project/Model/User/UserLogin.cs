using Project.Data;
using Project.Model.Domain;

namespace Project.Model.UserIdentity
{
    public class UserLogin
    {
        private readonly SchoolContext _schoolContext;
        public UserLogin(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public User Login(string username, string password)
        {
            var user = _schoolContext.Users.FirstOrDefault(u => u.UserName == username && u.PasswordHash == password);
            if (user == null)
                return null;

            //string hash = BCrypt.Net.BCrypt.HashPassword(password);

            //bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            //if (!isPasswordValid)
            //    return null;

            return user;
        }

    }
}
