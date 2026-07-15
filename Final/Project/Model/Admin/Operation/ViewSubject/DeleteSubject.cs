using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Data;

namespace Project.Model.Admin.Operation.ViewSubject
{
    public class DeleteSubject : IViewSubjectOperation
    {
        private readonly SchoolContext _schoolContext;
        public DeleteSubject(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public bool Operation()
        {
            Console.WriteLine("Provide following information to delete a subject:");
            Console.Write("Subject name:");
            var subject_name = Console.ReadLine();
            var remove_subject = _schoolContext.Subjects.FirstOrDefault(c => c.Name == subject_name);
            if (remove_subject != null)
            {
                var assignments = _schoolContext.TeacherAssignments
                                  .Where(a => a.SubjectId == remove_subject.Id)
                                  .ToList();

                if (assignments.Count > 0)
                    _schoolContext.TeacherAssignments.RemoveRange(assignments);

                _schoolContext.Subjects.Remove(remove_subject);
                _schoolContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
