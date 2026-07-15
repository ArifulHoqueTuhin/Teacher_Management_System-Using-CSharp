using Project.Data;
using Project.Model.Admin.Operation;
using Project.Model.Admin.Operation.ViewClass;
using Project.Model.Admin.Operation.ViewSubject;
using Project.Model.Admin.Operation.ViewTeacher;

namespace Project.Model.Admin
{
    public class AdminOption : IAdminOption
    {
        private readonly SchoolContext _schoolContext;
        private readonly IViewClassOptionType _viewClassOptionType;
        private readonly IViewSubjectOptionType _viewSubjectOptionType;
        private readonly IViewTeacherOptionType _viewTeacherOptionType;

        public AdminOption(SchoolContext schoolContext, IViewClassOptionType viewClassOptionType, IViewSubjectOptionType viewSubjectOptionType, IViewTeacherOptionType viewTeacherOptionType)
        {
            _schoolContext = schoolContext;
            _viewClassOptionType = viewClassOptionType;
            _viewSubjectOptionType = viewSubjectOptionType;
            _viewTeacherOptionType = viewTeacherOptionType;
        }
        public IAdminOperationType OperationType(string option)
        {
            return option switch
            {
                "1" => new CreateClass(_schoolContext),
                "2" => new CreateSubject(_schoolContext),
                "3" => new CreateTeacher(_schoolContext),
                "4" => new ViewClass(_schoolContext,_viewClassOptionType),
                "5" => new ViewSubject(_schoolContext,_viewSubjectOptionType),
                "6" => new ViewTeacher(_schoolContext,_viewTeacherOptionType),
                _ => throw new ArgumentException("invalid operation")
            };
        }
    }
}
