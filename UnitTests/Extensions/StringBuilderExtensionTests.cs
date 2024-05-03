using System.Text;

namespace UnitTests.Extensions;

public class StringBuilderExtensionTests
{
    [Theory]
    [InlineData(0, true, 'W')]
    [InlineData(3, true, 'D')]
    [InlineData(-1, false, null)]
    [InlineData(4, false, null)]
    public void Should_get_letter_at_index(int index, bool expectedHasValue, char? expectedLetter)
    {
        var returnedLetter = new StringBuilder("WORD").GetLetterAt(index);

        returnedLetter.HasValue.Should().Be(expectedHasValue);
        if (expectedLetter.HasValue)
            returnedLetter?.Should().Be(expectedLetter.Value);
    }
}