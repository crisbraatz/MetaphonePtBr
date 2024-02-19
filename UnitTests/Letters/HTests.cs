using System.Text;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class HTests
{
    [Theory]
    [InlineData(0, 'A', 'A', 1)]
    [InlineData(0, 'E', 'E', 1)]
    [InlineData(0, 'I', 'I', 1)]
    [InlineData(0, 'O', 'O', 1)]
    [InlineData(0, 'U', 'U', 1)]
    [InlineData(0, null, null, 0)]
    [InlineData(0, 'B', null, 0)]
    [InlineData(1, null, null, 0)]
    [InlineData(1, 'B', null, 0)]
    public void Should_convert_letter(
        int currentIndex, char? nextLetter, char? expectedNewLetter, int expectedIterationsBypass)
    {
        var token = new StringBuilder();

        var obtainedIterationsBypass = H.Convert(currentIndex, nextLetter, token);

        if (expectedNewLetter.HasValue)
            token.GetLetterAt()?.Should().Be(expectedNewLetter.Value);
        else
            token.ToString().Should().BeEmpty();
        obtainedIterationsBypass.Should().Be(expectedIterationsBypass);
    }
}