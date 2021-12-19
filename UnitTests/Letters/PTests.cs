using System.Text;
using FluentAssertions;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;
using Xunit;

namespace UnitTests.Letters
{
    public class PTests
    {
        [Theory]
        [InlineData('H', 'F', 1)]
        [InlineData(null, 'P', 0)]
        [InlineData('B', 'P', 0)]
        public void Should_convert_letter(char? nextLetter, char expectedNewLetter, int expectedIterationsBypass)
        {
            var token = new StringBuilder();

            var obtainedIterationsBypass = P.Convert(nextLetter, token);

            token.GetLetterAt()?.Should().Be(expectedNewLetter);
            obtainedIterationsBypass.Should().Be(expectedIterationsBypass);
        }
    }
}