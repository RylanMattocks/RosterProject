using System.Text.RegularExpressions;
using Roster.APP.DataStorage;
namespace Roster.APP.Inputs;

public static class InputValidation{

    private static readonly string Confirmation = "\nDoes this input look correct: {0}" +
                                                    "\n1. Yes                           2. No";
    private static readonly List<string> Options = ["1", "Yes", "2", "No"];
    public static string CheckString(string? userInput){
        if (String.IsNullOrEmpty(userInput)) return InvalidInputs.IsNull;
        if (!CheckRegex(userInput)) return InvalidInputs.IsInvalid(userInput);
        string cleanInput = Cleaner.Clean(userInput);
        CheckExit(cleanInput);
        return cleanInput;
    }

    public static string CheckInt(string? userInput){
        if (string.IsNullOrEmpty(userInput)) return InvalidInputs.IsNull;
        string cleanInput = Cleaner.Clean(userInput);
        CheckExit(cleanInput);
        if (TryParse(cleanInput)) return cleanInput;
        else return InvalidInputs.IsInvalid(userInput);
    }

    private static bool TryParse(string userInput){
        try{
            int userInt = int.Parse(userInput);
            return true;
        }
        catch(Exception){
            return false;
        }
    }

    private static void CheckExit(string userInput){
        if (userInput == "Exit") {
            Data.SaveData();
            Environment.Exit(0);
        }
    }

    private static bool CheckRegex(string userInput){
        return Regex.IsMatch(userInput, @"^[a-zA-Z]+$");
    }

    public static Tuple<bool, string> IsError(string userInput){
        if (userInput[0] == '!'){
            return Tuple.Create(true, userInput[1..]);
        }
        return Tuple.Create(false,userInput);
    }

    public static string CheckAge(int userInt){
        if (userInt <= 100 && userInt >= 1) return userInt.ToString();
        return InvalidInputs.IsInvalid(userInt.ToString());
    }

    public static bool ConfirmInput(string inputToConfirm){
        object[] formatStrings = [inputToConfirm];
        Console.WriteLine(String.Format(Confirmation, formatStrings));
        string userInput = ReadInput.GetUserInput(Options);
        Tuple<bool, string> errorString = InputValidation.IsError(userInput);
            if (errorString.Item1){
                Console.WriteLine(errorString.Item2);
                return ConfirmInput(inputToConfirm);
            }
        if (userInput == Options[0] || userInput == Options[1]){
            return true;
        }
        else /*(userInput == Options[2] || userInput == Options[3])*/{
            return false;
        }
    }
}