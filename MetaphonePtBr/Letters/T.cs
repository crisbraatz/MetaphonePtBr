using System.Text;

namespace MetaphonePtBr.Letters;

/// Legend:
/// Letter = Letter.
/// Rules ordered by priority:
/// TH = T.
internal static class T
{
    internal static int Convert(char? nextLetter, StringBuilder token)
    {
        if (nextLetter is 'H')
        {
            token.Append('T');

            return 1;
        }

        token.Append('T');

        return 0;
    }
}