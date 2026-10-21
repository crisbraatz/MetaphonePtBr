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
                return RuleResult.WithToken("X");

            if (previousLetter is 'E')
            {
                if (nextLetter.IsVowel())
                {
                    if (firstLetterBeforePrevious is null)
                        return RuleResult.WithToken("Z");

                    switch (nextLetter)
                    {
                        case 'E':
                        case 'I':
                            return RuleResult.WithToken("X", 1);
                        default:
                            return RuleResult.WithToken("KS", 1);
                    }
                }

                switch (nextLetter)
                {
                    case 'C':
                        return RuleResult.WithToken("S", 1);
                    case 'P':
                    case 'T':
                        return RuleResult.WithToken("S");
                    default:
                        return RuleResult.WithToken("KS");
                }
            }

            if (previousLetter.IsVowel())
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
                        return RuleResult.WithToken("KS");
                }

            return RuleResult.WithToken("X");
        }
    }
}
