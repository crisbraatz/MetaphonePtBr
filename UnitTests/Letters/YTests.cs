using System.Text;
using FluentAssertions;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;
using Xunit;

namespace UnitTests.Letters;

public class YTests
{
    [Fact]
    public void Should_convert_letter()
    {
        var token = new StringBuilder();

        var obtainedIterationsBypass = Y.Convert(token);

        token.GetLetterAt()?.Should().Be('I');
        obtainedIterationsBypass.Should().Be(0);
    }
}