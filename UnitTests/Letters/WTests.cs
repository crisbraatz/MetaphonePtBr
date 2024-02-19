using System.Text;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class WTests
{
    [Theory]
    [InlineData('L', 'V', 1)]
    [InlineData('R', 'V', 1)]
    [InlineData('A', 'V', 1)]
    [InlineData('E', 'V', 1)]
    [InlineData('I', 'V', 1)]
    [InlineData('O', 'V', 1)]
    [InlineData('U', 'V', 1)]
    [InlineData('B', null, 1)]
    [InlineData(null, 'W', 0)]
    public void Should_convert_letter(char? nextLetter, char? expectedNewLetter, int expectedIterationsBypass)
    {
        var token = new StringBuilder();

        var obtainedIterationsBypass = W.Convert(nextLetter, token);

        if (expectedNewLetter.HasValue)
            token.GetLetterAt()?.Should().Be(expectedNewLetter.Value);
        else
            token.ToString().Should().BeEmpty();
        obtainedIterationsBypass.Should().Be(expectedIterationsBypass);
    }
}