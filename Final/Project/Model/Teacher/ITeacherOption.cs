using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Teacher
{
    public interface ITeacherOption
    {
        ITeacherOperationType OperationType(string option);
    }
}
