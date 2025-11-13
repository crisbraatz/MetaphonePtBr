using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class ImmutablesTests
{
    [Theory]
    [InlineData('A', null)]
    [InlineData('B', 'B')]
    [InlineData('C', null)]
    [InlineData('D', 'D')]
    [InlineData('E', null)]
    [InlineData('F', 'F')]
    [InlineData('G', null)]
    [InlineData('H', null)]
    [InlineData('I', null)]
    [InlineData('J', 'J')]
    [InlineData('K', 'K')]
    [InlineData('L', null)]
    [InlineData('M', 'M')]
    [InlineData('N', null)]
    [InlineData('O', null)]
    [InlineData('P', null)]
    [InlineData('Q', null)]
    [InlineData('R', null)]
    [InlineData('S', null)]
    [InlineData('T', null)]
    [InlineData('U', null)]
    [InlineData('V', 'V')]
    [InlineData('W', null)]
    [InlineData('X', null)]
    [InlineData('Y', null)]
    [InlineData('Z', null)]
    public void ShouldConvertLetter(char currentLetter, char? expectedLetter)
    {
        StringBuilder token = new();

        Immutables.Convert(currentLetter, token);

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
    }
}
