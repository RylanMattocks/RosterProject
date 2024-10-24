using Roster.APP.Inputs;
using Roster.APP.DataStorage;
using Roster.APP.People;
namespace Roster.APP.Menus.MainMenus;

public static class MainMenuLogic{
    private static readonly List<string> Options = ["1", "Teacher", "2", "Student", "Back"];

    public static int GetUserType(){
        string userInput = ReadInput.GetUserInput(Options);
        Tuple<bool, string> errorString = InputValidation.IsError(userInput);
            if (errorString.Item1){
                Console.WriteLine(errorString.Item2);
                return -2;
            }
        if (userInput == Options[0] || userInput == Options[1]) return 1;
        else if (userInput == Options[2] || userInput == Options[3]) return 2;
        else if (userInput == Options[4]) return -2;
        else return 0;
    }

    public static int VerifyUser(string firstName, string lastName, int userID){
        if (userID == 0) return 0;
        if (PersonLogic.CheckPerson(firstName, lastName)){
            if (PersonLogic.CheckPerson(firstName, lastName, userID)){
                if (PersonLogic.CheckStudent(userID) is not null) return 2;
                if (PersonLogic.CheckTeacher(userID) is not null) return 1;
                return 154;
            }
            else return -1;
        }
        else return 0;
    }

    public static Person CreatePerson(string userFName, string userLName, int userType){
        int userAge = PersonLogic.GetPersonAge();
        switch(userType){
            case 1:
                string userSubject = PersonLogic.GetPersonSubject();
                Person teacher = PersonLogic.CreateTeacher(userFName, userLName, userAge, userSubject);
                Data.AddPeople(teacher);
                return teacher;
            case 2:
                Person student = PersonLogic.CreateStudent(userFName, userLName, userAge);
                Data.AddPeople(student);
                return student;
            default:
                Person person = new Teacher();
                return person;
        }
    }

    public static Person GetPerson(int userID, int userType){
        switch(userType){
            case 1:
                List<Person> teachList = Data.People.Where(Person => Person.UserID == userID).ToList();
                Person teacher = teachList[0];
                return teacher;
            case 2:
                List<Person> studList = Data.People.Where(Person => Person.UserID == userID).ToList();
                Person student = studList[0];
                return student;
            default:
                Person person = new Teacher();
                return person;
        }
    }
}