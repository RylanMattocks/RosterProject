namespace Roster.APP;
class Program
{
    static void Main(string[] args)
    {

        int highId = -1;
        List<Person> people = Data.GetPeople();
        foreach (Person person in people){
            if (person is Student student){
                highId = Math.Max(highId, student.id);
            }
        }
        Student.nextID = ++highId;

        Tuple<string,string> userName = Tuple.Create("","");
        int currentMenu = -1;
        Tuple<Tuple<string,string>, int> loginInfo;

        do {

            switch(currentMenu){
                case -1:
                    Menu.getGreeting();
                    currentMenu++;
                    break;
                case 0:
                    loginInfo = Menu.getUserType();
                    userName = loginInfo.Item1;
                    currentMenu = loginInfo.Item2;
                    break;
                case 1:
                    currentMenu += Menu.getTeacherMenu(userName, people);
                    break;
                case 2:
                    currentMenu += Menu.getStudentMenu(userName, people);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        } while (true);
    }
}
