using MetaphonePtBr.Extensions;

namespace MetaphonePtBr.Letters
{
    internal static class W
    {
        /// Legend:
        /// Letter = Letter.
        /// [] = One occurrence of any listed letter.
        /// v = Any vowel.
        /// c = Any consonant.
        /// 0 = Bypass.
        /// Rules ordered by priority:
        /// W[v] = V.
        /// W[LR] = V.
        /// W[c] = 0.
        /// W$ = 0.
        internal static RuleResult Convert(char? nextLetter)
        {
            if (nextLetter.IsVowel() || nextLetter is 'L' || nextLetter is 'R')
                return RuleResult.FromToken("V");

            return RuleResult.Empty;
        }
    }
}
