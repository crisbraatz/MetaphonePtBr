using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MetaphonePtBr.Extensions
{
    internal static class StringExtension
    {
        private static readonly Regex s_nonAccentLettersRegex = new Regex("[^A-ZÇ]", RegexOptions.Compiled);
        private static readonly Regex s_oneOrMoreLettersOnlyRegex = new Regex("^[A-ZÀ-Ÿ]+$", RegexOptions.Compiled);

        internal static bool HasOneOrMoreLettersOnly(this string value) => s_oneOrMoreLettersOnlyRegex.IsMatch(value);

        internal static string RemoveAccentsExceptC(this string value)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char character in value)
            {
                if (new Dictionary<char, string>
                    {
                        ['ª'] = "A",
                        ['Æ'] = "AE",
                        ['º'] = "O",
                        ['Œ'] = "OE",
                        ['Ø'] = "O"
                    }
                    .TryGetValue(character, out string? replacement))
                    stringBuilder.Append(replacement);
                else if (character != 'Ç')
                    stringBuilder.Append(character.ToString().Normalize(NormalizationForm.FormD).FirstOrDefault(x =>
                        char.GetUnicodeCategory(x) != UnicodeCategory.NonSpacingMark));
                else
                    stringBuilder.Append(character);
            }

            return stringBuilder.ToString();
        }

        internal static string TrimAccentLettersExceptC(this string value) =>
            s_nonAccentLettersRegex.Replace(value, string.Empty);
    }
}
