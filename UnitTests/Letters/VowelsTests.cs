using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class VowelsTests
{
    [Theory]
    [InlineData(0, 'A', "A")]
    [InlineData(0, 'E', "E")]
    [InlineData(0, 'I', "I")]
    [InlineData(0, 'O', "O")]
    [InlineData(0, 'U', "U")]
    [InlineData(1, 'A', "")]
    [InlineData(1, 'E', "")]
    [InlineData(1, 'I', "")]
    [InlineData(1, 'O', "")]
    [InlineData(1, 'U', "")]
    [InlineData(0, 'B', "")]
    public void ShouldConvertLetter(int currentIndex, char currentLetter, string expectedToken)
    {
        RuleResult returnedRuleResult = Vowels.Convert(currentIndex, currentLetter);

        Assert.Equal(expectedToken, returnedRuleResult.Token);
        Assert.Equal(0, returnedRuleResult.Consumed);
    }
}
