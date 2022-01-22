using System.Text;
using FluentAssertions;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;
using Xunit;

namespace UnitTests.Letters;

public class TTests
{
    [Theory]
    [InlineData('H', 'T', 1)]
    [InlineData(null, 'T', 0)]
    [InlineData('B', 'T', 0)]
    public void Should_convert_letter(char? nextLetter, char expectedNewLetter, int expectedIterationsBypass)
    {
        var token = new StringBuilder();

        var obtainedIterationsBypass = T.Convert(nextLetter, token);

        token.GetLetterAt()?.Should().Be(expectedNewLetter);
        obtainedIterationsBypass.Should().Be(expectedIterationsBypass);
    }
}