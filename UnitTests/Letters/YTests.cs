using System.Text;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class YTests
{
    [Fact]
    public void Should_convert_letter()
    {
        var token = new StringBuilder();

        var returnedIndex = Y.Convert(token);

        token.GetLetterAt()?.Should().Be('I');
        returnedIndex.Should().Be(0);
    }
}