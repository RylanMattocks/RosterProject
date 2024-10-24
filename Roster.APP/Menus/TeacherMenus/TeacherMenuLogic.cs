using Roster.APP.Inputs;
using Roster.APP.DataStorage;
using Roster.APP.People;
namespace Roster.APP.Menus.TeacherMenus;

public class TeacherMenuLogic{
    private static List<string> Options = [
        "1", "View",
        "2", "Add", 
        "3", "Remove",
        "4", "Edit",
        "5", "Create",
        "6", "{0}",  
        "7", "Update", 
        "8", "Delete", 
        "9", "Back", 
        "0", "Save"];

    private static readonly string AddRemoveStudent = "\nPlease enter the Student ID: ";
    private static readonly string OldStudent = "\nPlease enter the Students info: ";
    private static readonly string NewStudent = "\nPlease enter the new Student Information: ";
    private static readonly string NewInfo = "\nPlease enter your new info: ";
    private static readonly string CreateStudent = "\nPlease enter the new students info: ";
    private static readonly string AllStudents = "\nHere are all the current students: ";
    private static readonly string TeachersStudent = "\nHere are all your current students: ";

    public static int GetUserOption(Teacher teacher){
        object[] formatString = [teacher.FirstName!];
        Options[11] = string.Format(Options[11], formatString);
        string userInput = ReadInput.GetUserInput(Options);
        Tuple<bool, string> errorString = InputValidation.IsError(userInput);
            if (errorString.Item1){
                Console.WriteLine(errorString.Item2);
                return 0;
            }
        if (Options[0] == userInput || Options[1] == userInput){
            teacher.DisplayStudents();
            return 0;
        }
        else if (Options[2] == userInput || Options[3] == userInput){
            Console.WriteLine(AllStudents);
            List<Student> students = Data.GetStudents();
            foreach (Student student in students){
                student.DisplayStudentInfo();
            }
            Console.WriteLine(AddRemoveStudent);
            int userInt = PersonLogic.GetPersonID();
            teacher.AddStudents(userInt);
            return 0;
        }
        else if (Options[4] == userInput || Options[5] == userInput){
            Console.WriteLine(TeachersStudent);
            List<Student> students = Data.GetStudents();
            foreach (Student student in students){
                if (teacher.StudentID.Contains(student.UserID)){
                    student.DisplayStudentInfo();
                }
            }
            Console.WriteLine(AddRemoveStudent);
            int userInt = PersonLogic.GetPersonID();
            teacher.RemoveStudents(userInt);
            return 0;
        }
        else if (Options[6] == userInput || Options[7] == userInput){
            Console.WriteLine(TeachersStudent);
            List<Student> students = Data.GetStudents();
            foreach (Student student in students){
                if (teacher.StudentID.Contains(student.UserID)){
                    student.DisplayStudentInfo();
                }
            }
            int oldStudentID = PersonLogic.SetPersonID(teacher.StudentID);
            Console.WriteLine(OldStudent);
            Console.WriteLine(AllStudents);
            foreach (Student student in students){
                student.DisplayStudentInfo();
            }
            Console.WriteLine(NewStudent);
            int newStudentID = PersonLogic.SetPersonID(PersonLogic.GetStudentIDs());
            teacher.EditStudents(oldStudentID, newStudentID);
        }
        else if (Options[8] == userInput || Options[9] == userInput){
            Console.WriteLine(CreateStudent);
            Data.AddPeople(PersonLogic.CreateStudent(PersonLogic.GetPersonFName(), PersonLogic.GetPersonLName(), PersonLogic.GetPersonAge()));
            Data.SaveData();
            return 0;
        }
        else if (Options[10] == userInput || Options[11] == userInput){
            teacher.DisplayTeacher();
            return 0;
        }
        else if (Options[12] == userInput || Options[13] == userInput){
            Console.WriteLine(NewInfo);
            teacher.FirstName = PersonLogic.GetPersonFName();
            teacher.LastName = PersonLogic.GetPersonLName();
            teacher.Age = PersonLogic.GetPersonAge();
            teacher.Subject = PersonLogic.GetPersonSubject();
            return -1;
        }
        else if (Options[14] == userInput || Options[15] == userInput){
            if (!InputValidation.ConfirmInput(userInput)) return 0;
            Data.RemovePerson(teacher);
            foreach (Student student in Data.GetStudents()){
                if (student.Classes.Contains(teacher.Subject!)) {
                    if (!Data.GetAllClasses().Contains(teacher.Subject!)) student.Classes.Remove(teacher.Subject!);
                }
            }
            Data.SaveData();
            return -1;
        }
        else if (Options[16] == userInput || Options[17] == userInput){
            Data.SaveData();
            return -1;
        }
        else if (Options[18] == userInput || Options[19] == userInput){
            Data.SaveData();
            return 0;
        }
        return 0;
    }
}