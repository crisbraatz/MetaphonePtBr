using System.Text;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class PTests
{
    [Theory]
    [InlineData('H', 'F', 1)]
    [InlineData(null, 'P', 0)]
    [InlineData('B', 'P', 0)]
    public void Should_convert_letter(char? nextLetter, char expectedNewLetter, int expectedIndex)
    {
        var token = new StringBuilder();

        var returnedIndex = P.Convert(nextLetter, token);

        token.GetLetterAt()?.Should().Be(expectedNewLetter);
        returnedIndex.Should().Be(expectedIndex);
    }
}