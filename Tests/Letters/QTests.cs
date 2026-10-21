using MetaphonePtBr;
using MetaphonePtBr.Letters;

namespace Tests.Letters;

public class QTests
{
    [Fact]
    public void ShouldConvertLetter()
    {
        RuleResult returned = Q.Convert();

        Assert.Equal("K", returned.Token);
        Assert.Equal(0, returned.Index);
    }
}
