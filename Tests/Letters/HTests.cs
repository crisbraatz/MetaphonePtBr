using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace Tests.Letters;

public class HTests
{
    [Theory]
    [InlineData(0, 'A', "A", 1)]
    [InlineData(0, 'E', "E", 1)]
    [InlineData(0, 'I', "I", 1)]
    [InlineData(0, 'O', "O", 1)]
    [InlineData(0, 'U', "U", 1)]
    [InlineData(0, null, "", 0)]
    [InlineData(0, 'B', "", 0)]
    [InlineData(1, null, "", 0)]
    [InlineData(1, 'B', "", 0)]
    public void ShouldConvertLetter(int currentIndex, char? nextLetter, string expectedToken, int expectedIndex)
    {
        RuleResult returned = H.Convert(currentIndex, nextLetter);

        Assert.Equal(expectedToken, returned.Token);
        Assert.Equal(expectedIndex, returned.Index);
    }
}
