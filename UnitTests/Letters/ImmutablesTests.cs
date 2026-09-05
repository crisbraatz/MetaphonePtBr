using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class ImmutablesTests
{
    [Theory]
    [InlineData('A', "")]
    [InlineData('B', "B")]
    [InlineData('C', "")]
    [InlineData('D', "D")]
    [InlineData('E', "")]
    [InlineData('F', "F")]
    [InlineData('G', "")]
    [InlineData('H', "")]
    [InlineData('I', "")]
    [InlineData('J', "J")]
    [InlineData('K', "K")]
    [InlineData('L', "")]
    [InlineData('M', "M")]
    [InlineData('N', "")]
    [InlineData('O', "")]
    [InlineData('P', "")]
    [InlineData('Q', "")]
    [InlineData('R', "")]
    [InlineData('S', "")]
    [InlineData('T', "")]
    [InlineData('U', "")]
    [InlineData('V', "V")]
    [InlineData('W', "")]
    [InlineData('X', "")]
    [InlineData('Y', "")]
    [InlineData('Z', "")]
    public void ShouldConvertLetter(char currentLetter, string expectedToken)
    {
        RuleResult returnedRuleResult = Immutables.Convert(currentLetter);

        Assert.Equal(expectedToken, returnedRuleResult.Token);
        Assert.Equal(0, returnedRuleResult.Consumed);
    }
}
