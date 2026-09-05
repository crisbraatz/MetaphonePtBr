using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class CTests
{
    [Theory]
    [InlineData('C', 'H', 'R', "K", 1)]
    [InlineData('C', 'H', 'B', "X", 1)]
    [InlineData('C', 'E', null, "S", 0)]
    [InlineData('C', 'I', 'B', "S", 0)]
    [InlineData('C', 'Q', null, "", 0)]
    [InlineData('C', 'K', null, "", 0)]
    [InlineData('C', 'A', null, "K", 0)]
    [InlineData('C', 'O', 'B', "K", 0)]
    [InlineData('C', 'U', null, "K", 0)]
    [InlineData('C', 'B', null, "K", 0)]
    [InlineData('C', null, null, "K", 0)]
    [InlineData('Ç', null, null, "S", 0)]
    [InlineData('Ç', 'B', null, "S", 0)]
    [InlineData('B', null, null, "", 0)]
    public void ShouldConvertLetter(
        char currentLetter, char? nextLetter, char? firstLetterAfterNext, string expectedToken, int expectedIndex)
    {
        RuleResult returnedRuleResult = C.Convert(currentLetter, nextLetter, firstLetterAfterNext);

        Assert.Equal(expectedToken, returnedRuleResult.Token);
        Assert.Equal(expectedIndex, returnedRuleResult.Consumed);
    }
}
