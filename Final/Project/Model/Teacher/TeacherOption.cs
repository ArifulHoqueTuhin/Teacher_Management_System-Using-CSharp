
using Project.Data;
using Project.Model.Domain;

namespace Project.Model.Teacher
{
    public class TeacherOption : ITeacherOption
    {
        private readonly SchoolContext _context;
        private readonly User _currentUser;
        public TeacherOption(SchoolContext schoolContext, User currentUser)
        {
            _context = schoolContext;
            _currentUser = currentUser;
        }

        public ITeacherOperationType OperationType(string option)
        {
            return option switch
            {
                "1" => new ViewGrade(_context),
                "2" => new InsertGrade(_context),
                "3" => new AdStudent(_context, _currentUser),
                "4" => new EditStudent(_context, _currentUser),
                "5" => new DeleteStudent(_context, _currentUser),
                "6" => new LogoutOperation(),
                _ => throw new ArgumentException("option is invalid")
            };
        }
    }
}
