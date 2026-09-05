using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class STests
{
    [Theory]
    [InlineData('A', 'S', null, "S", 1)]
    [InlineData('A', 'H', null, "X", 1)]
    [InlineData('A', 'A', null, "Z", 0)]
    [InlineData('E', 'E', null, "Z", 0)]
    [InlineData('I', 'I', null, "Z", 0)]
    [InlineData('O', 'O', null, "Z", 0)]
    [InlineData('U', 'U', null, "Z", 0)]
    [InlineData('A', 'C', 'E', "S", 2)]
    [InlineData('A', 'C', 'I', "S", 2)]
    [InlineData('A', 'C', 'A', "SK", 2)]
    [InlineData('A', 'C', 'O', "SK", 2)]
    [InlineData('A', 'C', 'U', "SK", 2)]
    [InlineData('A', 'C', 'H', "X", 2)]
    [InlineData('A', 'C', 'B', "S", 1)]
    [InlineData(null, 'B', null, "S", 0)]
    [InlineData('A', 'B', null, "S", 0)]
    [InlineData('B', 'A', null, "S", 0)]
    [InlineData('B', null, null, "S", 0)]
    public void ShouldConvertLetter(
        char? previousLetter, char? nextLetter, char? firstLetterAfterNext, string expectedToken, int expectedIndex)
    {
        RuleResult returnedRuleResult = S.Convert(previousLetter, nextLetter, firstLetterAfterNext);

        Assert.Equal(expectedToken, returnedRuleResult.Token);
        Assert.Equal(expectedIndex, returnedRuleResult.Consumed);
    }
}
