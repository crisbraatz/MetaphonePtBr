using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class RTests
{
    [Theory]
    [InlineData(null, null, null, 0)]
    [InlineData(null, 'B', null, 0)]
    [InlineData('B', null, null, 0)]
    [InlineData(null, 'R', null, 0)]
    [InlineData('B', 'R', null, 1)]
    [InlineData('B', 'B', 'R', 0)]
    public void ShouldConvertLetter(char? previousLetter, char? nextLetter, char? expectedLetter, int expectedIndex)
    {
        StringBuilder token = new();

        int returnedIndex = R.Convert(previousLetter, nextLetter, token);

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
