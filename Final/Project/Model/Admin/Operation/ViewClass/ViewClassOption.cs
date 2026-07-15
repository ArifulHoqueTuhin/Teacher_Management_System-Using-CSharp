

using Project.Data;

namespace Project.Model.Admin.Operation.ViewClass
{
    public class ViewClassOption : IViewClassOptionType
    {
        private readonly SchoolContext _schoolContext;
        public ViewClassOption(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }
        public IViewClassOperation OptionType(string option)
        {
            return option switch
            {
                "1" => new EditClass(_schoolContext),
                "2" => new DeleteClass(_schoolContext),
                "3" => new AssignSubject(_schoolContext),
                _ => throw new ArgumentException("option is invalid")
            };
        }
    }
}
