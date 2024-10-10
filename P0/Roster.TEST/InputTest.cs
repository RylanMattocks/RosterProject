namespace Roster.TEST;

using System.Diagnostics;
using Roster.APP;
public class InputTest
{
    [Theory]
    [InlineData("test", new string[] {"test", "open", "1"}, true)]
    [InlineData("", new string[] {"test", "open", "1"}, false)]
    [InlineData("not", new string[] {"test", "open", "1"}, false)]
    [InlineData( "test" , new string[] {}, false)]
    public void TestUserInputIsCorrect(string input, string[] options, bool expected)
    {
        bool actual = Input.checkCorrect(input, [.. options]);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("test", false)]
    [InlineData(null, true)]
    [InlineData("", true)]
    public void TestUserInputIsNotNullOrEmpty(string input, bool expected)
    {
        bool actual = Input.checkNull(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, new string[] {"test"}, "test")]
    [InlineData(0, new string[] {"testo"}, "")]
    [InlineData(0, new string[] {"arm", "test"}, "test")]
    [InlineData(1, new string[] {"test"}, "")]
    [InlineData(1, new string[] {}, "")]
    [InlineData(2, new string[] {"test"}, "")]
    [InlineData(2, new string[] {"arm", "test"}, "")]
    [InlineData(2, new string[] {}, "")]
    [InlineData(3, new string[] {"test"}, "")]
    [InlineData(3, new string[] {"arm", "test"}, "")]
    [InlineData(3, new string[] {}, "")]

    public void TestGettingValidUserInput(int index, string[] options, string expected)
    {
        Input testRead = new();
        string? actual = testRead.getUserInput([.. options], index);
        Assert.Equal(expected, actual);
    }
}