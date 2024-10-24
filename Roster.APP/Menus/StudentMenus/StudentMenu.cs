using Roster.APP.People;
namespace Roster.APP.Menus.StudentMenus;

public static class StudentMenu{
    private static readonly string StudentOptions = (
            "\nSelect an Option: \n" +
            "1. \'View\' classes                           " + "5. View \'{0}\' info\n" +
            "2. \'Add\' a class                            " + "6. \'Update\' {0} info\n" +
            "3. \'Remove\' a class                         " + "7. \'Delete\' {0}\n" +
            "4. \'Edit\' a class\n\n" +
            "9. \'Back\' a menu                            " +  "0. \'Save\' data"
        );

    public static int Menu(Person person){
        Student user = (Student)person;
        object[] formatStrings = [user.FirstName!];
        string userOptions = String.Format(StudentOptions, formatStrings);
        Console.WriteLine(userOptions);
        return StudentMenuLogic.GetUserOption(user);
    }
}