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
    public void ShouldGetMetaphoneTokenFromValue(string value, string expectedToken)
    {
        string returnedToken = value.GetMetaphoneToken();

        Assert.Equal(expectedToken, returnedToken);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ShouldThrowExceptionWhenValueIsNullOrWhiteSpace(string value)
    {
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(value.GetMetaphoneToken);

        Assert.Equal("Value can not be null or white space. (Parameter 'value')", exception.Message);
    }

    [Theory]
    [InlineData("WORD123")]
    [InlineData("123")]
    public void ShouldThrowExceptionWhenValueDoesNotHaveOneOrMoreLettersOnly(string value)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(value.GetMetaphoneToken);

        Assert.Equal("Value must have one or more letters only.", exception.Message);
    }
}
