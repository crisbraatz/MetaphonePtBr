using System.Text;

namespace MetaphonePtBr.Letters;

/// Legend:
/// Letter = Letter.
/// ˆ      = Begin of the word.
/// v      = Any vowel.
/// Rules ordered by priority:
/// ˆ[v] = v.
internal static class Vowels
{
    internal static int Convert(int currentIndex, char currentLetter, StringBuilder token)
    {
        if (currentIndex is 0 & currentLetter is 'A' or 'E' or 'I' or 'O' or 'U')
            token.Append(currentLetter);

        return 0;
    }
}