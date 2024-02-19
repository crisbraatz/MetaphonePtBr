using System.Text;

namespace MetaphonePtBr.Letters;

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
internal static class X
{
    internal static int Convert(
        char? firstLetterBeforePrevious, char? previousLetter, char? nextLetter, StringBuilder token)
    {
        switch (previousLetter)
        {
            case 'E':
                switch (nextLetter)
                {
                    case 'A' or 'E' or 'I' or 'O' or 'U' when firstLetterBeforePrevious is null:
                        token.Append('Z');
                        return 1;
                    case 'A' or 'E' or 'I' or 'O' or 'U':
                        token.Append('X');
                        return 1;
                    case 'C' or 'P' or 'T':
                        token.Append('S');
                        return 1;
                    default:
                        token.Append("KS");
                        return 1;
                }
            case 'A' or 'I' or 'O' or 'U':
                switch (firstLetterBeforePrevious)
                {
                    case 'A' or 'C' or 'E' or 'G' or 'I' or 'K' or 'L' or 'O' or 'R' or 'U' or 'X':
                        token.Append('X');
                        return 0;
                    case 'D' or 'F' or 'M' or 'N' or 'P' or 'Q' or 'S' or 'T' or 'V' or 'Z':
                        token.Append("KS");
                        return 0;
                }

                break;
        }

        token.Append('X');

        return 0;
    }
}