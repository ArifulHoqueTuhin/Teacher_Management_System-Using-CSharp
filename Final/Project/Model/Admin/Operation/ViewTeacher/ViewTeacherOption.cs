using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;
using Project.Model.Admin.Operation.ViewSubject;

namespace Project.Model.Admin.Operation.ViewTeacher
{
    public class ViewTeacherOption : IViewTeacherOptionType
    {
        private readonly SchoolContext _schoolContext;
        public ViewTeacherOption(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public IViewTeacherOperation OperationType(string option)
        {
            return option switch
            {
                "1" => new EditTeacher(_schoolContext),
                "2" => new DeleteTeacher(_schoolContext),    
                _ => throw new ArgumentException("option is invalid")
            };

        }
    }
}
