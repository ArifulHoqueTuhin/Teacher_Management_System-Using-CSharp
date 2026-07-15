using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Admin.Operation.ViewTeacher
{
   public interface IViewTeacherOptionType
    {
        IViewTeacherOperation OperationType(string option);
    }
}
