using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class GTests
{
    [Theory]
    [InlineData('A', null, 'G', 1)]
    [InlineData('O', null, 'G', 1)]
    [InlineData('U', null, 'G', 1)]
    [InlineData('A', 'B', 'G', 1)]
    [InlineData('O', 'B', 'G', 1)]
    [InlineData('U', 'B', 'G', 1)]
    [InlineData('E', null, 'J', 1)]
    [InlineData('I', null, 'J', 1)]
    [InlineData('E', 'B', 'J', 1)]
    [InlineData('I', 'B', 'J', 1)]
    [InlineData('H', 'E', 'J', 2)]
    [InlineData('H', 'I', 'J', 2)]
    [InlineData('H', 'B', 'G', 2)]
    [InlineData(null, null, 'G', 0)]
    [InlineData('B', null, 'G', 0)]
    [InlineData('B', 'B', 'G', 0)]
    public void ShouldConvertLetter(
        char? nextLetter, char? firstLetterAfterNext, char expectedLetter, int expectedIndex)
    {
        StringBuilder token = new();

        int returnedIndex = G.Convert(nextLetter, firstLetterAfterNext, token);

        char? returnedLetter = token.GetCharAt();
        Assert.True(returnedLetter.HasValue);
        Assert.Equal(expectedLetter, returnedLetter.Value);
        Assert.Equal(expectedIndex, returnedIndex);
    }
}
