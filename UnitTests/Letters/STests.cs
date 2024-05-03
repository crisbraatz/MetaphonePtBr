using System.Text;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class STests
{
    [Theory]
    [InlineData('H', null, "X", 1)]
    [InlineData('C', 'E', "S", 2)]
    [InlineData('C', 'I', "S", 2)]
    [InlineData('C', 'A', "SK", 2)]
    [InlineData('C', 'O', "SK", 2)]
    [InlineData('C', 'U', "SK", 2)]
    [InlineData('C', 'H', "X", 2)]
    [InlineData('C', 'B', "S", 1)]
    [InlineData('B', null, "S", 1)]
    [InlineData('B', 'A', "S", 1)]
    [InlineData('A', null, "S", 0)]
    [InlineData('A', 'B', "S", 0)]
    [InlineData(null, null, "S", 0)]
    public void Should_convert_letter(
        char? nextLetter, char? firstLetterAfterNext, string expectedNewLetters, int expectedIndex)
    {
        var token = new StringBuilder();

        var returnedIndex = S.Convert(nextLetter, firstLetterAfterNext, token);

        token.ToString().Should().Be(expectedNewLetters);
        returnedIndex.Should().Be(expectedIndex);
    }
}