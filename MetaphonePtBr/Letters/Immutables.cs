using System.Text;

namespace MetaphonePtBr.Letters
{
    public static class Immutables
    {
        /// <summary>
        /// Legend:
        /// Letter = Letter.
        /// Rules orderer by priority:
        /// B = B.
        /// D = D.
        /// F = F.
        /// J = J.
        /// K = K.
        /// M = M.
        /// V = V.
        /// </summary>
        /// <param name="currentLetter">The current letter of the iteration.</param>
        /// <param name="token">The token to append, if applicable by any rule, the new letter.</param>
        /// <returns>Iterations to bypass if a rule was applied.</returns>
        public static int Convert(char currentLetter, StringBuilder token)
        {
            if (currentLetter is 'B' or 'D' or 'F' or 'J' or 'K' or 'M' or 'V')
                token.Append(currentLetter);

            return 0;
        }
    }
}