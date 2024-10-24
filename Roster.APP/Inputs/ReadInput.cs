namespace Roster.APP.Inputs;

public class ReadInput{
    // Get the input from the user and check if valid

    public static string GetUserInput(){
        string? userInput = Console.ReadLine();
        return InputValidation.CheckString(userInput);
    }

    public static string GetUserInt(){
        string? userInput = Console.ReadLine();
        return InputValidation.CheckInt(userInput);
    }

    public static string GetUserInput(List<string> options){
        string? userInput = Console.ReadLine();
        string checkedString = InputValidation.CheckString(userInput);
        Tuple<bool, string> errorString = InputValidation.IsError(checkedString);
        if (errorString.Item1) return InvalidInputs.IsInvalid(userInput!);
        if (!options.Contains(checkedString)) return InvalidInputs.IsInvalid(checkedString);
        return checkedString;
    }

    public static string GetUserInt(List<int> options){
        string? userInput = Console.ReadLine();
        string checkedInt = InputValidation.CheckInt(userInput);
        Tuple<bool, string> errorString = InputValidation.IsError(checkedInt);
        if (errorString.Item1) return InvalidInputs.IsInvalid(userInput!);
        if (!options.Contains(int.Parse(checkedInt))) return InvalidInputs.IsInvalid(checkedInt);
        return checkedInt;
    }
}