using System.Text;
using MetaphonePtBr.Extensions;

namespace UnitTests.Extensions;

public class StringBuilderExtensionTests
{
    [Theory]
    [InlineData(0, 'W')]
    [InlineData(1, 'O')]
    [InlineData(2, 'R')]
    [InlineData(3, 'D')]
    public void ShouldGetCharAtIndex(int index, char expectedCharacter)
    {
        char? returnedCharacter = new StringBuilder("WORD").GetCharAt(index);

        Assert.True(returnedCharacter.HasValue);
        Assert.Equal(expectedCharacter, returnedCharacter);
    }

    [Fact]
    public void ShouldReturnItselfWhenSingleChar()
    {
        char? returnedCharacter = new StringBuilder("W").GetCharAt();

        Assert.True(returnedCharacter.HasValue);
        Assert.Equal('W', returnedCharacter);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(4)]
    [InlineData(5)]
    public void ShouldReturnNullWhenIndexOutOfRange(int index)
    {
        char? returnedCharacter = new StringBuilder("WORD").GetCharAt(index);

        Assert.False(returnedCharacter.HasValue);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void ShouldReturnNullWhenStringBuilderIsDefault(int index)
    {
        char? returnedCharacter = new StringBuilder().GetCharAt(index);

        Assert.False(returnedCharacter.HasValue);
    }
}
