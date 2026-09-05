using MetaphonePtBr.Extensions;

namespace UnitTests.Extensions;

public class CharExtensionsTests
{
    [Theory]
    [InlineData('A')]
    [InlineData('B')]
    [InlineData('C')]
    [InlineData('D')]
    [InlineData('E')]
    [InlineData('F')]
    [InlineData('G')]
    [InlineData('H')]
    [InlineData('I')]
    [InlineData('J')]
    [InlineData('K')]
    [InlineData('L')]
    [InlineData('M')]
    [InlineData('N')]
    [InlineData('O')]
    [InlineData('P')]
    [InlineData('Q')]
    [InlineData('R')]
    [InlineData('S')]
    [InlineData('T')]
    [InlineData('U')]
    [InlineData('V')]
    [InlineData('W')]
    [InlineData('X')]
    [InlineData('Y')]
    [InlineData('Z')]
    [InlineData('Ç')]
    public void ShouldReturnTrueWhenCharIsNormalizedLetter(char value)
    {
        bool returned = value.IsNormalizedLetter();

        Assert.True(returned);
    }

    [Theory]
    [InlineData('a')]
    [InlineData('z')]
    [InlineData('Á')]
    [InlineData('À')]
    [InlineData('Â')]
    [InlineData('Ã')]
    [InlineData('É')]
    [InlineData('Ê')]
    [InlineData('Í')]
    [InlineData('Ó')]
    [InlineData('Ô')]
    [InlineData('Õ')]
    [InlineData('Ú')]
    [InlineData('Ü')]
    [InlineData('ç')]
    [InlineData('1')]
    [InlineData(' ')]
    [InlineData('-')]
    public void ShouldReturnFalseWhenCharIsNotNormalizedLetter(char value)
    {
        bool returned = value.IsNormalizedLetter();

        Assert.False(returned);
    }

    [Theory]
    [InlineData('A')]
    [InlineData('Z')]
    [InlineData('Ç')]
    [InlineData('a')]
    [InlineData('z')]
    [InlineData('ç')]
    [InlineData('Á')]
    [InlineData('À')]
    [InlineData('Â')]
    [InlineData('Ã')]
    [InlineData('É')]
    [InlineData('Ê')]
    [InlineData('Í')]
    [InlineData('Ó')]
    [InlineData('Ô')]
    [InlineData('Õ')]
    [InlineData('Ú')]
    [InlineData('Ü')]
    public void ShouldReturnTrueWhenCharIsSupportedLetter(char value)
    {
        bool returned = value.IsSupportedLetter();

        Assert.True(returned);
    }

    [Theory]
    [InlineData('1')]
    [InlineData(' ')]
    [InlineData('-')]
    [InlineData('ª')]
    [InlineData('º')]
    public void ShouldReturnFalseWhenCharIsNotSupportedLetter(char value)
    {
        bool returned = value.IsSupportedLetter();

        Assert.False(returned);
    }

    [Theory]
    [InlineData('A')]
    [InlineData('E')]
    [InlineData('I')]
    [InlineData('O')]
    [InlineData('U')]
    public void ShouldReturnTrueWhenCharIsVowel(char value)
    {
        bool returnedFromChar = value.IsVowel();
        bool returnedFromNullableChar = ((char?)value).IsVowel();

        Assert.True(returnedFromChar);
        Assert.True(returnedFromNullableChar);
    }

    [Theory]
    [InlineData(null)]
    [InlineData('B')]
    [InlineData('C')]
    [InlineData('D')]
    [InlineData('F')]
    [InlineData('G')]
    [InlineData('H')]
    [InlineData('J')]
    [InlineData('K')]
    [InlineData('L')]
    [InlineData('M')]
    [InlineData('N')]
    [InlineData('P')]
    [InlineData('Q')]
    [InlineData('R')]
    [InlineData('S')]
    [InlineData('T')]
    [InlineData('V')]
    [InlineData('W')]
    [InlineData('X')]
    [InlineData('Y')]
    [InlineData('Z')]
    public void ShouldReturnFalseWhenCharIsNotVowel(char? value)
    {
        bool returnedFromNullableChar = value.IsVowel();

        Assert.False(returnedFromNullableChar);

        if (value.HasValue)
        {
            bool returnedFromChar = value.Value.IsVowel();

            Assert.False(returnedFromChar);
        }
    }
}
