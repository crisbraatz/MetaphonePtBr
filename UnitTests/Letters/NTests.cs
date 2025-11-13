using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class NTests
{
    [Theory]
    [InlineData(null, 'M')]
    [InlineData('H', null)]
    [InlineData('B', 'N')]
    public void ShouldConvertLetter(char? nextLetter, char? expectedLetter)
    {
        StringBuilder token = new();

        N.Convert(nextLetter, token);

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
