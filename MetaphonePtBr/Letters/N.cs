using System.Text;

namespace MetaphonePtBr.Letters;

/// Legend:
/// Letter = Letter.
/// $      = End of the word.
/// 0      = Bypass.
/// Rules ordered by priority:
/// N$ = M.
/// NH = 0.
internal static class N
{
    internal static int Convert(char? nextLetter, StringBuilder token)
    {
        switch (nextLetter)
        {
            case null:
                token.Append('M');
                return 0;
            case not 'H':
                token.Append('N');
                return 0;
            default:
                return 0;
        }
    }
}