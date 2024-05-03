using System.Text;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class ZTests
{
    [Theory]
    [InlineData(null, 'S')]
    [InlineData('A', 'Z')]
    public void Should_convert_letter(char? nextLetter, char expectedNewLetter)
    {
        var token = new StringBuilder();

        var returnedIndex = Z.Convert(nextLetter, token);

        token.GetLetterAt()?.Should().Be(expectedNewLetter);
        returnedIndex.Should().Be(0);
    }
}