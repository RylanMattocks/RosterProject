namespace Roster.APP;

public class Logic{

    public static Person addPerson(string type, List<Person> people, Tuple<string,string> fullName){
        foreach (Person person in people){
            if (fullName.Item1 == person.firstName && fullName.Item2 == person.lastName){
                Console.WriteLine($"\n{fullName.Item1} {fullName.Item2} already exists!");
                return person;
            }
        }
        if (type == "teacher"){
            Person newPerson = Menu.getTeacherInfo(fullName, people);
            people.Add(newPerson);
            Console.WriteLine($"\n{newPerson.firstName} {newPerson.lastName} created!");
            return newPerson;
        }
        else /*(type == "student")*/{
            Person newPerson = Menu.getStudentInfo(fullName, people);
            people.Add(newPerson);
            Console.WriteLine($"\n{newPerson.firstName} {newPerson.lastName} created!");
            return newPerson;
        }
    }

    public static void deletePerson(Person person, List<Person> people){
        int studentIDToRemove = -1;
        foreach (Person p in people){
            if (p == person){
                    people.Remove(p);
                    if (p is Student student){
                        studentIDToRemove = student.id;
                    }
                    Console.WriteLine($"\n{p.firstName} {p.lastName} deleted!");
                    break;
            }
        }
        foreach (Person p in people){
            if (p is Teacher teach){
                teach.studentID.Remove(studentIDToRemove);
            }
        }
    }

    public static void addLearner(Person teacher, string fName, string lName, List<Person> people){
        if (teacher is Teacher newT){
            if (checkPerson(fName, lName, people).Item1){
                Person student = checkPerson(fName, lName, people).Item2;
                if (student is Student stud){

                    if (newT.studentID.Contains(stud.id)){
                        Console.WriteLine("\nYou already have this student!");
                    }
                    else{
                        newT.studentID.Add(stud.id);
                        Console.WriteLine($"\n{stud.firstName} {stud.lastName} added!");
                    }
                }
            }
            else Console.WriteLine($"\n{fName} {lName} is not a valid student.\nPlease make sure you have typed the name correctly.");
        }
    }
    public static Tuple<bool,Person> checkPerson(string fName, string lName, List<Person> people){
        foreach(Person aPerson in people){
            if (aPerson.firstName == fName && aPerson.lastName ==lName){
                return Tuple.Create(true, aPerson);
            }
        }
        Person newPerson = new Student();
        return Tuple.Create(false, newPerson);
    }

    public static void removeLearner(Person teacher, string fName, string lName, List<Person> people){
        if (teacher is Teacher newT){
            if (checkPerson(fName, lName, people).Item1){
                Person student = checkPerson(fName, lName, people).Item2;
                if (student is Student stud){
                    if (newT.studentID.Contains(stud.id)){
                        if (student is Student newS){
                            newT.studentID.Remove(stud.id);
                            Console.WriteLine($"\n{newS.firstName} {newS.lastName} removed!");
                        }
                    }
                }
            }
            else Console.WriteLine($"\n{fName} {lName} is not one of your students!");
        }
    }

    // Used for student menu
    public static void editStudent(Person student, List<Person> people){
        if (student is Student newS){
            Person updatedStudent = Menu.getStudentInfo(Menu.getName(), people);
            Console.WriteLine("\nPlease enter updated info: ");
            if (updatedStudent is Student uStudent){
                newS.firstName = uStudent.firstName;
                newS.lastName = uStudent.lastName;
                newS.age = uStudent.age;
                Console.WriteLine($"\n{newS.firstName} {newS.lastName} created!");
            }
        }
    }

    // Used for teacher menu
    public static void editStudent(string fName, string lName, List<Person> people){
        if (checkPerson(fName, lName, people).Item1){
            Person student = checkPerson(fName, lName, people).Item2;
            if (student is Student newS){
                Console.WriteLine("\nStudent Found!\nPlease enter updated Info: ");
                Person updatedStudent = Menu.getStudentInfo(Menu.getName(), people);
                if (updatedStudent is Student uStudent){
                    newS.firstName = uStudent.firstName;
                    newS.lastName = uStudent.lastName;
                    newS.age = uStudent.age;
                    Console.WriteLine($"\n{newS.firstName} {newS.lastName} updated!");
                }
            }
        }
        else Console.WriteLine($"\nStudent {fName} {lName} not found.\nPlease make sure you have typed the name correctly.");
    }
    
    public static void editTeacher(Person teacher, List<Person> people){
        if (teacher is Teacher newT){
            Console.WriteLine("\nPlease enter your updated info: ");
            Person updatedTeacher = Menu.getTeacherInfo(Menu.getName(), people);
            if (updatedTeacher is Teacher uTeach){
                newT.firstName = uTeach.firstName;
                newT.lastName = uTeach.lastName;
                newT.age = uTeach.age;
                newT.subject = uTeach.subject;
                Console.WriteLine("\nInfo updated!\nPlease login again.");
            }
        }
    }

    public static void addClass(Person student){
        if (student is Student newS){
            newS.addClass(Input.getSubject());
            Console.WriteLine($"\n{newS.classes.Last()} added!");
        }
    }

    public static void removeClass(Person student, string subject){
        if (student is Student newS){
            if (newS.classes.Remove(subject)) Console.WriteLine($"\n{subject} removed!");
            else Console.WriteLine($"\nYou are not enrolled in {subject}.\nPlease make sure you have typed the name correctly.");
        }
    }

    public static void editClass(Person Student, string subject){
        if (Student is Student newS){
            if (newS.classes.Contains(subject)){
                int index = newS.classes.IndexOf(subject);
                Console.WriteLine("\nPlease enter updated info: ");
                newS.classes[index] = Input.getSubject();
                Console.WriteLine($"\n{newS.classes.Last()} updated!");
            }
            else Console.WriteLine($"\nYou aren't enrolled in {subject}.\nPlease make sure you have typed the name correctly.");
        }
    }

    public static void saveData(List<Person> people){
        List<Teacher> teachList = [];
        List<Student> studList = [];
        foreach(Person p in people){
            if (p is Teacher teach){
                teachList.Add(teach);
            }
            else if (p is Student stud) {
                studList.Add(stud);
            }
        }
        _ = Data.saveTeachers(teachList);
        _ = Data.saveStudents(studList);
    }

}