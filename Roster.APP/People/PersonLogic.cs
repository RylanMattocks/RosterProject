namespace Roster.APP.People;
using Roster.APP.Inputs;
using Roster.APP.DataStorage;

public static class PersonLogic{

    private static readonly string FirstName = "\nPlease enter first name: ";
    private static readonly string LastName = "\nPlease enter last name: ";
    private static readonly string NewPersonID = "\nIf you are a new user: enter 0.\nPlease enter User ID: ";
    private static readonly string PersonID = "\nPlease enter User ID: ";
    private static readonly string PersonAge = "\nPlease enter age(1-100): ";
    private static readonly string PersonSubject = "\nPlease enter subject: ";
    private static string ShowUserID = "\nYou have been added to our system {0}!\nYour User ID is {1}. You will need this to access your account.";

    public static Tuple<string,string,int> GetPersonInfo(){
        Tuple<string,string> fullName = GetPersonName();
        return Tuple.Create(fullName.Item1, fullName.Item2, GetPersonID());
    }

    public static Tuple<string,string> GetPersonName(){
        return Tuple.Create(GetPersonFName(), GetPersonLName());
    }

    public static string GetPersonFName(){
        Console.WriteLine(FirstName);
        string? userInput = ReadInput.GetUserInput();
        Tuple<bool,string> checkInput = InputValidation.IsError(userInput);
        if (checkInput.Item1){
            Console.WriteLine(checkInput.Item2);
            return GetPersonFName();
        }
        return userInput;
    }

    public static string GetPersonLName(){
        Console.WriteLine(LastName);
        string? userInput = ReadInput.GetUserInput();
        Tuple<bool,string> checkInput = InputValidation.IsError(userInput);
        if (checkInput.Item1){
            Console.WriteLine(checkInput.Item2);
            return GetPersonLName();
        }
        return userInput;
    }

    public static int GetPersonID(){
        Console.WriteLine(NewPersonID);
        string? userInput = ReadInput.GetUserInt();
        Tuple<bool,string> checkInput = InputValidation.IsError(userInput);
        if (checkInput.Item1){
            Console.WriteLine(checkInput.Item2);
            return GetPersonID();
        }
        else return int.Parse(userInput);
    }

    public static int GetPersonAge(){
        Console.WriteLine(PersonAge);
        string? userInput = ReadInput.GetUserInt();
        Tuple<bool, string> validInput = InputValidation.IsError(userInput);
        if (validInput.Item1){
            Console.WriteLine(validInput.Item2);
            return GetPersonAge();
        }
        int userInt = int.Parse(userInput);
        userInput = InputValidation.CheckAge(userInt);
        validInput = InputValidation.IsError(userInput);
        if (validInput.Item1){
            Console.WriteLine(validInput.Item2);
            return GetPersonAge();
        }
        return userInt;
    }

    public static string GetPersonSubject(){
        Console.WriteLine(PersonSubject);
        string? userInput = ReadInput.GetUserInput();
        Tuple<bool,string> checkInput = InputValidation.IsError(userInput);
        if (checkInput.Item1){
            Console.WriteLine(checkInput.Item2);
            return GetPersonSubject();
        }
        if (!InputValidation.ConfirmInput(userInput)) return GetPersonSubject();
        return userInput;
    }

    public static bool CheckPerson(string firstName, string lastName){
        foreach (Person person in Data.People){
            if (person.FirstName == firstName && person.LastName == lastName) return true;
        }
        return false;
    }

    public static bool CheckPerson(string firstName, string lastName, int userID){
        foreach (Person person in Data.People){
            if (person.FirstName == firstName && person.LastName == lastName && person.UserID == userID) return true;
        }
        return false;
    }

    public static Student? CheckStudent(int userID){
        foreach (Person person in Data.People){
            if (person is Student student){
                if (student.UserID == userID) return student;
            }
        }
        return null;
    }
    
    public static Teacher? CheckTeacher(int userID){
        foreach (Person person in Data.People){
            if (person is Teacher teacher){
                if (teacher.UserID == userID) return teacher;
            }
        }
        return null;
    }

    public static Teacher CreateTeacher(string firstName, string lastName, int age, string subject){
        Teacher teacher = new(firstName, lastName, age, subject, Data.NextID);
        Data.NextID++;
        object[] formatStrings = [teacher.FirstName!, teacher.UserID];
        Console.WriteLine(String.Format(ShowUserID, formatStrings));
        return teacher;
    }

    public static Student CreateStudent(string firstName, string lastName, int age){
        Student student = new(firstName, lastName, age, Data.NextID);
        Data.NextID++;
        object[] formatStrings = [student.FirstName!, student.UserID];
        Console.WriteLine(String.Format(ShowUserID, formatStrings));
        return student;
    }
    
    public static List<int> GetStudentIDs(){
        List<int> studentIDs = [];
        foreach (Person person in Data.People){
            if (person is Student student){
                studentIDs.Add(student.UserID);
            }
        }
        return studentIDs;
    }

    public static int SetPersonID(List<int> options){
        Console.WriteLine(PersonID);
        string? userInput = ReadInput.GetUserInt(options);
        Tuple<bool,string> checkInput = InputValidation.IsError(userInput);
        if (checkInput.Item1){
            Console.WriteLine(checkInput.Item2);
            return SetPersonID(options);
        }
        else return int.Parse(userInput);
    }
    public static string GetStudentSubject(){
        Console.WriteLine(PersonSubject);
        string? userInput = ReadInput.GetUserInput(Data.GetAllClasses().ToList());
        Tuple<bool,string> checkInput = InputValidation.IsError(userInput);
        if (checkInput.Item1){
            Console.WriteLine(checkInput.Item2);
            return GetStudentSubject();
        }
        return userInput;
    }
    public static string SetStudentSubject(List<string> options){
        Console.WriteLine(PersonSubject);
        string? userInput = ReadInput.GetUserInput(options);
        Tuple<bool,string> checkInput = InputValidation.IsError(userInput);
        if (checkInput.Item1){
            Console.WriteLine(checkInput.Item2);
            return SetStudentSubject(options);
        }
        return userInput;
    }
    
}