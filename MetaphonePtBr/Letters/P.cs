using System.Text;

namespace MetaphonePtBr.Letters;

/// Legend:
/// Letter = Letter.
/// Rules ordered by priority:
/// PH = F.
internal static class P
{
    internal static int Convert(char? nextLetter, StringBuilder token)
    {
        if (nextLetter is 'H')
        {
            token.Append('F');

            return 1;
        }

        token.Append('P');

        return 0;
    }
}