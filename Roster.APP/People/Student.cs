using Roster.APP.DataStorage;

namespace Roster.APP.People;

public class Student : Person{
    public HashSet<string> Classes {get; set;} = [];
    public Student(){}
    public Student(string fName, string lName, int age, int NextID){
        this.FirstName = fName;
        this.LastName = lName;
        this.Age = age;
        this.UserID = NextID;
    }

    public void AddClass(string subject){
        if (this.Classes.Contains(subject)) Console.WriteLine($"\n{subject} already exists!");
        foreach (Teacher teacher in Data.GetTeachers()){
            if (teacher.Subject == subject){
                this.Classes.Add(subject);
                Console.WriteLine($"\n{subject} added!");
                break;
            }
        }
        if (!this.Classes.Contains(subject)) Console.WriteLine($"\n{subject} does not exist!");
    }

    public void RemoveClass(string subject){
        if (!this.Classes.Remove(subject)) {
            Console.WriteLine($"\n{subject} does not exist!");
        }
        else {
            Console.WriteLine($"\n{subject} removed!");
        }
    }

    public void DisplayClasses(){
        if (this.Classes.Count != 0)
        {
            Console.WriteLine();
            foreach(string subject in this.Classes){
                Console.WriteLine($"You are enrolled in {subject}!");
            }
        }
        else Console.WriteLine("\nYou are not enrolled in any classes!");
    }

    public void UpdateClass(string oldSubject, string newSubject){
        RemoveClass(oldSubject);
        AddClass(newSubject);
        Console.WriteLine("\nClass updated!");
    }

    public void DisplayStudent(){
        if (this.Classes.Count != 0) Console.WriteLine($"\n{this.FirstName} {this.LastName} is {this.Age}.\nThey are enrolled in {this.Classes.Count} classes.");
        else Console.WriteLine($"\n{this.FirstName} {this.LastName} is {this.Age}.\nThey are not enrolled in any classes!");
        Console.WriteLine($"Your User ID is {this.UserID}");
    }

    public void DisplayStudentInfo(){
        Console.WriteLine($"\n{this.FirstName} {this.LastName} User ID is {this.UserID}.");
    }

}