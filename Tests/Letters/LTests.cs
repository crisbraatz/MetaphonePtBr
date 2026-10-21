using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace Tests.Letters;

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
        RuleResult returned = L.Convert(previousLetter, nextLetter);

        Assert.Equal(expectedToken, returned.Token);
        Assert.Equal(expectedIndex, returned.Index);
    }
}
