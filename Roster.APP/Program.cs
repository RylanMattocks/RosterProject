using Roster.APP.DataStorage;
using Roster.APP.People;
using Roster.APP.Menus.MainMenus;
using Roster.APP.Menus.StudentMenus;
using Roster.APP.Menus.TeacherMenus;
namespace Roster.APP;
class Program
{
    static void Main(string[] args)
    {

        Data.SetPeople();
        int currentMenu = -1;
        Person tmp = new Teacher();
        Tuple<int, Person> userInfo = Tuple.Create(currentMenu, tmp);

        do {
            switch(currentMenu){
                case -1:
                    MainMenu.PrintGreeting();
                    currentMenu++;
                    break;
                case 0:
                    userInfo = MainMenu.GetUserType();
                    currentMenu += userInfo.Item1;
                    break;
                case 1:
                    currentMenu += TeacherMenu.Menu(userInfo.Item2);
                    break;
                case 2:
                    currentMenu += StudentMenu.Menu(userInfo.Item2);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        } while (true);
    }
}
