using System.Text;

namespace MetaphonePtBr.Letters
{
    internal static class Immutables
    {
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
        internal static void Convert(char currentLetter, StringBuilder token)
        {
            if (currentLetter is 'B' ||
                currentLetter is 'D' ||
                currentLetter is 'F' ||
                currentLetter is 'J' ||
                currentLetter is 'K' ||
                currentLetter is 'M' ||
                currentLetter is 'V')
                token.Append(currentLetter);
        }
    }
}
