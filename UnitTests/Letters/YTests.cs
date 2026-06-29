using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class YTests
{
    [Fact]
    public void ShouldConvertLetter()
    {
        StringBuilder token = new();

        Y.Convert(token);

        char? returnedLetter = token.GetCharAt();
        Assert.True(returnedLetter.HasValue);
        Assert.Equal('I', returnedLetter.Value);
    }
}
