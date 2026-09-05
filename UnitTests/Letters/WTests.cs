using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class WTests
{
    [Theory]
    [InlineData('A', "V", 0)]
    [InlineData('E', "V", 0)]
    [InlineData('I', "V", 0)]
    [InlineData('O', "V", 0)]
    [InlineData('U', "V", 0)]
    [InlineData('L', "V", 0)]
    [InlineData('R', "V", 0)]
    [InlineData('B', "", 0)]
    [InlineData(null, "", 0)]
    public void ShouldConvertLetter(char? nextLetter, string expectedToken, int expectedIndex)
    {
        RuleResult returnedRuleResult = W.Convert(nextLetter);

        Assert.Equal(expectedToken, returnedRuleResult.Token);
        Assert.Equal(expectedIndex, returnedRuleResult.Consumed);
    }
}
