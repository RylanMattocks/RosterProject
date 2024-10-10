namespace Roster.APP;

using System.ComponentModel.DataAnnotations;
using System.Text.Json;

public static class Data{

    public static async Task saveStudents(List<Student> students){

        string studentList = JsonSerializer.Serialize(students);

        try{
            using(StreamWriter sw = File.CreateText("students.txt")){
                await sw.WriteAsync(studentList);
            }
        }
        catch(Exception){
            Console.WriteLine("\nCould not save data.\n");
        }
    }

    public static async Task saveTeachers(List<Teacher> teachers){

        string teacherList = JsonSerializer.Serialize(teachers);

        try{
            using(StreamWriter sw = File.CreateText("files/teachers.txt")){
                await sw.WriteAsync(teacherList);
            }
        }
        catch(Exception){
            Console.WriteLine("\nCould not save data.\n");
        }
    }

    public static List<Student> getStudents(){
        try {
            using(StreamReader sr = File.OpenText("files/students.txt")){
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

    public static List<Teacher> getTeachers(){
        try {
            using(StreamReader sr = File.OpenText("files/teachers.txt")){
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
    public static List<Person> GetPeople(){
        List<Person> people = [];
        foreach (Student s in getStudents()){
            people.Add(s);
        }
        foreach (Teacher t in getTeachers()){
            people.Add(t);
        }
        return people;
    }
}