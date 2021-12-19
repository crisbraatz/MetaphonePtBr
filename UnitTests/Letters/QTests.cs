using System.Text;
using FluentAssertions;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;
using Xunit;

namespace UnitTests.Letters
{
    public class QTests
    {
        [Fact]
        public void Should_convert_letter()
        {
            var token = new StringBuilder();

            var obtainedIterationsBypass = Q.Convert(token);

            token.GetLetterAt()?.Should().Be('K');
            obtainedIterationsBypass.Should().Be(0);
        }
    }
}