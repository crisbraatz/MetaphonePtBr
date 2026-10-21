using MetaphonePtBr.Extensions;

namespace MetaphonePtBr.Letters
{
    internal static class Vowels
    {
        /// Legend:
        /// Letter = Letter.
        /// ^ = Beginning of word.
        /// v = Any vowel.
        /// Rules ordered by priority:
        /// ^[v] = v.
        internal static RuleResult Convert(int currentIndex, char currentLetter) =>
            currentIndex is 0 && currentLetter.IsVowel()
                ? RuleResult.WithToken(currentLetter.ToString())
                : RuleResult.Empty;
    }
}
