using Roster.APP.Inputs;
namespace Roster.TEST;

public class InputTests
{

    // Cleaner Tests
    [Theory]
    [InlineData("string", "String")]
    [InlineData("sTrIng", "String")]
    [InlineData("String", "String")]
    [InlineData("STRING", "String")]
    [InlineData("STRING  ", "String")]
    [InlineData("  STRING", "String")]
    [InlineData(" STRING ", "String")]
    public void TestToMakeSureStringReturnsTrimmedAndCapitalFirstLetter(string str, string expected)
    {
        string actual = Cleaner.Clean(str);
        Assert.Equal(expected, actual);
    }

    // InputValidation Tests
    [Theory]
    [InlineData("!0", true, "0")]
    [InlineData("1", false, "1")]
    [InlineData("!1", true, "1")]
    [InlineData("pass", false, "pass")]
    [InlineData("string", false, "string")]
    [InlineData("!str123", true, "str123")]
    [InlineData("123str", false, "123str")]
    public void TestIfStringIsMarkedAsError(string input, bool expectedBool, string expectedStr)
    {
        Tuple<bool, string> expected = Tuple.Create(expectedBool, expectedStr);
        Tuple<bool, string> actual = InputValidation.IsError(input);
        Assert.Equal(expected, actual);
    }
}