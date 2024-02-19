using MetaphonePtBr;

namespace UnitTests;

public class MetaphoneTests
{
    [Theory]
    [InlineData("BANCOS", "BNKS")]
    [InlineData("FÚTEIS", "FTS")]
    [InlineData("PAGAVAM", "PGVM")]
    [InlineData("LHE", "")]
    [InlineData("QUEIJO", "KJ")]
    [InlineData("WHISKY", "SI")]
    [InlineData("E", "E")]
    [InlineData("XADREZ", "XDRS")]
    [InlineData("já", "J")]
    [InlineData("fiz", "FS")]
    [InlineData("vinho", "V")]
    [InlineData("com", "KM")]
    [InlineData("toque", "TK")]
    [InlineData("de", "D")]
    [InlineData("kiwi", "KV")]
    [InlineData("para", "PR")]
    [InlineData("belga", "BLG")]
    [InlineData("sexy", "SKS")]
    public void Should_get_metaphone_token_from_word(string word, string expectedToken)
    {
        var obtainedToken = word.GetMetaphoneToken();

        obtainedToken.Should().Be(expectedToken);
    }
}