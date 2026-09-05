using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class YTests
{
    [Fact]
    public void ShouldConvertLetter()
    {
        RuleResult returnedRuleResult = Y.Convert();

        Assert.Equal("I", returnedRuleResult.Token);
        Assert.Equal(0, returnedRuleResult.Consumed);
    }
}
