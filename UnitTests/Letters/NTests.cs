using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class NTests
{
    [Theory]
    [InlineData('B', null, "M", 0)]
    [InlineData('B', 'H', "", 1)]
    [InlineData('N', 'A', "", 0)]
    [InlineData('B', 'A', "N", 0)]
    public void ShouldConvertLetter(char? previousLetter, char? nextLetter, string expectedToken, int expectedIndex)
    {
        RuleResult returnedRuleResult = N.Convert(previousLetter, nextLetter);

        Assert.Equal(expectedToken, returnedRuleResult.Token);
        Assert.Equal(expectedIndex, returnedRuleResult.Consumed);
    }
}
