using System.Text;
using MetaphonePtBr.Letters;

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