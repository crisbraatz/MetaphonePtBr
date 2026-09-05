using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class QTests
{
    [Fact]
    public void ShouldConvertLetter()
    {
        RuleResult returnedRuleResult = Q.Convert();

        Assert.Equal("K", returnedRuleResult.Token);
        Assert.Equal(0, returnedRuleResult.Consumed);
    }
}
