using Roster.APP.DataStorage;
namespace Roster.APP.People;

public class Teacher : Person{
    public List<int> StudentID {get; set; } = [];
    public string? Subject {get; set;}
    public Teacher() {}
    public Teacher(string fName, string lName, int age, string subject, int NextID){
        this.FirstName = fName;
        this.LastName = lName;
        this.Age = age;
        this.Subject = subject;
        this.UserID = NextID;
    }

    public void AddStudents(int studentID){
        if (this.StudentID.Contains(studentID)) Console.WriteLine($"\nThis user already exists!");
        else {
            this.StudentID.Add(studentID);
            Console.WriteLine("\nStudent added!");
        }
    }

    public void RemoveStudents(int studentID){
        if (!this.StudentID.Remove(studentID)) {
            Console.WriteLine($"\nStudent ID:{studentID} does not exist!");
        }
        else {
            Console.WriteLine($"\nStudent removed!");
        }
    }

    public void EditStudents(int oldStudentID, int newStudentID){
        foreach (int id in StudentID){
            if (id == oldStudentID){
                RemoveStudents(oldStudentID);
                AddStudents(newStudentID);
                Console.WriteLine("\nStudents list updated!");
                break;
            }
        }
    }

    public void DisplayStudents(){
        if (this.StudentID.Count > 0){
            foreach(Person person in Data.People){
                if (person is Student stud){
                    if (this.StudentID.Contains(stud.UserID)){
                        stud.DisplayStudentInfo();
                    }
                }
            }
        }
        else Console.WriteLine("\nYou do not have any students");
    }

    public void DisplayTeacher(){
        if (this.StudentID.Count != 0) Console.WriteLine($"\n{this.FirstName} {this.LastName} is {this.Age}.\nThey teach {this.Subject}.\nThey have {this.StudentID.Count} students!");
        else Console.WriteLine($"\n{this.FirstName} {this.LastName} is {this.Age}.\nThey teach {this.Subject}.\nThey do not have any students!");
        Console.WriteLine($"Your User ID is {this.UserID}");
    }
}
