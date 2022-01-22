using System.Text;

namespace MetaphonePtBr.Letters;

public static class X
{
    /// <summary>
    /// Legend:
    /// Letter = Letter.
    /// ˆ      = Begin of the word.
    /// $      = End of the word.
    /// []     = One occurence of any.
    /// v      = Any vowel.
    /// .      = Any letter.
    /// Rules orderer by priority:
    /// X$                  = X.
    /// ^EX[v]              = Z.
    /// .EX[v]              = X.
    /// [CGKLRXv][AIOU]X    = X.
    /// [DFMNPQSTVZ][AIOU]X = KS.
    /// EX[EI]              = X.
    /// EX[CPT]             = S.
    /// EX[.]               = KS.
    /// </summary>
    /// <param name="firstLetterBeforePrevious">The first letter before the previous letter of the iteration.</param>
    /// <param name="previousLetter">The previous letter of the iteration.</param>
    /// <param name="nextLetter">The next letter of the iteration.</param>
    /// <param name="token">The token to append, if applicable by any rule, the new letter.</param>
    /// <returns>Iterations to bypass if a rule was applied.</returns>
    public static int Convert(
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