using System.Text;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class NTests
{
    [Theory]
    [InlineData(null, 'M')]
    [InlineData('H', null)]
    [InlineData('B', 'N')]
    public void Should_convert_letter(char? nextLetter, char? expectedNewLetter)
    {
        var token = new StringBuilder();

        var obtainedIterationsBypass = N.Convert(nextLetter, token);

        if (expectedNewLetter.HasValue)
            token.GetLetterAt()?.Should().Be(expectedNewLetter.Value);
        else
            token.ToString().Should().BeEmpty();
        obtainedIterationsBypass.Should().Be(0);
    }
}