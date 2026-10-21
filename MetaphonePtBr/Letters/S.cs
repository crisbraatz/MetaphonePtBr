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
                    return RuleResult.WithToken("S", 1);
                case 'H':
                    return RuleResult.WithToken("X", 1);
            }

            if (previousLetter.IsVowel() && nextLetter.IsVowel())
                return RuleResult.WithToken("Z");

            if (!(nextLetter is 'C'))
                return RuleResult.WithToken("S");

            switch (firstLetterAfterNext)
            {
                case 'E':
                case 'I':
                    return RuleResult.WithToken("S", 2);
                case 'A':
                case 'O':
                case 'U':
                    return RuleResult.WithToken("SK", 2);
                case 'H':
                    return RuleResult.WithToken("X", 2);
                default:
                    return RuleResult.WithToken("S", 1);
            }
        }
    }
}
