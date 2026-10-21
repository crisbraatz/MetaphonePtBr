using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace Tests.Letters;

public class NTests
{
    [Theory]
    [InlineData('B', null, "M", 0)]
    [InlineData('B', 'H', "", 1)]
    [InlineData('N', 'A', "", 0)]
    [InlineData('B', 'A', "N", 0)]
    public void ShouldConvertLetter(char? previousLetter, char? nextLetter, string expectedToken, int expectedIndex)
    {
        RuleResult returned = N.Convert(previousLetter, nextLetter);

        Assert.Equal(expectedToken, returned.Token);
        Assert.Equal(expectedIndex, returned.Index);
    }
}
