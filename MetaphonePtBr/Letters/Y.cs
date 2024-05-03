using System.Text;

namespace MetaphonePtBr.Letters;

/// Legend:
/// Letter = Letter.
/// Rules ordered by priority:
/// Y = I.
internal static class Y
{
    internal static int Convert(StringBuilder token)
    {
        token.Append('I');

        return 0;
    }
}