using System.Text;

namespace MetaphonePtBr.Letters
{
    internal static class X
    {
        /// Legend:
        /// Letter = Letter.
        /// ˆ      = Begin of the word.
        /// $      = End of the word.
        /// []     = One occurrence of any.
        /// v      = Any vowel.
        /// .      = Any letter.
        /// Rules ordered by priority:
        /// X$                  = X.
        /// ^EX[v]              = Z.
        /// .EX[v]              = X.
        /// [CGKLRXv][AIOU]X    = X.
        /// [DFMNPQSTVZ][AIOU]X = KS.
        /// EX[EI]              = X.
        /// EX[CPT]             = S.
        /// EX[.]               = KS.
        internal static int Convert(
            char? firstLetterBeforePrevious, char? previousLetter, char? nextLetter, StringBuilder token)
        {
            switch (previousLetter)
            {
                case 'E':
                    switch (nextLetter)
                    {
                        case 'A' when firstLetterBeforePrevious is null:
                        case 'E' when firstLetterBeforePrevious is null:
                        case 'I' when firstLetterBeforePrevious is null:
                        case 'O' when firstLetterBeforePrevious is null:
                        case 'U' when firstLetterBeforePrevious is null:
                            token.Append('Z');

                            return 1;
                        case 'A':
                        case 'E':
                        case 'I':
                        case 'O':
                        case 'U':
                            token.Append('X');

                            return 1;
                        case 'C':
                        case 'P':
                        case 'T':
                            token.Append('S');

                            return 1;
                        default:
                            token.Append("KS");

                            return 1;
                    }
                case 'A':
                case 'I':
                case 'O':
                case 'U':
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
                            token.Append('X');

                            return 0;
                        case 'D':
                        case 'F':
                        case 'M':
                        case 'N':
                        case 'P':
                        case 'Q':
                        case 'S':
                        case 'T':
                        case 'V':
                        case 'Z':
                            token.Append("KS");

                            return 0;
                    }

                    break;
            }

            token.Append('X');

            return 0;
        }
    }
}
