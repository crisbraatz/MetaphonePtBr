using System.Text;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class ImmutablesTests
{
    [Theory]
    [InlineData('A', null)]
    [InlineData('B', 'B')]
    [InlineData('C', null)]
    [InlineData('D', 'D')]
    [InlineData('E', null)]
    [InlineData('F', 'F')]
    [InlineData('G', null)]
    [InlineData('H', null)]
    [InlineData('I', null)]
    [InlineData('J', 'J')]
    [InlineData('K', 'K')]
    [InlineData('L', null)]
    [InlineData('M', 'M')]
    [InlineData('N', null)]
    [InlineData('O', null)]
    [InlineData('P', null)]
    [InlineData('Q', null)]
    [InlineData('R', null)]
    [InlineData('S', null)]
    [InlineData('T', null)]
    [InlineData('U', null)]
    [InlineData('V', 'V')]
    [InlineData('W', null)]
    [InlineData('X', null)]
    [InlineData('Y', null)]
    [InlineData('Z', null)]
    public void Should_convert_letter(char currentLetter, char? expectedNewLetter)
    {
        var token = new StringBuilder();

        var obtainedIterationsBypass = Immutables.Convert(currentLetter, token);

        if (expectedNewLetter.HasValue)
            token.GetLetterAt()?.Should().Be(expectedNewLetter.Value);
        else
            token.ToString().Should().BeEmpty();
        obtainedIterationsBypass.Should().Be(0);
    }
}