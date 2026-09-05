using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class ZTests
{
    [Theory]
    [InlineData(null, "S")]
    [InlineData('A', "Z")]
    public void ShouldConvertLetter(char? nextLetter, string expectedToken)
    {
        RuleResult returnedRuleResult = Z.Convert(nextLetter);

        Assert.Equal(expectedToken, returnedRuleResult.Token);
        Assert.Equal(0, returnedRuleResult.Consumed);
    }
}
