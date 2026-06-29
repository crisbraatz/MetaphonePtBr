using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class CTests
{
    [Theory]
    [InlineData('C', 'A', null, 'K', 1)]
    [InlineData('C', 'O', null, 'K', 1)]
    [InlineData('C', 'U', null, 'K', 1)]
    [InlineData('C', 'B', null, 'K', 1)]
    [InlineData('C', 'A', 'B', 'K', 1)]
    [InlineData('C', 'O', 'B', 'K', 1)]
    [InlineData('C', 'U', 'B', 'K', 1)]
    [InlineData('C', 'B', 'B', 'K', 1)]
    [InlineData('C', 'E', null, 'S', 1)]
    [InlineData('C', 'I', null, 'S', 1)]
    [InlineData('C', 'E', 'B', 'S', 1)]
    [InlineData('C', 'I', 'B', 'S', 1)]
    [InlineData('C', 'H', 'R', 'K', 2)]
    [InlineData('C', 'H', 'B', 'X', 1)]
    [InlineData('C', null, null, 'K', 0)]
    [InlineData('Ç', null, null, 'S', 0)]
    [InlineData('Ç', 'B', null, 'S', 0)]
    [InlineData('Ç', 'B', 'B', 'S', 0)]
    [InlineData('B', null, null, null, 0)]
    public void ShouldConvertLetter(
        char currentLetter, char? nextLetter, char? firstLetterAfterNext, char? expectedLetter, int expectedIndex)
    {
        StringBuilder token = new();

        int returnedIndex = C.Convert(currentLetter, nextLetter, firstLetterAfterNext, token);

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
