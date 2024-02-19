using System.Text;

namespace MetaphonePtBr.Letters;

/// Legend:
/// Letter = Letter.
/// $      = End of the word.
/// Rules ordered by priority:
/// Z$ = S.
internal static class Z
{
    internal static int Convert(char? nextLetter, StringBuilder token)
    {
        switch (nextLetter)
        {
            case null:
                token.Append('S');
                return 0;
            default:
                token.Append('Z');
                return 0;
        }
    }
}