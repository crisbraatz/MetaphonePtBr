using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class ZTests
{
    [Theory]
    [InlineData(null, 'S')]
    [InlineData('A', 'Z')]
    public void ShouldConvertLetter(char? nextLetter, char expectedLetter)
    {
        StringBuilder token = new();

        Z.Convert(nextLetter, token);

        char? returnedLetter = token.GetCharAt();
        Assert.True(returnedLetter.HasValue);
        Assert.Equal(expectedLetter, returnedLetter.Value);
    }
}
