using System.Globalization;
using System.Linq;
using System.Text;

namespace MetaphonePtBr.Extensions
{
    internal static class StringExtensions
    {
        internal static char? GetCharAt(this string value, int index = 0) =>
            index >= 0 && value.Length - 1 >= index ? value[index] : (char?)null;

        internal static bool HasOneOrMoreLettersOnly(this string value) =>
            value.Length != 0 && value.Normalize(NormalizationForm.FormC).All(x => x.IsSupportedLetter());

        internal static string RemoveAccentsExceptC(this string value)
        {
            StringBuilder stringBuilder = new StringBuilder();

            string normalizedValue = value.Normalize(NormalizationForm.FormD);

            for (int index = 0; index < normalizedValue.Length; index++)
            {
                char character = normalizedValue[index];

                if (char.GetUnicodeCategory(character) is UnicodeCategory.NonSpacingMark)
                    continue;

                if (character is 'C' && index + 1 < normalizedValue.Length && normalizedValue[index + 1] is '\u0327')
                {
                    stringBuilder.Append('Ç');

                    continue;
                }

                stringBuilder.Append(character);
            }

            return stringBuilder.ToString();
        }

        internal static string TrimAccentLettersExceptC(this string value) =>
            new string(value.Where(x => x.IsNormalizedLetter()).ToArray());
    }
}
