using MetaphonePtBr.Extensions;

namespace Tests.Extensions;

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
    public void ShouldGetCharAtIndex(int index, char expected)
    {
        char? returned = "PALAVRA".GetCharAt(index);

        Assert.True(returned.HasValue);
        Assert.Equal(expected, returned);
    }

    [Fact]
    public void ShouldReturnItselfWhenSingleChar()
    {
        char? returned = "P".GetCharAt();

        Assert.True(returned.HasValue);
        Assert.Equal('P', returned);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(7)]
    [InlineData(8)]
    public void ShouldReturnNullWhenIndexOutOfRange(int index) => Assert.False("PALAVRA".GetCharAt(index).HasValue);

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void ShouldReturnNullWhenStringIsEmpty(int index) => Assert.False(string.Empty.GetCharAt(index).HasValue);

    [Theory]
    [InlineData("P")]
    [InlineData("PALAVRA")]
    [InlineData("AÇÃO")]
    public void ShouldReturnTrueWhenValueHasOneOrMoreLettersOnly(string value) =>
        Assert.True(value.HasOneOrMoreLettersOnly());

    [Theory]
    [InlineData("")]
    [InlineData("123")]
    [InlineData("123PALAVRAS")]
    [InlineData("DUAS PALAVRAS")]
    public void ShouldReturnFalseWhenValueDoesNotHaveOneOrMoreLettersOnly(string value) =>
        Assert.False(value.HasOneOrMoreLettersOnly());

    [Fact]
    public void ShouldRemoveAccentsExceptC() => Assert.Equal(
        "AAAAAAAÆBCÇDEEEEEEEEFGHIIIIIIIJKLMNNOOOOOOŒØOPQRSTUUUUUUVWXYZ",
        "AÁÃÀÂÄÅÆBCÇDEÉÊÈĘĖĒËFGHIÍÎÌÏĮĪJKLMNÑOÓÕÔÒÖŒØŌPQRSTUÚÜÙÛŪVWXYZ".RemoveAccentsExceptC());

    [Fact]
    public void ShouldTrimAccentLettersExceptC() => Assert.Equal(
        "ABCÇDEFGHIJKLMNOPQRSTUVWXYZ",
        "AÁÃÀÂªÄÅÆBCÇDEÉÊÈĘĖĒËFGHIÍÎÌÏĮĪJKLMNÑOÓÕÔÒºÖŒØŌPQRSTUÚÜÙÛŪVWXYZ".TrimAccentLettersExceptC());
}
