using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace Tests.Letters;

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
        RuleResult returned = W.Convert(nextLetter);

        Assert.Equal(expectedToken, returned.Token);
        Assert.Equal(expectedIndex, returned.Index);
    }
}
