using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class PTests
{
    [Theory]
    [InlineData('H', 'F', 1)]
    [InlineData(null, 'P', 0)]
    [InlineData('B', 'P', 0)]
    public void ShouldConvertLetter(char? nextLetter, char expectedLetter, int expectedIndex)
    {
        StringBuilder token = new();

        int returnedIndex = P.Convert(nextLetter, token);

        char? returnedLetter = token.GetCharAt();
        Assert.True(returnedLetter.HasValue);
        Assert.Equal(expectedLetter, returnedLetter.Value);
        Assert.Equal(expectedIndex, returnedIndex);
    }
}
