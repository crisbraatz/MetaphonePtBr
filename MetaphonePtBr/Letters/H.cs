using System.Text;

namespace MetaphonePtBr.Letters;

/// Legend:
/// Letter = Letter.
/// ˆ      = Begin of the word.
/// v      = Any vowel.
/// 0      = Bypass.
/// Rules ordered by priority:
/// ˆH[v] = v.
/// H     = 0.
internal static class H
{
    internal static int Convert(int currentIndex, char? nextLetter, StringBuilder token)
    {
        if (currentIndex is not 0 || nextLetter is not ('A' or 'E' or 'I' or 'O' or 'U'))
            return 0;

        token.Append(nextLetter);

        return 1;
    }
}