using System.Text;

namespace MetaphonePtBr.Letters;

/// Legend:
/// Letter = Letter.
/// Rules ordered by priority:
/// B = B.
/// D = D.
/// F = F.
/// J = J.
/// K = K.
/// M = M.
/// V = V.
internal static class Immutables
{
    internal static int Convert(char currentLetter, StringBuilder token)
    {
        if (currentLetter is 'B' or 'D' or 'F' or 'J' or 'K' or 'M' or 'V')
            token.Append(currentLetter);

        return 0;
    }
}