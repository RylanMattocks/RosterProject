using System.Text.RegularExpressions;

namespace Roster.APP;
public static class Cleaner {

    public static string Clean(string str){
        string cleanString = str.Trim().ToLower();
        return cleanString;
    }

    public static string Upper(string str){
        string upperString = $"{char.ToUpper(str[0])}{str[1..]}";
        return upperString;
    }

    public static bool checkRegex(string str){
        return Regex.IsMatch(str, @"^[a-zA-Z]+$");
    }
}