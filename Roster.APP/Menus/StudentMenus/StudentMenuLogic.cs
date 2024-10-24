using Roster.APP.People;
using Roster.APP.Inputs;
using Roster.APP.DataStorage;
namespace Roster.APP.Menus.StudentMenus;

public static class StudentMenuLogic{
    private static List<string> Options = [
            "1", "View",
            "2", "Add",
            "3", "Remove",
            "4", "Edit",
            "5", "{0}",
            "6", "Update",
            "7", "Delete",
            "9", "Back",
            "0", "Save",
        ];
    private static readonly string AddClass = "\nType the class you would like to add: ";
    private static readonly string RemoveClass = "\nType the class you would like to remove: ";
    private static readonly string EditClass = "\nType the class you would like to edit: ";
    private static readonly string NewClass = "\nType the new class: ";
    private static readonly string NewInfo = "\nType in your new info: ";
    private static readonly string StudentClasses = "\nHere are all your current classes: ";
    private static readonly string AllClasses = "\nHere are all the available classes: ";

    public static int GetUserOption(Student student){
        object[] formatStrings = [student.FirstName!];
        Options[9] = String.Format(Options[9], formatStrings);
        string userInput = ReadInput.GetUserInput(Options);
        Tuple<bool, string> errorString = InputValidation.IsError(userInput);
            if (errorString.Item1){
                Console.WriteLine(errorString.Item2);
                return 0;
            }
        if (userInput == Options[0] || userInput == Options[1]){
            student.DisplayClasses();
            return 0;
        }
        else if (userInput == Options[2] || userInput == Options[3]) {
            Console.WriteLine(AllClasses);
            foreach (string str in Data.GetAllClasses()){
                Console.WriteLine($"Available Class: {str}");
            }
            Console.WriteLine(AddClass);
            string subject = PersonLogic.GetStudentSubject();
            student.AddClass(subject);
            return 0;
        }
        else if (userInput == Options[4] || userInput == Options[5]) {
            Console.WriteLine(StudentClasses);
            student.DisplayClasses();
            Console.WriteLine(RemoveClass);
            string subject = PersonLogic.SetStudentSubject(student.Classes.ToList());
            student.RemoveClass(subject);
            return 0;
        }
        else if (userInput == Options[6] || userInput == Options[7]) {
            Console.WriteLine(StudentClasses);
            student.DisplayClasses();
            Console.WriteLine(EditClass);
            string oldSubject = PersonLogic.SetStudentSubject(student.Classes.ToList());
            Console.WriteLine(AllClasses);
            foreach (string str in Data.GetAllClasses()){
                Console.WriteLine($"Available Class: {str}");
            }
            Console.WriteLine(NewClass);
            string newSubject = PersonLogic.GetStudentSubject();
            student.UpdateClass(oldSubject, newSubject);
            return 0;
        }
        else if (userInput == Options[8] || userInput == Options[9]) {
            student.DisplayStudent();
            return 0;
        }
        else if (userInput == Options[10] || userInput == Options[11]) {
            Console.WriteLine(NewInfo);
            student.FirstName = PersonLogic.GetPersonFName();
            student.LastName = PersonLogic.GetPersonLName();
            student.Age = PersonLogic.GetPersonAge();
            return -2;
        }
        else if (userInput == Options[12] || userInput == Options[13]) {
            if (!InputValidation.ConfirmInput(userInput)) return 0;
            foreach (Person person in Data.People){
                if (person is Teacher teacher){
                    teacher.StudentID.Remove(student.UserID);
                }
            }
            Data.RemovePerson(student);
            Data.SaveData();
            return -2;
            }
        else if (userInput == Options[14] || userInput == Options[15]) {
            Data.SaveData();
            return -2;
            }
        else if (userInput == Options[16] || userInput == Options[17]) {
            Data.SaveData();
            return 0;
        }
        return 0;
    }
}