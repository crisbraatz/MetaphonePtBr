using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class VowelsTests
{
    [Theory]
    [InlineData(0, 'A', 'A')]
    [InlineData(0, 'E', 'E')]
    [InlineData(0, 'I', 'I')]
    [InlineData(0, 'O', 'O')]
    [InlineData(0, 'U', 'U')]
    [InlineData(1, 'A', null)]
    public void ShouldConvertLetter(int currentIndex, char currentLetter, char? expectedLetter)
    {
        StringBuilder token = new();

        Vowels.Convert(currentIndex, currentLetter, token);

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
