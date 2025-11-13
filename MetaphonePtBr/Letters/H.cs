using System.Text;

namespace MetaphonePtBr.Letters
{
    internal static class H
    {
        /// Legend:
        /// Letter = Letter.
        /// ˆ      = Begin of the word.
        /// v      = Any vowel.
        /// 0      = Bypass.
        /// Rules ordered by priority:
        /// ˆH[v] = v.
        /// H     = 0.
        internal static int Convert(int currentIndex, char? nextLetter, StringBuilder token)
        {
            if (currentIndex != 0 || !(nextLetter is 'A' ||
                                       nextLetter is 'E' ||
                                       nextLetter is 'I' ||
                                       nextLetter is 'O' ||
                                       nextLetter is 'U'))
                return 0;

            token.Append(nextLetter);

            return 1;
        }
    }
}
