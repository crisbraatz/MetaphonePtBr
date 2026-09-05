using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace UnitTests.Letters;

public class XTests
{
    [Theory]
    [InlineData(null, null, null, "X", 0)]
    [InlineData(null, 'A', null, "X", 0)]
    [InlineData('D', 'A', null, "X", 0)]
    [InlineData(null, 'E', 'A', "Z", 0)]
    [InlineData(null, 'E', 'E', "Z", 0)]
    [InlineData(null, 'E', 'I', "Z", 0)]
    [InlineData(null, 'E', 'O', "Z", 0)]
    [InlineData(null, 'E', 'U', "Z", 0)]
    [InlineData('B', 'E', 'E', "X", 1)]
    [InlineData('B', 'E', 'I', "X", 1)]
    [InlineData('B', 'E', 'A', "KS", 1)]
    [InlineData('B', 'E', 'O', "KS", 1)]
    [InlineData('B', 'E', 'U', "KS", 1)]
    [InlineData('B', 'E', 'C', "S", 1)]
    [InlineData('B', 'E', 'P', "S", 0)]
    [InlineData('B', 'E', 'T', "S", 0)]
    [InlineData('B', 'E', 'B', "KS", 0)]
    [InlineData('A', 'A', 'B', "X", 0)]
    [InlineData('C', 'A', 'B', "X", 0)]
    [InlineData('E', 'I', 'B', "X", 0)]
    [InlineData('G', 'O', 'B', "X", 0)]
    [InlineData('K', 'U', 'B', "X", 0)]
    [InlineData('L', 'A', 'B', "X", 0)]
    [InlineData('R', 'I', 'B', "X", 0)]
    [InlineData('X', 'O', 'B', "X", 0)]
    [InlineData('D', 'A', 'B', "KS", 0)]
    [InlineData('F', 'I', 'B', "KS", 0)]
    [InlineData('M', 'O', 'B', "KS", 0)]
    [InlineData('N', 'U', 'B', "KS", 0)]
    [InlineData('P', 'A', 'B', "KS", 0)]
    [InlineData('Q', 'I', 'B', "KS", 0)]
    [InlineData('S', 'O', 'B', "KS", 0)]
    [InlineData('T', 'U', 'B', "KS", 0)]
    [InlineData('V', 'A', 'B', "KS", 0)]
    [InlineData('Z', 'I', 'B', "KS", 0)]
    [InlineData('B', 'B', 'A', "X", 0)]
    public void ShouldConvertLetter(
        char? firstLetterBeforePrevious,
        char? previousLetter,
        char? nextLetter,
        string expectedToken,
        int expectedIndex)
    {
        RuleResult returnedRuleResult = X.Convert(firstLetterBeforePrevious, previousLetter, nextLetter);

        Assert.Equal(expectedToken, returnedRuleResult.Token);
        Assert.Equal(expectedIndex, returnedRuleResult.Consumed);
    }
}
