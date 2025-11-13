using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class QTests
{
    [Fact]
    public void ShouldConvertLetter()
    {
        StringBuilder token = new();

        Q.Convert(token);

        char? returnedLetter = token.GetCharAt();
        Assert.True(returnedLetter.HasValue);
        Assert.Equal('K', returnedLetter.Value);
    }
}
