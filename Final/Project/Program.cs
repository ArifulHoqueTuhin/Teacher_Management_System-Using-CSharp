
using Project.Data;
using Project.Model.Admin;
using Project.Model.Admin.Operation.ViewClass;
using Project.Model.Admin.Operation.ViewSubject;
using Project.Model.Admin.Operation.ViewTeacher;
using Project.Model.Teacher;
using Project.Model.UserIdentity;


var context = new SchoolContext();
while (true)
{
    Console.WriteLine("Please Login :");
    Console.Write("Username:");
    var Username = Console.ReadLine();
    Console.Write("Password:");
    var Password = Console.ReadLine();
    var userLogin = new UserLogin(context);
    var user = userLogin.Login(Username, Password);
    if (user == null)
    {
        Console.WriteLine("invalid user");
        continue;
    }

    Console.WriteLine($"\n Welcome {user.Name} ({user.Type})!\n");

    var viewClassOption = new ViewClassOption(context);
    var viewSubjectOption = new ViewSubjectOption(context);
    var viewTeacherOption = new ViewTeacherOption(context);

    var adminOption = new AdminOption(context, viewClassOption, viewSubjectOption, viewTeacherOption);
    var teacherOption = new TeacherOption(context,user);
    var userIdentifier = new UserIdentifier(adminOption, teacherOption, context, user);
    var userIdentifierService = new UserIdentifierService(userIdentifier);   

    bool keepLoggedIn = true;

    while (keepLoggedIn)
    {
        bool performOperation = userIdentifierService.UserService(user.Type.ToString());

        if (!performOperation)
        {
            Console.WriteLine("\n User logged out successfully.\n");
            keepLoggedIn = false;
        }
    }

}


