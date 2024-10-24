using System.Text.Json;
using Roster.APP.People;
namespace Roster.APP.DataStorage;

public class Data{

    public static List<Person> People {get; set; } = [];
    public static int NextID {get; set;} = 1;

    public static async Task SaveStudentsToJson(List<Student> students){

        string studentList = JsonSerializer.Serialize(students);

        try{
            using(StreamWriter sw = File.CreateText("DataSTorage/students.json")){
                await sw.WriteAsync(studentList);
            }
        }
        catch(Exception){
            Console.WriteLine("\nCould not save data.\n");
        }
    }

    public static async Task SaveTeachersToJson(List<Teacher> teachers){

        string teacherList = JsonSerializer.Serialize(teachers);

        try{
            using(StreamWriter sw = File.CreateText("DataStorage/teachers.json")){
                await sw.WriteAsync(teacherList);
            }
        }
        catch(Exception){
            Console.WriteLine("\nCould not save data.\n");
        }
    }

    public static List<Student> GetStudentsFromJson(){
        try {
            using(StreamReader sr = File.OpenText("DataStorage/students.json")){
                string jstring = sr.ReadToEnd();
                if (jstring.Length > 0) return JsonSerializer.Deserialize<List<Student>>(jstring)!;
                else return [];
            }
        }
        catch (Exception){
            Console.WriteLine("\nCould not load data.\n");
            return [];
        }
    }

    public static List<Teacher> GetTeachersFromJson(){
        try {
            using(StreamReader sr = File.OpenText("DataStorage/teachers.json")){
                string jstring = sr.ReadToEnd();
                if (jstring.Length > 0) return JsonSerializer.Deserialize<List<Teacher>>(jstring)!;
                else return [];
            }
        }
        catch (Exception){
            Console.WriteLine("\nCould not load data.\n");
            return [];
        }
    }
    public static void SetPeople(){
        foreach (Student s in GetStudentsFromJson()){
            People.Add(s);
            NextID = Math.Max(s.UserID, NextID);
            NextID++;
        }
        foreach (Teacher t in GetTeachersFromJson()){
            People.Add(t);
            NextID = Math.Max(t.UserID, NextID);
            NextID++;
        }
    }

    public static void AddPeople(Person person){
        People.Add(person);
    }

    public static void RemovePerson(Person person){
        People.Remove(person);
    }

    public static void SaveData(){
        List<Student> saveStudents = [];
        List<Teacher> saveTeachers = [];
        foreach (Person person in People){
            if (person is Student student)
                saveStudents.Add(student);
            if (person is Teacher teacher){
                saveTeachers.Add(teacher);
            }
        }
        _ = SaveStudentsToJson(saveStudents);
        _ = SaveTeachersToJson(saveTeachers);
    }

    public static List<Student> GetStudents(){
        List<Student> students = [];
        foreach (Person person in Data.People){
            if (person is Student student){
                students.Add(student);
            }
        }
        return students;
    }

    public static List<Teacher> GetTeachers(){
        List<Teacher> teachers = [];
        foreach (Person person in Data.People){
            if (person is Teacher teacher){
                teachers.Add(teacher);
            }
        }
        return teachers;
    }

    public static HashSet<string> GetAllClasses(){
        HashSet<string> allClasses = [];
        foreach (Teacher teacher in GetTeachers()){
            allClasses.Add(teacher.Subject!);
        }
        return allClasses;
    }
}