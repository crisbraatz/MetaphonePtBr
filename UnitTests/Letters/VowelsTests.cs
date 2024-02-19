using System.Text;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class VowelsTests
{
    [Theory]
    [InlineData(0, 'A', 'A')]
    [InlineData(0, 'E', 'E')]
    [InlineData(0, 'I', 'I')]
    [InlineData(0, 'O', 'O')]
    [InlineData(0, 'U', 'U')]
    [InlineData(1, 'A', null)]
    public void Should_convert_letter(int currentIndex, char currentLetter, char? expectedNewLetter)
    {
        var token = new StringBuilder();

        var obtainedIterationsBypass = Vowels.Convert(currentIndex, currentLetter, token);

        if (expectedNewLetter.HasValue)
            token.GetLetterAt()?.Should().Be(expectedNewLetter.Value);
        else
            token.ToString().Should().BeEmpty();
        obtainedIterationsBypass.Should().Be(0);
    }
}