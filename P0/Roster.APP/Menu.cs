using System.Collections;
using System.Xml.Serialization;

namespace Roster.APP;

public class Menu{

    // Greets User
    public static void getGreeting(){
        Console.WriteLine("\n\nHello! Welcome to the Class Roster Application!\n" +
                            "If at any time you would like to exit type \'Exit\' \n");
    }

    // Determines if user is teacher or student
    public static Tuple<Tuple<string, string>, int> getUserType(){

        // Give user options
        string message = (
            "Select one of the following:\n" + 
            "1. I am a \'Teacher\'                         " + "2. I am a \'Student\'"
        );

        // Get user input
        List<string> cases = ["1", "teacher", "2", "student", "back"];
        string? uInput = Input.getUserInput(message, cases);

        // Return user choice
        if (uInput == cases[0] || uInput == cases[1]){
            Tuple<string,string> uName = getName();
            return Tuple.Create(uName, 1);
        }
        else if (uInput == cases[2] || uInput == cases[3]){
            Tuple<string,string> uName = getName();
            return Tuple.Create(uName, 2);
        }
        else if (uInput == cases[4]){
            return Tuple.Create(Tuple.Create("a","a"), -1);
        }
        else{
            Console.WriteLine("\nThis is not a valid input.\nPlease try again!\n");
            return getUserType();
        }
    }
    public static int getTeacherMenu(Tuple<string,string> userName, List<Person> people){
        Person user = new Teacher();
        foreach(Person person in people){
            if (person.firstName == userName.Item1 && person.lastName == person.lastName){
                    if (person is Teacher newS){
                        user = newS;
                    }
                    else{
                        Console.WriteLine("\nThe user exists but is not a teacher!\n");
                        return -1;
                    }
                break;
            }
        }
        if (String.IsNullOrEmpty(user.firstName)){
            Console.WriteLine($"\nSorry {userName.Item1}, it looks like you aren't in our system.\n" + 
                                "Lets get you added!");
            user = Logic.addPerson("teacher", people, userName);
        }

        string? message = (
            "Select an Option: \n" +
            "1. \'View\' students                          " + $"6. \'View {user.firstName}\' info\n" +
            "2. \'Add\' a student                          " + $"7. \'Update\' {user.firstName} info\n" +
            "3. \'Remove\' a student                       " + $"8. \'Delete\' {user.firstName}\n" +
            "4. \'Edit\' a student\n" +
            "5. \'Create\' a new student\n\n" +
            "9. \'Back\' a menu                            " + "0. \'Save\' data"
        );

        List<string> options = [
        "view", "1", 
        "add", "2", 
        "remove", "3", 
        "edit", "4", 
        $"view {Cleaner.Clean(user.firstName!)}", "6", 
        "5", "create", 
        "7", "update", 
        "8", "delete", 
        "9", "back", 
        "0", "save"];

        string userInput = Input.getUserInput(message, options);
        
        // View students
        if(userInput == options[0] || userInput == options[1]){
            if(user is Teacher newTeacher){
                newTeacher.displayStudents(people);
            }
            return 0;
        }
        // Add Students
        else if (userInput == options[2] || userInput == options[3]){
            Logic.addLearner(user, getfName(), getlName(), people);
            return 0;
        }
        // Remove Student
        else if (userInput == options[4] || userInput == options[5]){
            Logic.removeLearner(user, getfName(), getlName(), people);
            return 0;
        }
        // Edit Student
        else if (userInput == options[6] || userInput == options[7]){
            Logic.editStudent(getfName(), getlName(), people);
            return 0;
        }
        // View Teacher Info
        else if(userInput == options[8] || userInput == options[9]){
            if(user is Teacher newTeacher){
                newTeacher.displayTeacher();
            }
            return 0;
        }
        // Create Student
        else if (userInput == options[10] || userInput == options[11]){
            Logic.addPerson("student", people, getName());
            return 0;
        }
        // Update Teacher
        else if (userInput == options[12] || userInput == options[13]){
            Logic.editTeacher(user, people);
            return -1;
        }
        // Delete Teacher
        else if (userInput == options[14] || userInput == options[15]){
            Logic.deletePerson(user, people);
            return -1;
        }
        // Return to previous Menu
        else if (userInput == options[16] || userInput == options[17]){
            return -1;
        }
        // Save Data
        else /*(userInput == options[18] || userInput == options[19])*/{
            Logic.saveData(people);
            return 0;
        }
    }
    public static int getStudentMenu(Tuple<string, string> userName, List<Person> people){
        Person user = new Student();
        foreach(Person person in people){
            if (person.firstName == userName.Item1 && person.lastName == person.lastName){
                if (person is Student newS){
                    user = newS;
                    break;
                }
                else{
                    Console.WriteLine("\nThe user exists but is not a student!\n");
                    return -2;
                }
            }
        }
        if (String.IsNullOrEmpty(user.firstName)){
            Console.WriteLine($"\nSorry {userName.Item1}, it looks like you aren't in our system.\n" + 
                                "Lets get you added!");
            user = Logic.addPerson("student", people, userName);
        }

        string? message = (
            "Select an Option: \n" +
            "1. \'View\' classes                           " + $"5. \'View {user.firstName}\' info\n" +
            "2. \'Add\' a class                            " + $"6. \'Update\' {user.firstName} info\n" +
            "3. \'Remove\' a class                         " + $"7. \'Delete\' {user.firstName}\n" +
            "4. \'Edit\' a class\n\n" +
            "9. \'Back\' a menu                            " +  "0. \'Save\' data"
        );

        List<string> options = [
            "1", "view",
            "2", "add",
            "3", "remove",
            "4", "edit",
            "5", $"view {Cleaner.Clean(user.firstName!)}",
            "6", "update",
            "7", "delete",
            "9", "back",
            "0", "save",
        ];

        string userInput = Input.getUserInput(message, options);

        // View Classes
        if (userInput == options[0] || userInput == options[1]){
            if (user is Student newS) newS.displayClasses();
            return 0;
        }

        // Add Classes
        else if (userInput == options[2] || userInput == options[3]){
            Logic.addClass(user);
            return 0;
        }

        // Remove Classes
        else if (userInput == options[4] || userInput == options[5]){
            Logic.removeClass(user, Input.getSubject());
            return 0;
        }

        // Edit Classes
        else if (userInput == options[6] || userInput == options[7]){
            Logic.editClass(user, Input.getSubject());
            return 0;
        }

        // View User info
        else if (userInput == options[8] || userInput == options[9]){
            if(user is Student newS) newS.displayStudent();
            return 0;
        }

        // Update user info
        else if (userInput == options[10] || userInput == options[11]){
            Logic.editStudent(user, people);
            return -2;
        }

        // Delete user info
        else if (userInput == options[12] || userInput == options[13]){
            Logic.deletePerson(user, people);
            return -2;
        }

        // Go back to previous menu
        else if (userInput == options[14] || userInput == options[15]){
            return -2;
        }

        // Save Data
        else /*(userInput == options[0] || userInput == options[1])*/{
            Logic.saveData(people);
            return 0;
        }

    }
    public static string getfName(){
        string message = "Please enter first name: ";
        string? userInput = Input.getUserInput(message);
        return Cleaner.Upper(userInput);
    }

