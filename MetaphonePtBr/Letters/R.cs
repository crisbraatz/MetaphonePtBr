using System.Text;

namespace MetaphonePtBr.Letters;

/// Legend:
/// Letter = Letter.
/// ˆ      = Begin of the word.
/// $      = End of the word.
/// 0      = Bypass.
/// Rules ordered by priority:
/// ^R = 0.
/// R$ = 0.
/// RR = 0.
internal static class R
{
    internal static int Convert(char? previousLetter, char? nextLetter, StringBuilder token)
    {
        if (previousLetter is null || nextLetter is null)
            return 0;

        if (nextLetter is 'R')
            return 1;

        token.Append('R');

        return 0;
    }
}