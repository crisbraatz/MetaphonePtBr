using MetaphonePtBr.Extensions;

namespace MetaphonePtBr.Letters
{
    internal static class H
    {
        /// Legend:
        /// Letter = Letter.
        /// ^ = Beginning of word.
        /// v = Any vowel.
        /// 0 = Bypass.
        /// Rules ordered by priority:
        /// ^H[v] = v.
        /// H = 0.
        internal static RuleResult Convert(int currentIndex, char? nextLetter)
        {
            if (currentIndex != 0 || !nextLetter.IsVowel())
                return RuleResult.Empty;

            return RuleResult.FromToken(nextLetter.GetValueOrDefault().ToString(), 1);
        }
    }
}
