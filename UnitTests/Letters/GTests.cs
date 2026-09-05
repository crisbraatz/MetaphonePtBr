using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class GTests
{
    [Theory]
    [InlineData('H', 'A', "J", 0)]
    [InlineData('H', 'E', "J", 0)]
    [InlineData('H', 'I', "J", 0)]
    [InlineData('H', 'B', "GJ", 0)]
    [InlineData('H', null, "GJ", 0)]
    [InlineData('E', null, "J", 0)]
    [InlineData('I', 'B', "J", 0)]
    [InlineData('A', null, "G", 0)]
    [InlineData('O', 'B', "G", 0)]
    [InlineData('U', null, "G", 0)]
    [InlineData('B', null, "G", 0)]
    [InlineData(null, null, "G", 0)]
    public void ShouldConvertLetter(
        char? nextLetter, char? firstLetterAfterNext, string expectedToken, int expectedIndex)
    {
        RuleResult returnedRuleResult = G.Convert(nextLetter, firstLetterAfterNext);

        Assert.Equal(expectedToken, returnedRuleResult.Token);
        Assert.Equal(expectedIndex, returnedRuleResult.Consumed);
    }
}
