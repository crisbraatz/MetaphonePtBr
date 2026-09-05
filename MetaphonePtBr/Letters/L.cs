using MetaphonePtBr.Extensions;

namespace MetaphonePtBr.Letters
{
    internal static class L
    {
        /// Legend:
        /// Letter = Letter.
        /// ^ = Beginning of word.
        /// v = Any vowel.
        /// 0 = Bypass.
        /// Rules ordered by priority:
        /// LH = 0.
        /// ^L = L.
        /// L[v] = L.
        /// L = 0.
        internal static RuleResult Convert(char? previousLetter, char? nextLetter)
        {
            if (nextLetter is 'H')
                return RuleResult.Consume(1);

            if (previousLetter is null || nextLetter.IsVowel())
                return RuleResult.FromToken("L");

            return RuleResult.Empty;
        }
    }
}