    public static string getlName(){
        string message = "Please enter last name: ";
        string? userInput = Input.getUserInput(message);
        return Cleaner.Upper(userInput) ;
    }

    public static Tuple<string, string> getName(){
        return Tuple.Create(getfName(), getlName());
    }

    public static Person getTeacherInfo(Tuple<string,string> fullName, List<Person> people){
        if (Logic.checkPerson(fullName.Item1, fullName.Item2, people).Item1){
            Console.WriteLine("\nThis user already exists!\n");
            return Logic.checkPerson(fullName.Item1, fullName.Item2, people).Item2;
        }
        else{
            int age = Input.getAge();
            string? subject = Input.getSubject();
            Person newPerson = new Teacher(fullName.Item1, fullName.Item2, age, subject);
            return newPerson;
        }
    }

    public static Person getStudentInfo(Tuple<string,string> fullName, List<Person> people){
        if (Logic.checkPerson(fullName.Item1, fullName.Item2, people).Item1){
            Console.WriteLine("\nThis user already exists!\n");
            return Logic.checkPerson(fullName.Item1, fullName.Item2, people).Item2;
        }
        else{
            int age = Input.getAge();
            Person newPerson = new Student(fullName.Item1, fullName.Item2, age);
            return newPerson;
        }
    }
}