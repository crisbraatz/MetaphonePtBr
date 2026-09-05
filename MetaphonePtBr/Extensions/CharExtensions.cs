namespace MetaphonePtBr.Extensions
{
    internal static class CharExtensions
    {
        internal static bool IsNormalizedLetter(this char value) => (value >= 'A' && value <= 'Z') || value is 'Ç';

        internal static bool IsSupportedLetter(this char value)
        {
            char upperInvariantValue = char.ToUpperInvariant(value);

            return upperInvariantValue.IsNormalizedLetter() ||
                   upperInvariantValue is 'Á' ||
                   upperInvariantValue is 'À' ||
                   upperInvariantValue is 'Â' ||
                   upperInvariantValue is 'Ã' ||
                   upperInvariantValue is 'É' ||
                   upperInvariantValue is 'Ê' ||
                   upperInvariantValue is 'Í' ||
                   upperInvariantValue is 'Ó' ||
                   upperInvariantValue is 'Ô' ||
                   upperInvariantValue is 'Õ' ||
                   upperInvariantValue is 'Ú' ||
                   upperInvariantValue is 'Ü';
        }

        internal static bool IsVowel(this char value) =>
            value is 'A' || value is 'E' || value is 'I' || value is 'O' || value is 'U';

        internal static bool IsVowel(this char? value) =>
            value.HasValue && value.Value.IsVowel();
    }
}
