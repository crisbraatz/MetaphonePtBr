using System.Text;

namespace MetaphonePtBr.Letters;

/// Legend:
/// Letter = Letter.
/// []     = One occurrence of any.
/// c      = Any consonant.
/// Rules ordered by priority:
/// SH      = X.
/// SC[EI]  = S.
/// SC[AOU] = SK.
/// SCH     = X.
/// S[c]    = S.
internal static class S
{
    internal static int Convert(char? nextLetter, char? firstLetterAfterNext, StringBuilder token)
    {
        switch (nextLetter)
        {
            case 'H':
                token.Append('X');
                return 1;
            case 'C':
                switch (firstLetterAfterNext)
                {
                    case 'E' or 'I':
                        token.Append('S');
                        return 2;
                    case 'A' or 'O' or 'U':
                        token.Append("SK");
                        return 2;
                    case 'H':
                        token.Append('X');
                        return 2;
                }

                break;
        }

        token.Append('S');

        return nextLetter switch
        {
            null => 0,
            not ('A' or 'E' or 'I' or 'O' or 'U') => 1,
            _ => 0
        };
    }
}