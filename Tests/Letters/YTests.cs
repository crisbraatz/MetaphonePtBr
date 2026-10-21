using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace Tests.Letters;

public class YTests
{
    [Fact]
    public void ShouldConvertLetter()
    {
        RuleResult returned = Y.Convert();

        Assert.Equal("I", returned.Token);
        Assert.Equal(0, returned.Index);
    }
}
