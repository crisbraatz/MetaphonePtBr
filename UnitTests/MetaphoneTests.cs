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
    [InlineData("WHISKY", "SKI")]
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
    [InlineData("belga", "BG")]
    [InlineData("sexy", "SKSI")]
    public void ShouldGetMetaphoneTokenFromValue(string value, string expectedToken)
    {
        string returnedToken = value.GetMetaphoneToken();

        Assert.Equal(expectedToken, returnedToken);
    }

    [Theory]
    [InlineData("Christofer")]
    [InlineData("Christofr")]
    [InlineData("Christopher")]
    [InlineData("Christophr")]
    [InlineData("Cristofer")]
    [InlineData("Cristofr")]
    [InlineData("Cristophr")]
    public void ShouldGetMetaphoneTokenFromReadmeSample(string value)
    {
        string returnedToken = value.GetMetaphoneToken();

        Assert.Equal("KRSTF", returnedToken);
    }

#pragma warning disable S4144
    [Theory]
    [InlineData("CA", "K")]
    [InlineData("CE", "S")]
    [InlineData("CRA", "KR")]
    [InlineData("CHRA", "KR")]
    [InlineData("CHAVE", "XV")]
    [InlineData("AC", "AK")]
    [InlineData("AÇA", "AS")]
    [InlineData("GA", "G")]
    [InlineData("GE", "J")]
    [InlineData("GHE", "J")]
    [InlineData("GHB", "GJB")]
    [InlineData("HA", "A")]
    [InlineData("AH", "A")]
    [InlineData("B", "B")]
    [InlineData("D", "D")]
    [InlineData("F", "F")]
    [InlineData("J", "J")]
    [InlineData("K", "K")]
    [InlineData("M", "M")]
    [InlineData("V", "V")]
    [InlineData("LA", "L")]
    [InlineData("LHA", "")]
    [InlineData("AN", "AM")]
    [InlineData("NHA", "")]
    [InlineData("PH", "F")]
    [InlineData("PA", "P")]
    [InlineData("QA", "K")]
    [InlineData("RA", "")]
    [InlineData("AR", "A")]
    [InlineData("ARRA", "A")]
    [InlineData("ARA", "AR")]
    [InlineData("ARBA", "ARB")]
    [InlineData("BRA", "BR")]
    [InlineData("SHA", "X")]
    [InlineData("SCE", "S")]
    [InlineData("SCA", "SK")]
    [InlineData("SCHA", "X")]
    [InlineData("SS", "S")]
    [InlineData("SPA", "SP")]
    [InlineData("SA", "S")]
    [InlineData("TH", "T")]
    [InlineData("TA", "T")]
    [InlineData("A", "A")]
    [InlineData("WA", "V")]
    [InlineData("WB", "B")]
    [InlineData("AX", "AX")]
    [InlineData("EX", "EX")]
    [InlineData("EXA", "EZ")]
    [InlineData("BEXE", "BX")]
    [InlineData("BEXA", "BKS")]
    [InlineData("CAXA", "KX")]
    [InlineData("FAXA", "FKS")]
    [InlineData("EXE", "EZ")]
    [InlineData("EXC", "ES")]
    [InlineData("EXB", "EKSB")]
    [InlineData("XA", "X")]
    [InlineData("Y", "I")]
    [InlineData("AZ", "AS")]
    [InlineData("ZA", "Z")]
    public void ShouldGetMetaphoneTokenFromReadmeRules(string value, string expectedToken)
    {
        string returnedToken = value.GetMetaphoneToken();

        Assert.Equal(expectedToken, returnedToken);
    }
#pragma warning restore S4144

    [Fact]
    public void ShouldThrowExceptionWhenValueIsNull()
    {
        string? value = null;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(value.GetMetaphoneToken);

        Assert.Equal("Value can not be null. (Parameter 'value')", exception.Message);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ShouldThrowExceptionWhenValueIsEmptyOrWhiteSpace(string value)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(value.GetMetaphoneToken);

        Assert.Equal("Value can not be empty or white space. (Parameter 'value')", exception.Message);
    }

    [Theory]
    [InlineData("123")]
    [InlineData("123PALAVRAS")]
    [InlineData("DUAS PALAVRAS")]
    public void ShouldThrowExceptionWhenValueDoesNotHaveOneOrMoreSupportedPortugueseLettersOnly(string value)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(value.GetMetaphoneToken);

        Assert.Equal(
            "Value must have one or more supported PT-BR letters only. (Parameter 'value')", exception.Message);
    }
}
