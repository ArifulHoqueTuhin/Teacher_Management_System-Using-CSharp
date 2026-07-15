using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;
using Project.Model.Admin.Operation.ViewClass;

namespace Project.Model.Admin.Operation.ViewSubject
{
    public class ViewSubjectOption : IViewSubjectOptionType
    {
        private readonly SchoolContext _schoolContext;
        public ViewSubjectOption(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public IViewSubjectOperation OptionType(string option)
        {
            return option switch
            {
                "1" => new EditSubject(_schoolContext),
                "2" => new DeleteSubject(_schoolContext),
                "3" => new AssignTeacher(_schoolContext),
                _ => throw new ArgumentException("option is invalid")
            };
        }
    }
}
