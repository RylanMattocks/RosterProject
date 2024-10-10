namespace Roster.APP;

// Class to help with testing
public static class Terminal{
   
    public static string? Read(int index){
        List<string> testCases = [
            "test",
            "ttse",
            "",
            null,
        ];
        return testCases[index];
    }
    
}