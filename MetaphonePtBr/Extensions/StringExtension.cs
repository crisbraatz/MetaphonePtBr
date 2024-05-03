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

    internal static void IsNullOrWhiteSpace(this string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            throw new Exception("The string is null or empty or white space.");
    }

    internal static void IsSingleWord(this string word)
    {
        if (word.Trim().Split(' ').Length > 1 || !OneOrMoreLettersRegex().IsMatch(word))
            throw new Exception("The string is not a single word.");
    }

    internal static string RemoveAccentsExceptC(this string word)
    {
        var builder = new StringBuilder();

        foreach (var letter in word)
        {
            if (letter is not 'Ç')
                builder.Append(letter.ToString().Normalize(NormalizationForm.FormD).First(x =>
                    char.GetUnicodeCategory(x) is not UnicodeCategory.NonSpacingMark));
            else
                builder.Append(letter);
        }

        return builder.ToString();
    }

    internal static string TrimAccentLettersExceptC(this string word) =>
        NonAccentLettersRegex().Replace(word, string.Empty);
}