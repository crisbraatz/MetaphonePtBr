using MetaphonePtBr.Extensions;

namespace MetaphonePtBr.Letters
{
    internal static class G
    {
        /// Legend:
        /// Letter = Letter.
        /// v = Any vowel.
        /// c = Any consonant.
        /// Rules ordered by priority:
        /// GH[v] = J.
        /// GH[c] = GJ.
        /// G[EI] = J.
        /// G = G.
        internal static RuleResult Convert(char? nextLetter, char? firstLetterAfterNext)
        {
            switch (nextLetter)
            {
                case 'H':
                    return firstLetterAfterNext.IsVowel()
                        ? RuleResult.FromToken("J")
                        : RuleResult.FromToken("GJ");
                case 'E':
                case 'I':
                    return RuleResult.FromToken("J");
                default:
                    return RuleResult.FromToken("G");
            }
        }
    }
}
