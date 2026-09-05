using MetaphonePtBr.Extensions;

namespace UnitTests.Extensions;

public class StringExtensionsTests
{
    [Theory]
    [InlineData(0, 'P')]
    [InlineData(1, 'A')]
    [InlineData(2, 'L')]
    [InlineData(3, 'A')]
    [InlineData(4, 'V')]
    [InlineData(5, 'R')]
    [InlineData(6, 'A')]
    public void ShouldGetCharAtIndex(int index, char expectedCharacter)
    {
        char? returnedCharacter = "PALAVRA".GetCharAt(index);

        Assert.True(returnedCharacter.HasValue);
        Assert.Equal(expectedCharacter, returnedCharacter);
    }

    [Fact]
    public void ShouldReturnItselfWhenSingleChar()
    {
        char? returnedCharacter = "P".GetCharAt();

        Assert.True(returnedCharacter.HasValue);
        Assert.Equal('P', returnedCharacter);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(7)]
    [InlineData(8)]
    public void ShouldReturnNullWhenIndexOutOfRange(int index)
    {
        char? returnedCharacter = "PALAVRA".GetCharAt(index);

        Assert.False(returnedCharacter.HasValue);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void ShouldReturnNullWhenStringIsEmpty(int index)
    {
        char? returnedCharacter = string.Empty.GetCharAt(index);

        Assert.False(returnedCharacter.HasValue);
    }

    [Theory]
    [InlineData("P")]
    [InlineData("PALAVRA")]
    [InlineData("AÇÃO")]
    public void ShouldReturnTrueWhenValueHasOneOrMoreLettersOnly(string value)
    {
        bool returned = value.HasOneOrMoreLettersOnly();

        Assert.True(returned);
    }

    [Theory]
    [InlineData("")]
    [InlineData("123")]
    [InlineData("123PALAVRAS")]
    [InlineData("DUAS PALAVRAS")]
    public void ShouldReturnFalseWhenValueHasNotOneOrMoreLettersOnly(string value)
    {
        bool returned = value.HasOneOrMoreLettersOnly();

        Assert.False(returned);
    }

    [Fact]
    public void ShouldRemoveAccentsExceptC()
    {
        string wordWithoutAccents =
            "AÁÃÀÂÄÅÆBCÇDEÉÊÈĘĖĒËFGHIÍÎÌÏĮĪJKLMNÑOÓÕÔÒÖŒØŌPQRSTUÚÜÙÛŪVWXYZ".RemoveAccentsExceptC();

        Assert.Equal("AAAAAAAÆBCÇDEEEEEEEEFGHIIIIIIIJKLMNNOOOOOOŒØOPQRSTUUUUUUVWXYZ", wordWithoutAccents);
    }

    [Fact]
    public void ShouldTrimAccentLettersExceptC()
    {
        string wordWithoutAccents =
            "AÁÃÀÂªÄÅÆBCÇDEÉÊÈĘĖĒËFGHIÍÎÌÏĮĪJKLMNÑOÓÕÔÒºÖŒØŌPQRSTUÚÜÙÛŪVWXYZ".TrimAccentLettersExceptC();

        Assert.Equal("ABCÇDEFGHIJKLMNOPQRSTUVWXYZ", wordWithoutAccents);
    }
}
