using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace MetaphonePtBr.Extensions;

internal static partial class StringExtension
{
    [GeneratedRegex("[^A-ZÇ]", RegexOptions.Compiled)]
    private static partial Regex NonAccentLettersRegex();

    [GeneratedRegex("^[A-ZÀ-Ÿ]+$", RegexOptions.Compiled)]
    private static partial Regex OneOrMoreLettersRegex();

    private static readonly Regex NonAccentLetters = NonAccentLettersRegex();
    private static readonly Regex OneOrMoreLetters = OneOrMoreLettersRegex();

    internal static void IsNullOrWhiteSpace(this string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            throw new Exception("The string is null or empty or white space.");
    }

    internal static void IsSingleWord(this string word)
    {
        if (word.Trim().Split(" ").Length > 1 || !OneOrMoreLetters.IsMatch(word))
            throw new Exception("The string is not a single word.");
    }

    internal static string RemoveAccentsExceptC(this string wordWithAccents)
    {
        var wordWithoutAccents = new StringBuilder();

        foreach (var letter in wordWithAccents)
        {
            if (letter is not 'Ç')
                wordWithoutAccents.Append(letter.ToString().Normalize(NormalizationForm.FormD).First(x =>
                    char.GetUnicodeCategory(x) is not UnicodeCategory.NonSpacingMark));
            else
                wordWithoutAccents.Append(letter);
        }

        return wordWithoutAccents.ToString();
    }

    internal static string TrimAccentLettersExceptC(this string wordWithAccentLetters) =>
        NonAccentLetters.Replace(wordWithAccentLetters, string.Empty);
}