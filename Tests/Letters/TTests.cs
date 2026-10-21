using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace Tests.Letters;

public class TTests
{
    [Theory]
    [InlineData('H', "T", 1)]
    [InlineData(null, "T", 0)]
    [InlineData('B', "T", 0)]
    public void ShouldConvertLetter(char? nextLetter, string expectedToken, int expectedIndex)
    {
        RuleResult returned = T.Convert(nextLetter);

        Assert.Equal(expectedToken, returned.Token);
        Assert.Equal(expectedIndex, returned.Index);
    }
}
