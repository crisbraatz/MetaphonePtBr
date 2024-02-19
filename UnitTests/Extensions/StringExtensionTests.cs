namespace UnitTests.Extensions;

public class StringExtensionTests
{
    private Action _action;

    [Fact]
    public void Should_validate_string_is_not_null_and_not_empty_and_not_white_space()
    {
        _action = "WORD".IsNullOrWhiteSpace;

        _action.Should().NotThrow<Exception>();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Should_throw_exception_when_string_is_null_or_empty_or_white_space(string word)
    {
        _action = word.IsNullOrWhiteSpace;

        _action.Should().Throw<Exception>().WithMessage("The string is null or empty or white space.");
    }

    [Fact]
    public void Should_validate_string_is_single_word()
    {
        _action = "WORD".IsSingleWord;

        _action.Should().NotThrow<Exception>();
    }

    [Fact]
    public void Should_throw_exception_when_string_is_not_single_word()
    {
        _action = "MANY WORDS".IsSingleWord;

        _action.Should().Throw<Exception>().WithMessage("The string is not a single word.");
    }

    [Fact]
    public void Should_throw_exception_when_string_contains_non_letters()
    {
        for (var i = 32; i < 127; i++)
        {
            if (i is >= 65 and <= 90 or >= 97 and <= 122)
                continue;

            var variableWord = "WORD" + (char)i;

            _action = variableWord.IsSingleWord;

            _action.Should().Throw<Exception>().WithMessage("The string is not a single word.");
        }
    }

    [Fact]
    public void Should_remove_accents_except_c()
    {
        var wordWithoutAccents = "AÁÃÀÂªÄÅÆBCÇDEÉÊÈĘĖĒËFGHIÍÎÌÏĮĪJKLMNÑOÓÕÔÒºÖŒØŌPQRSTUÚÜÙÛŪVWXYZ"
            .RemoveAccentsExceptC();

        wordWithoutAccents.Should()
            .NotContainAll(
                "Á", "Ã", "À", "Â", "ª", "Ä", "Å", "Æ", "É", "Ê", "È", "Ę", "Ė", "Ē", "Ë", "Í", "Î", "Ì",
                "Ï", "Į", "Ī", "Ñ", "Ó", "Õ", "Ô", "Ò", "º", "Ö", "Œ", "Ø", "Ō", "Ú", "Ü", "Ù", "Û", "Ū")
            .And.ContainAll(
                "A", "B", "C", "Ç", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z")
            .And.HaveLength(63);
    }

    [Fact]
    public void Should_trim_accent_letters_except_c()
    {
        var wordWithoutAccent = "AÁÃÀÂªÄÅÆBCÇDEÉÊÈĘĖĒËFGHIÍÎÌÏĮĪJKLMNÑOÓÕÔÒºÖŒØŌPQRSTUÚÜÙÛŪVWXYZ"
            .TrimAccentLettersExceptC();

        wordWithoutAccent.Should()
            .NotContainAll(
                "Á", "Ã", "À", "Â", "ª", "Ä", "Å", "Æ", "É", "Ê", "È", "Ę", "Ė", "Ē", "Ë", "Í", "Î", "Ì",
                "Ï", "Į", "Ī", "Ñ", "Ó", "Õ", "Ô", "Ò", "º", "Ö", "Œ", "Ø", "Ō", "Ú", "Ü", "Ù", "Û", "Ū")
            .And.ContainAll(
                "A", "B", "C", "Ç", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z")
            .And.HaveLength(27);
    }
}