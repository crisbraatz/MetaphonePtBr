using MetaphonePtBr.Extensions;

namespace UnitTests.Extensions;

public class StringExtensionTests
{
    [Theory]
    [InlineData("W")]
    [InlineData("WORD")]
    public void ShouldReturnTrueWhenValueHasOneOrMoreLetters(string value)
    {
        bool returned = value.HasOneOrMoreLettersOnly();

        Assert.True(returned);
    }

    [Fact]
    public void ShouldReturnFalseWhenValueIsNullOrEmpty()
    {
        bool returned = string.Empty.HasOneOrMoreLettersOnly();

        Assert.False(returned);
    }

    [Fact]
    public void ShouldReturnFalseWhenValueHasNonLetters()
    {
        for (int i = 32; i < 127; i++)
        {
            if (i is >= 65 and <= 90 or >= 97 and <= 122)
                continue;

            bool returned = ("WORD" + (char)i).HasOneOrMoreLettersOnly();

            Assert.False(returned);
        }
    }

    [Fact]
    public void ShouldRemoveAccentsExceptC()
    {
        string wordWithoutAccents =
            "AÁÃÀÂªÄÅÆBCÇDEÉÊÈĘĖĒËFGHIÍÎÌÏĮĪJKLMNÑOÓÕÔÒºÖŒØŌPQRSTUÚÜÙÛŪVWXYZ".RemoveAccentsExceptC();

        foreach (string letter in new[]
                 {
                     "Á", "Ã", "À", "Â", "ª", "Ä", "Å", "Æ", "É", "Ê", "È", "Ę", "Ė", "Ē", "Ë", "Í", "Î", "Ì", "Ï",
                     "Į", "Ī", "Ñ", "Ó", "Õ", "Ô", "Ò", "º", "Ö", "Œ", "Ø", "Ō", "Ú", "Ü", "Ù", "Û", "Ū"
                 })
            Assert.DoesNotContain(letter, wordWithoutAccents, StringComparison.OrdinalIgnoreCase);
        foreach (string letter in new[]
                 {
                     "A", "B", "C", "Ç", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R",
                     "S", "T", "U", "V", "W", "X", "Y", "Z"
                 })
            Assert.Contains(letter, wordWithoutAccents, StringComparison.OrdinalIgnoreCase);
        Assert.Equal(65, wordWithoutAccents.Length);
    }

    [Fact]
    public void ShouldTrimAccentLettersExceptC()
    {
        string wordWithoutAccents =
            "AÁÃÀÂªÄÅÆBCÇDEÉÊÈĘĖĒËFGHIÍÎÌÏĮĪJKLMNÑOÓÕÔÒºÖŒØŌPQRSTUÚÜÙÛŪVWXYZ".TrimAccentLettersExceptC();

        foreach (string letter in new[]
                 {
                     "Á", "Ã", "À", "Â", "ª", "Ä", "Å", "Æ", "É", "Ê", "È", "Ę", "Ė", "Ē", "Ë", "Í", "Î", "Ì", "Ï",
                     "Į", "Ī", "Ñ", "Ó", "Õ", "Ô", "Ò", "º", "Ö", "Œ", "Ø", "Ō", "Ú", "Ü", "Ù", "Û", "Ū"
                 })
            Assert.DoesNotContain(letter, wordWithoutAccents, StringComparison.OrdinalIgnoreCase);
        foreach (string letter in new[]
                 {
                     "A", "B", "C", "Ç", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R",
                     "S", "T", "U", "V", "W", "X", "Y", "Z"
                 })
            Assert.Contains(letter, wordWithoutAccents, StringComparison.OrdinalIgnoreCase);
        Assert.Equal(27, wordWithoutAccents.Length);
    }
}
