using System.Text;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class XTests
{
    [Theory]
    [InlineData(null, null, null, "X", 0)]
    [InlineData(null, 'A', null, "X", 0)]
    [InlineData('B', 'A', null, "X", 0)]
    [InlineData(null, 'E', 'A', "Z", 1)]
    [InlineData(null, 'E', 'E', "Z", 1)]
    [InlineData(null, 'E', 'I', "Z", 1)]
    [InlineData(null, 'E', 'O', "Z", 1)]
    [InlineData(null, 'E', 'U', "Z", 1)]
    [InlineData('B', 'E', 'A', "X", 1)]
    [InlineData('B', 'E', 'E', "X", 1)]
    [InlineData('B', 'E', 'I', "X", 1)]
    [InlineData('B', 'E', 'O', "X", 1)]
    [InlineData('B', 'E', 'U', "X", 1)]
    [InlineData('C', 'A', null, "X", 0)]
    [InlineData('G', 'I', null, "X", 0)]
    [InlineData('K', 'O', null, "X", 0)]
    [InlineData('L', 'U', null, "X", 0)]
    [InlineData('R', 'A', null, "X", 0)]
    [InlineData('X', 'I', null, "X", 0)]
    [InlineData('A', 'O', null, "X", 0)]
    [InlineData('E', 'U', null, "X", 0)]
    [InlineData('I', 'A', null, "X", 0)]
    [InlineData('O', 'I', null, "X", 0)]
    [InlineData('U', 'O', null, "X", 0)]
    [InlineData('C', 'A', 'B', "X", 0)]
    [InlineData('G', 'I', 'B', "X", 0)]
    [InlineData('K', 'O', 'B', "X", 0)]
    [InlineData('L', 'U', 'B', "X", 0)]
    [InlineData('R', 'A', 'B', "X", 0)]
    [InlineData('X', 'I', 'B', "X", 0)]
    [InlineData('A', 'O', 'B', "X", 0)]
    [InlineData('E', 'U', 'B', "X", 0)]
    [InlineData('I', 'A', 'B', "X", 0)]
    [InlineData('O', 'I', 'B', "X", 0)]
    [InlineData('U', 'O', 'B', "X", 0)]
    [InlineData('D', 'A', null, "KS", 0)]
    [InlineData('F', 'I', null, "KS", 0)]
    [InlineData('M', 'O', null, "KS", 0)]
    [InlineData('N', 'U', null, "KS", 0)]
    [InlineData('P', 'A', null, "KS", 0)]
    [InlineData('Q', 'I', null, "KS", 0)]
    [InlineData('S', 'O', null, "KS", 0)]
    [InlineData('T', 'U', null, "KS", 0)]
    [InlineData('V', 'A', null, "KS", 0)]
    [InlineData('Z', 'I', null, "KS", 0)]
    [InlineData('D', 'A', 'B', "KS", 0)]
    [InlineData('F', 'I', 'B', "KS", 0)]
    [InlineData('M', 'O', 'B', "KS", 0)]
    [InlineData('N', 'U', 'B', "KS", 0)]
    [InlineData('P', 'A', 'B', "KS", 0)]
    [InlineData('Q', 'I', 'B', "KS", 0)]
    [InlineData('S', 'O', 'B', "KS", 0)]
    [InlineData('T', 'U', 'B', "KS", 0)]
    [InlineData('V', 'A', 'B', "KS", 0)]
    [InlineData('Z', 'I', 'B', "KS", 0)]
    [InlineData('B', 'E', 'C', "S", 1)]
    [InlineData('B', 'E', 'P', "S", 1)]
    [InlineData('B', 'E', 'T', "S", 1)]
    [InlineData('B', 'E', 'B', "KS", 1)]
    public void Should_convert_letter(
        char? firstLetterBeforePrevious,
        char? previousLetter,
        char? nextLetter,
        string expectedNewLetters,
        int expectedIterationsBypass)
    {
        var token = new StringBuilder();

        var obtainedIterationsBypass = X.Convert(firstLetterBeforePrevious, previousLetter, nextLetter, token);

        token.ToString().Should().Be(expectedNewLetters);
        obtainedIterationsBypass.Should().Be(expectedIterationsBypass);
    }
}