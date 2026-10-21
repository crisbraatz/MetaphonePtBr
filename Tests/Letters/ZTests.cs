using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace Tests.Letters;

public class ZTests
{
    [Theory]
    [InlineData(null, "S")]
    [InlineData('A', "Z")]
    public void ShouldConvertLetter(char? nextLetter, string expectedToken)
    {
        RuleResult returned = Z.Convert(nextLetter);

        Assert.Equal(expectedToken, returned.Token);
        Assert.Equal(0, returned.Index);
    }
}
