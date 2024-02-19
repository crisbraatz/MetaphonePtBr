using System.Text;

namespace MetaphonePtBr.Letters;

/// Legend:
/// Letter = Letter.
/// $      = End of the word.
/// []     = One occurrence of any.
/// c      = Any consonant.
/// Rules ordered by priority:
/// C[AOUc] = K.
/// C[EI]   = S.
/// CHR     = K.
/// CH      = X.
/// C$      = K.
/// Ç       = S.
internal static class C
{
    internal static int Convert(char currentLetter, char? nextLetter, char? firstLetterAfterNext, StringBuilder token)
    {
        switch (currentLetter)
        {
            case 'C':
                switch (nextLetter)
                {
                    case 'H' when firstLetterAfterNext is 'R':
                        token.Append('K');
                        return 2;
                    case 'H':
                        token.Append('X');
                        return 1;
                    case 'E' or 'I':
                        token.Append('S');
                        return 1;
                    default:
                        token.Append('K');
                        return nextLetter is null ? 0 : 1;
                }
            case 'Ç':
                token.Append('S');
                return 0;
            default:
                return 0;
        }
    }
}