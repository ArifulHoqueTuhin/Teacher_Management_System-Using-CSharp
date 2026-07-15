using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Teacher
{
    public class LogoutOperation : ITeacherOperationType
    {
        public bool Type()
        {
            Console.WriteLine("user Logging out");        
            return false;
        }
    }
}
