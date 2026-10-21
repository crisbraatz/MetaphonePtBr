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
                return RuleResult.Increment(1);

            return previousLetter is null || nextLetter.IsVowel() ? RuleResult.WithToken("L") : RuleResult.Empty;
        }
    }
}
