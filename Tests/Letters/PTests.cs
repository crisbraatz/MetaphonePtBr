using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace Tests.Letters;

public class PTests
{
    [Theory]
    [InlineData('H', "F", 1)]
    [InlineData(null, "P", 0)]
    [InlineData('B', "P", 0)]
    public void ShouldConvertLetter(char? nextLetter, string expectedToken, int expectedIndex)
    {
        RuleResult returned = P.Convert(nextLetter);

        Assert.Equal(expectedToken, returned.Token);
        Assert.Equal(expectedIndex, returned.Index);
    }
}
