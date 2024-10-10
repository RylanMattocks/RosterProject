namespace Roster.APP;

public class Student : Person{
    public List<string> classes {get; set;} = [];
    public int id {get; set; }
    public static int nextID {get; set;} = 0;
    public Student(){}
    public Student(string fName, string lName, int age){
        firstName = fName;
        lastName = lName;
        this.age = age;
        this.id = nextID;
        nextID++;
    }

    public void addClass(string subject){
        if (classes.Contains(subject)) Console.WriteLine($"\n{subject} already exists!");
        else classes.Add(Cleaner.Upper(Cleaner.Clean(subject)));
    }

    public void displayClasses(){
        if (classes.Any()){
            Console.WriteLine();
            foreach(string subject in classes){
                Console.WriteLine($"You are enrolled in {subject}!");
            }
        }
        else Console.WriteLine("\nYou are not enrolled in any classes!");
    }

    public void displayStudent(){
        if (classes.Any()) Console.WriteLine($"\n{firstName} {lastName} is {age}.\nTheir studentID is {id}.\nThey are enrolled in {classes.Count} classes.");
        else Console.WriteLine($"\n{firstName} {lastName} is {age}.\nThey are not enrolled in any classes!");
    }

}