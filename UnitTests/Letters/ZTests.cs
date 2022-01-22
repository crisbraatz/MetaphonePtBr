using System.Text;
using FluentAssertions;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;
using Xunit;

namespace UnitTests.Letters;

public class ZTests
{
    [Theory]
    [InlineData(null, 'S')]
    [InlineData('A', 'Z')]
    public void Should_convert_letter(char? nextLetter, char expectedNewLetter)
    {
        var token = new StringBuilder();

        var obtainedIterationsBypass = Z.Convert(nextLetter, token);

        token.GetLetterAt()?.Should().Be(expectedNewLetter);
        obtainedIterationsBypass.Should().Be(0);
    }
}