using System.Text;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class CTests
{
    [Theory]
    [InlineData('C', 'A', null, 'K', 1)]
    [InlineData('C', 'O', null, 'K', 1)]
    [InlineData('C', 'U', null, 'K', 1)]
    [InlineData('C', 'B', null, 'K', 1)]
    [InlineData('C', 'A', 'B', 'K', 1)]
    [InlineData('C', 'O', 'B', 'K', 1)]
    [InlineData('C', 'U', 'B', 'K', 1)]
    [InlineData('C', 'B', 'B', 'K', 1)]
    [InlineData('C', 'E', null, 'S', 1)]
    [InlineData('C', 'I', null, 'S', 1)]
    [InlineData('C', 'E', 'B', 'S', 1)]
    [InlineData('C', 'I', 'B', 'S', 1)]
    [InlineData('C', 'H', 'R', 'K', 2)]
    [InlineData('C', 'H', 'B', 'X', 1)]
    [InlineData('C', null, null, 'K', 0)]
    [InlineData('Ç', null, null, 'S', 0)]
    [InlineData('Ç', 'B', null, 'S', 0)]
    [InlineData('Ç', 'B', 'B', 'S', 0)]
    [InlineData('B', null, null, null, 0)]
    public void Should_convert_letter(
        char currentLetter,
        char? nextLetter,
        char? firstLetterAfterNext,
        char? expectedNewLetter,
        int expectedIterationsBypass)
    {
        var token = new StringBuilder();

        var obtainedIterationsBypass = C.Convert(currentLetter, nextLetter, firstLetterAfterNext, token);

        if (expectedNewLetter.HasValue)
            token.GetLetterAt()?.Should().Be(expectedNewLetter.Value);
        obtainedIterationsBypass.Should().Be(expectedIterationsBypass);
    }
}