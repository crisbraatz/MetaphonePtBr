using System.Text;

namespace MetaphonePtBr.Letters;

public static class G
{
    /// <summary>
    /// Legend:
    /// Letter = Letter.
    /// []     = One occurence of any.
    /// c      = Any consonant.
    /// Rules orderer by priority:
    /// G[AOU] = G.
    /// G[EI]  = J.
    /// GH[EI] = J.
    /// GH[c]  = G.
    /// </summary>
    /// <param name="nextLetter">The next letter of the iteration.</param>
    /// <param name="firstLetterAfterNext">The first letter after the next letter of the iteration.</param>
    /// <param name="token">The token to append, if applicable by any rule, the new letter.</param>
    /// <returns>Iterations to bypass if a rule was applied.</returns>
    public static int Convert(char? nextLetter, char? firstLetterAfterNext, StringBuilder token)
    {
        switch (nextLetter)
        {
            case 'A' or 'O' or 'U':
                token.Append('G');
                return 1;
            case 'E' or 'I':
                token.Append('J');
                return 1;
            case 'H' when firstLetterAfterNext is 'E' or 'I':
                token.Append('J');
                return 2;
            case 'H' when firstLetterAfterNext is not ('A' or 'O' or 'U'):
                token.Append('G');
                return 2;
            default:
                token.Append('G');
                return 0;
        }
    }
}