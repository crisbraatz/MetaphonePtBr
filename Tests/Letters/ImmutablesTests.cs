using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace Tests.Letters;

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
        RuleResult returned = Immutables.Convert(currentLetter);

        Assert.Equal(expectedToken, returned.Token);
        Assert.Equal(0, returned.Index);
    }
}
