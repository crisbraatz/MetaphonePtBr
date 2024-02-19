using System.Text;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class LTests
{
    [Theory]
    [InlineData('A', 'A', 1)]
    [InlineData('B', 'L', 0)]
    [InlineData('E', 'E', 1)]
    [InlineData('H', null, 1)]
    [InlineData('I', 'I', 1)]
    [InlineData('O', 'O', 1)]
    [InlineData('U', 'U', 1)]
    public void Should_convert_letter(char? nextLetter, char? expectedNewLetter, int expectedIterationsBypass)
    {
        var token = new StringBuilder();

        var obtainedIterationsBypass = L.Convert(nextLetter, token);

        if (expectedNewLetter.HasValue)
            token.GetLetterAt()?.Should().Be(expectedNewLetter.Value);
        else
            token.ToString().Should().BeEmpty();
        obtainedIterationsBypass.Should().Be(expectedIterationsBypass);
    }
}