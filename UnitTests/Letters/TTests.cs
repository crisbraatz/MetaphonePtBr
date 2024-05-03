using System.Text;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class TTests
{
    [Theory]
    [InlineData('H', 'T', 1)]
    [InlineData(null, 'T', 0)]
    [InlineData('B', 'T', 0)]
    public void Should_convert_letter(char? nextLetter, char expectedNewLetter, int expectedIndex)
    {
        var token = new StringBuilder();

        var returnedIndex = T.Convert(nextLetter, token);

        token.GetLetterAt()?.Should().Be(expectedNewLetter);
        returnedIndex.Should().Be(expectedIndex);
    }
}