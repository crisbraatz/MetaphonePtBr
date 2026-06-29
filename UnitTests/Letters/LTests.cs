using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class LTests
{
    [Theory]
    [InlineData('A', 'A', 1)]
    [InlineData('B', 'L', 0)]
    [InlineData('E', 'E', 1)]
    [InlineData('H', null, 1)]
    [InlineData('I', 'I', 1)]
    [InlineData('O', 'O', 1)]
    [InlineData('U', 'U', 1)]
    public void ShouldConvertLetter(char nextLetter, char? expectedLetter, int expectedIndex)
    {
        StringBuilder token = new();

        int returnedIndex = L.Convert(nextLetter, token);

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
