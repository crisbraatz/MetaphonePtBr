using System.Text;

namespace MetaphonePtBr.Letters;

/// Legend:
/// Letter = Letter.
/// []     = One occurrence of any.
/// v      = Any vowel.
/// c      = Any consonant.
/// 0      = Bypass.
/// Rules ordered by priority:
/// W[LRv] = V.
/// W[c]   = 0.
internal static class W
{
    internal static int Convert(char? nextLetter, StringBuilder token)
    {
        switch (nextLetter)
        {
            case 'A' or 'E' or 'I' or 'L' or 'O' or 'R' or 'U':
                token.Append('V');
                return 1;
            case null:
                token.Append('W');
                return 0;
            default:
                return 1;
        }
    }
}