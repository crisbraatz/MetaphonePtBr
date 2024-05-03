using System.Text;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class RTests
{
    [Theory]
    [InlineData(null, null, null, 0)]
    [InlineData(null, 'B', null, 0)]
    [InlineData('B', null, null, 0)]
    [InlineData(null, 'R', null, 0)]
    [InlineData('B', 'R', null, 1)]
    [InlineData('B', 'B', 'R', 0)]
    public void Should_convert_letter(
        char? previousLetter, char? nextLetter, char? expectedNewLetter, int expectedIndex)
    {
        var token = new StringBuilder();

        var returnedIndex = R.Convert(previousLetter, nextLetter, token);

        if (expectedNewLetter.HasValue)
            token.GetLetterAt()?.Should().Be(expectedNewLetter.Value);
        else
            token.ToString().Should().BeEmpty();
        returnedIndex.Should().Be(expectedIndex);
    }
}