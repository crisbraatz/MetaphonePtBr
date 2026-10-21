using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace Tests.Letters;

public class RTests
{
    [Theory]
    [InlineData(null, 'A', "", 0)]
    [InlineData('A', null, "", 0)]
    [InlineData('A', 'R', "", 1)]
    [InlineData('A', 'A', "R", 0)]
    [InlineData('B', 'C', "R", 0)]
    [InlineData('B', 'A', "R", 0)]
    public void ShouldConvertLetter(char? previousLetter, char? nextLetter, string expectedToken, int expectedIndex)
    {
        RuleResult returned = R.Convert(previousLetter, nextLetter);

        Assert.Equal(expectedToken, returned.Token);
        Assert.Equal(expectedIndex, returned.Index);
    }
}
