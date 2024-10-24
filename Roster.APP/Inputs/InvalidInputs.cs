namespace Roster.APP.Inputs;

public static class InvalidInputs{
    public static string IsNull = "!\nInvalid Response: \'null value\'. Please try again.";

    public static string IsInvalid(string userInput){
        return $"!\nInvalid Response: \'{userInput}\'. Please try again.";
    }
}