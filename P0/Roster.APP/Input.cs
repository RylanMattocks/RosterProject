namespace Roster.APP;

public class Input{
    // Get the input from the user and check if valid

    public static string getUserInput(string message){
        Console.WriteLine("\n" + message);
        string? userInput = Console.ReadLine();
        checkExit(userInput);
        if (checkBack(userInput)) return "back";
        else if (checkNull(userInput)){
            Console.WriteLine("\nInvalid Response: \'null value\'. Please try again.");
            return getUserInput(message);
        }
        else {
            userInput = Cleaner.Clean(userInput!);
            if (Cleaner.checkRegex(userInput!)) return userInput!;
            else{
                Console.WriteLine($"\nInvalid Response: \'{userInput}\'. Please try again.");
                return getUserInput(message);
            }
        }
    }
    public static string getUserInput(string message, List<string> options){
        Console.WriteLine("\n" + message);
        string? userInput = Console.ReadLine();
        checkExit(userInput);
        if (checkBack(userInput)) return "back";
        else if (checkNull(userInput)){
            Console.WriteLine("\nInvalid Response: \'null value\'. Please try again.");
            return getUserInput(message, options);
        }
        else{
            userInput = Cleaner.Clean(userInput!);
            if (checkCorrect(userInput!, options)) return userInput!;
            else{
                Console.WriteLine($"\nInvalid Response: \'{userInput}\'. Please try again.");
                return getUserInput(message, options);
            }
        }
    }
    // Check if input is null
    public static bool checkNull(string? input){
        return String.IsNullOrEmpty(input);
    }

    // Check if input is valid
    public static bool checkCorrect(string input, List<string> options){
        return options.Contains(Cleaner.Clean(input));
    }
    public static void checkExit(string? input){
        if (!checkNull(input)){
            if (Cleaner.Clean(input!) == "exit") Environment.Exit(0);
        }
    }

    public static bool checkBack(string? input){
        if (!checkNull(input)){
            if (Cleaner.Clean(input!) == "back") return true;
        }
        return false;
    }
    public static int getAge(){
        string message = "Please enter age (0-100): ";
        List<string> options = [];
        for (int i = 0; i <= 100; i++){
            options.Add(i.ToString());
        }
        string? strAge = getUserInput(message, options);

        try{
            int age = int.Parse(Cleaner.Clean(strAge!));
            if (age <= 100 && age >= 0) return age;
            else{
                Console.WriteLine($"\nInvalid Response: \'{age}\'. Please try again!");
                return getAge();
            }
        }
        catch(Exception)
        {
            Console.WriteLine($"\nInvalid Response: \'{strAge}\'. Please try again!");
            getAge();
            return getAge();
        }
    }

    public static string getSubject(){
        string message = "Please enter your subject: ";
        string? subject = getUserInput(message);
        return Cleaner.Upper(subject);
    }











    // Overloaded Method for unit testing purposes
    
    public string getUserInput(List<string> options, int index){
        string? userInput = Terminal.Read(index);
        checkExit(userInput);
        if (checkNull(userInput)){
            return "";
        }
        else{
            userInput = Cleaner.Clean(userInput!);
            if (checkCorrect(userInput!, options)) return userInput!;
            else return "";
        }
    }
    

}