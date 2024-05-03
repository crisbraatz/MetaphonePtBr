using System.Text;

namespace MetaphonePtBr.Letters;

/// Legend:
/// Letter = Letter.
/// Rules ordered by priority:
/// Q = K.
internal static class Q
{
    internal static int Convert(StringBuilder token)
    {
        token.Append('K');

        return 0;
    }
}