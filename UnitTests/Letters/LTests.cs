using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class LTests
{
    [Theory]
    [InlineData('B', 'H', "", 1)]
    [InlineData(null, 'B', "L", 0)]
    [InlineData('B', 'A', "L", 0)]
    [InlineData('B', 'E', "L", 0)]
    [InlineData('B', 'I', "L", 0)]
    [InlineData('B', 'O', "L", 0)]
    [InlineData('B', 'U', "L", 0)]
    [InlineData('B', 'C', "", 0)]
    [InlineData('B', null, "", 0)]
    public void ShouldConvertLetter(char? previousLetter, char? nextLetter, string expectedToken, int expectedIndex)
    {
        RuleResult returnedRuleResult = L.Convert(previousLetter, nextLetter);

        Assert.Equal(expectedToken, returnedRuleResult.Token);
        Assert.Equal(expectedIndex, returnedRuleResult.Consumed);
    }
}
