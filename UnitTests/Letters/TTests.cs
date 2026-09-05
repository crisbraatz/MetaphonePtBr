using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class TTests
{
    [Theory]
    [InlineData('H', "T", 1)]
    [InlineData(null, "T", 0)]
    [InlineData('B', "T", 0)]
    public void ShouldConvertLetter(char? nextLetter, string expectedToken, int expectedIndex)
    {
        RuleResult returnedRuleResult = T.Convert(nextLetter);

        Assert.Equal(expectedToken, returnedRuleResult.Token);
        Assert.Equal(expectedIndex, returnedRuleResult.Consumed);
    }
}
