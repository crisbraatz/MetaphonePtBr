using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class HTests
{
    [Theory]
    [InlineData(0, 'A', 'A', 1)]
    [InlineData(0, 'E', 'E', 1)]
    [InlineData(0, 'I', 'I', 1)]
    [InlineData(0, 'O', 'O', 1)]
    [InlineData(0, 'U', 'U', 1)]
    [InlineData(0, null, null, 0)]
    [InlineData(0, 'B', null, 0)]
    [InlineData(1, null, null, 0)]
    [InlineData(1, 'B', null, 0)]
    public void ShouldConvertLetter(int currentIndex, char? nextLetter, char? expectedLetter, int expectedIndex)
    {
        StringBuilder token = new();

        int returnedIndex = H.Convert(currentIndex, nextLetter, token);

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
