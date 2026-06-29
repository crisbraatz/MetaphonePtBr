using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class TTests
{
    [Theory]
    [InlineData('H', 'T', 1)]
    [InlineData(null, 'T', 0)]
    [InlineData('B', 'T', 0)]
    public void ShouldConvertLetter(char? nextLetter, char expectedLetter, int expectedIndex)
    {
        StringBuilder token = new();

        int returnedIndex = T.Convert(nextLetter, token);

        char? returnedLetter = token.GetCharAt();
        Assert.True(returnedLetter.HasValue);
        Assert.Equal(expectedLetter, returnedLetter.Value);
        Assert.Equal(expectedIndex, returnedIndex);
    }
}
