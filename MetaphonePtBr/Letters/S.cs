using MetaphonePtBr.Extensions;

namespace MetaphonePtBr.Letters
{
    internal static class S
    {
        /// Legend:
        /// Letter = Letter.
        /// [] = One occurrence of any listed letter.
        /// v = Any vowel.
        /// c = Any consonant.
        /// Rules ordered by priority:
        /// SS = S.
        /// SH = X.
        /// vSv = Z.
        /// SC[EI] = S.
        /// SC[AOU] = SK.
        /// SCH = X.
        /// SC[.] = S.
        /// S = S.
        internal static RuleResult Convert(char? previousLetter, char? nextLetter, char? firstLetterAfterNext)
        {
            switch (nextLetter)
            {
                case 'S':
                    return RuleResult.FromToken("S", 1);
                case 'H':
                    return RuleResult.FromToken("X", 1);
            }

            if (previousLetter.IsVowel() && nextLetter.IsVowel())
                return RuleResult.FromToken("Z");

            if (nextLetter is 'C')
            {
                switch (firstLetterAfterNext)
                {
                    case 'E':
                    case 'I':
                        return RuleResult.FromToken("S", 2);
                    case 'A':
                    case 'O':
                    case 'U':
                        return RuleResult.FromToken("SK", 2);
                    case 'H':
                        return RuleResult.FromToken("X", 2);
                    default:
                        return RuleResult.FromToken("S", 1);
                }
            }

            return RuleResult.FromToken("S");
        }
    }
}
