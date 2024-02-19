using System.Text;

namespace UnitTests.Extensions;

public class StringBuilderExtensionTests
{
    [Theory]
    [InlineData(0, true, 'W')]
    [InlineData(3, true, 'D')]
    [InlineData(-1, false, null)]
    [InlineData(4, false, null)]
    public void Should_get_letter_at_desired_index(int desiredIndex, bool expectedHasValue, char? expectedLetter)
    {
        var obtainedLetter = new StringBuilder("WORD").GetLetterAt(desiredIndex);

        obtainedLetter.HasValue.Should().Be(expectedHasValue);
        if (expectedLetter.HasValue)
            obtainedLetter?.Should().Be(expectedLetter.Value);
    }
}