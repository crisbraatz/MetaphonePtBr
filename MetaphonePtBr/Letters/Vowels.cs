using System.Text;

namespace MetaphonePtBr.Letters
{
    internal static class Vowels
    {
        /// Legend:
        /// Letter = Letter.
        /// ˆ      = Begin of the word.
        /// v      = Any vowel.
        /// Rules ordered by priority:
        /// ˆ[v] = v.
        internal static void Convert(int currentIndex, char currentLetter, StringBuilder token)
        {
            if (currentIndex is 0 && (currentLetter is 'A' ||
                                      currentLetter is 'E' ||
                                      currentLetter is 'I' ||
                                      currentLetter is 'O' ||
                                      currentLetter is 'U'))
                token.Append(currentLetter);
        }
    }
}
