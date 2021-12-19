using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MetaphonePtBr.Extensions
{
    public static class StringExtension
    {
        private static readonly Regex NonAccentLetters = new("[^A-ZÇ]", RegexOptions.Compiled);
        private static readonly Regex OneOrMoreLetters = new("^[A-ZÀ-Ÿ]+$", RegexOptions.Compiled);

        public static void IsNullOrWhiteSpace(this string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                throw new Exception("The string is null or empty or white space.");
        }

        public static void IsSingleWord(this string word)
        {
            if (word.Trim().Split(" ").Length > 1 || !OneOrMoreLetters.IsMatch(word))
                throw new Exception("The string is not a single word.");
        }

        public static string RemoveAccentsExceptC(this string wordWithAccents)
        {
            var wordWithoutAccents = new StringBuilder();

            foreach (var letter in wordWithAccents)
            {
                if (letter is not 'Ç')
                    wordWithoutAccents.Append(letter.ToString().Normalize(NormalizationForm.FormD)
                        .First(x => char.GetUnicodeCategory(x) is not UnicodeCategory.NonSpacingMark));
                else
                    wordWithoutAccents.Append(letter);
            }

            return wordWithoutAccents.ToString();
        }

        public static string TrimAccentLettersExceptC(this string wordWithAccentLetters) =>
            NonAccentLetters.Replace(wordWithAccentLetters, string.Empty);
    }
}