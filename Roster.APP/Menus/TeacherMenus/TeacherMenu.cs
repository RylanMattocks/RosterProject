using Roster.APP.People;
namespace Roster.APP.Menus.TeacherMenus;

public class TeacherMenu{
    private static readonly string TeacherOptions = (
            "\nSelect an Option: \n" +
            "1. \'View\' students in class                 " + "6. View \'{0}\' info\n" +
            "2. \'Add\' a student to class                 " + "7. \'Update\' {0} info\n" +
            "3. \'Remove\' a student from class            " + "8. \'Delete\' {0}\n" +
            "4. \'Edit\' class list\n" +
            "5. \'Create\' a new student\n\n" +
            "9. \'Back\' a menu                            " + "0. \'Save\' data"
        );

    public static int Menu(Person person){
        Teacher user = (Teacher)person;
        object[] formatStrings = [user.FirstName!];
        string userOptions = String.Format(TeacherOptions, formatStrings);
        Console.WriteLine(userOptions);
        return TeacherMenuLogic.GetUserOption(user);
    }
}