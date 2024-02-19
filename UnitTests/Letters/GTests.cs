using System.Text;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class GTests
{
    [Theory]
    [InlineData('A', null, 'G', 1)]
    [InlineData('O', null, 'G', 1)]
    [InlineData('U', null, 'G', 1)]
    [InlineData('A', 'B', 'G', 1)]
    [InlineData('O', 'B', 'G', 1)]
    [InlineData('U', 'B', 'G', 1)]
    [InlineData('E', null, 'J', 1)]
    [InlineData('I', null, 'J', 1)]
    [InlineData('E', 'B', 'J', 1)]
    [InlineData('I', 'B', 'J', 1)]
    [InlineData('H', 'E', 'J', 2)]
    [InlineData('H', 'I', 'J', 2)]
    [InlineData('H', 'B', 'G', 2)]
    [InlineData(null, null, 'G', 0)]
    [InlineData('B', null, 'G', 0)]
    [InlineData('B', 'B', 'G', 0)]
    public void Should_convert_letter(
        char? nextLetter, char? firstLetterAfterNext, char expectedNewLetter, int expectedIterationsBypass)
    {
        var token = new StringBuilder();

        var obtainedIterationsBypass = G.Convert(nextLetter, firstLetterAfterNext, token);

        token.GetLetterAt()?.Should().Be(expectedNewLetter);
        obtainedIterationsBypass.Should().Be(expectedIterationsBypass);
    }
}