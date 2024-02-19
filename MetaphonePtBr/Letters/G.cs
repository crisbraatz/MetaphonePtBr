using System.Text;

namespace MetaphonePtBr.Letters;

/// Legend:
/// Letter = Letter.
/// []     = One occurrence of any.
/// c      = Any consonant.
/// Rules ordered by priority:
/// G[AOU] = G.
/// G[EI]  = J.
/// GH[EI] = J.
/// GH[c]  = G.
internal static class G
{
    internal static int Convert(char? nextLetter, char? firstLetterAfterNext, StringBuilder token)
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