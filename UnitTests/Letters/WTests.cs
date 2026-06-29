using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class WTests
{
    [Theory]
    [InlineData('L', 'V', 1)]
    [InlineData('R', 'V', 1)]
    [InlineData('A', 'V', 1)]
    [InlineData('E', 'V', 1)]
    [InlineData('I', 'V', 1)]
    [InlineData('O', 'V', 1)]
    [InlineData('U', 'V', 1)]
    [InlineData('B', null, 1)]
    [InlineData(null, 'W', 0)]
    public void ShouldConvertLetter(char? nextLetter, char? expectedLetter, int expectedIndex)
    {
        StringBuilder token = new();

        int returnedIndex = W.Convert(nextLetter, token);

        char? returnedLetter = token.GetCharAt();
        if (expectedLetter.HasValue)
        {
            Assert.True(returnedLetter.HasValue);
            Assert.Equal(expectedLetter.Value, returnedLetter.Value);
        }
        else
        {
            Assert.False(returnedLetter.HasValue);
            Assert.Equal(string.Empty, token.ToString());
        }

        Assert.Equal(expectedIndex, returnedIndex);
    }
}
