
using Project.Data;
using Project.Model.Enums;

namespace Project.Model.Teacher
{
    public class ViewGrade : ITeacherOperationType
    {
        private readonly SchoolContext _context;
        public ViewGrade(SchoolContext context)
        {
            _context = context;
        }
        public bool Type()
        {
            Console.WriteLine("Please provide following information to view grades:");
            Console.Write("Class name:");
            var class_name = Console.ReadLine();
            var class_ = _context.Classes.FirstOrDefault(c => c.Name == class_name);
            if (class_ != null)
            {
                var students = _context.Students
               .Where(s => s.ClassId == class_.Id)
               .OrderBy(s => s.Name)
               .ToList();

                Console.WriteLine($"Showing grades for - {class_name}");
                Console.WriteLine($"{"Name",-20} {"1st",5} {"Mid",5} {"Final",5}");
                foreach (var student in students)
                {
                    var termAvgs = _context.Grades
                   .Where(g => g.ClassId == class_.Id && g.StudentId == student.Id)
                   .GroupBy(g => g.Term)
                   .Select(g => new
                   {
                       Term = g.Key,
                       Avg = g.Average(x => x.Score)
                   }).ToList();

                    double first = termAvgs.FirstOrDefault(x => x.Term == Term.First)?.Avg ?? 0.0;
                    double mid = termAvgs.FirstOrDefault(x => x.Term == Term.Mid)?.Avg ?? 0.0;
                    double final = termAvgs.FirstOrDefault(x => x.Term == Term.Final)?.Avg ?? 0.0;
                    Console.WriteLine($"{student.Name,-20} {first,5:0.0} {mid,5:0.0} {final,5:0.0}");
                    
                }
                return true;
            }

            return false;
        }
    }
}
