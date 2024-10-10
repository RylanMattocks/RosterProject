using System.Dynamic;
using System.Runtime.InteropServices;

namespace Roster.APP;

public class Teacher : Person{
    public List<int> studentID {get; set; } = [];

    public string? subject {get; set;}
    public Teacher(){}

    public Teacher(string fName, string lName, int age, string subject){
        firstName = fName;
        lastName = lName;
        this.age = age;
        this.subject = subject;
    }

    public void displayStudents(List<Person> people){
        if (studentID.Count > 0){
            foreach(Person person in people){
                if (person is Student stud){
                    if (studentID.Contains(stud.id)){
                        stud.displayStudent();
                    }
                }
            }
        }
        else Console.WriteLine("\nYou do not have any students");
    }

    public void displayTeacher(){
        if (studentID.Any()) Console.WriteLine($"\n{firstName} {lastName} is {age}.\nThey teach {subject}.\nThey have {studentID.Count} students!");
        else Console.WriteLine($"\n{firstName} {lastName} is {age}.\nThey teach {subject}.\nThey do not have any students!");
    }
}
