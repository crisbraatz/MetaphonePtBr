using MetaphonePtBr.Extensions;

namespace MetaphonePtBr.Letters
{
    internal static class X
    {
        /// Legend:
        /// Letter = Letter.
        /// ^ = Beginning of word.
        /// $ = End of word.
        /// v = Any vowel.
        /// . = Any letter.
        /// Rules ordered by priority:
        /// X$ = X.
        /// ^EX[v] = Z.
        /// .EX[EI] = X.
        /// .EX[AOU] = KS.
        /// EX[C] = S.
        /// EX[PT] = S.
        /// EX[.] = KS.
        /// [vCKGLRX][AIOU]X = X.
        /// [DFMNPQSTVZ][AIOU]X = KS.
        /// X = X.
        internal static RuleResult Convert(char? firstLetterBeforePrevious, char? previousLetter, char? nextLetter)
        {
            if (nextLetter is null)
                return RuleResult.FromToken("X");

            if (previousLetter is 'E')
            {
                if (nextLetter.IsVowel())
                {
                    if (firstLetterBeforePrevious is null)
                        return RuleResult.FromToken("Z");

                    switch (nextLetter)
                    {
                        case 'E':
                        case 'I':
                            return RuleResult.FromToken("X", 1);
                        default:
                            return RuleResult.FromToken("KS", 1);
                    }
                }

                switch (nextLetter)
                {
                    case 'C':
                        return RuleResult.FromToken("S", 1);
                    case 'P':
                    case 'T':
                        return RuleResult.FromToken("S");
                    default:
                        return RuleResult.FromToken("KS");
                }
            }

            if (previousLetter.IsVowel())
            {
                switch (firstLetterBeforePrevious)
                {
                    case 'A':
                    case 'C':
                    case 'E':
                    case 'G':
                    case 'I':
                    case 'K':
                    case 'L':
                    case 'O':
                    case 'R':
                    case 'U':
                    case 'X':
                        break;
                    default:
                        return RuleResult.FromToken("KS");
                }
            }

            return RuleResult.FromToken("X");
        }
    }
}
