using System.Text;

namespace MetaphonePtBr.Letters
{
    public static class T
    {
        /// <summary>
        /// Legend:
        /// Letter = Letter.
        /// Rules orderer by priority:
        /// TH = T.
        /// </summary>
        /// <param name="nextLetter">The next letter of the iteration.</param>
        /// <param name="token">The token to append, if applicable by any rule, the new letter.</param>
        /// <returns>Iterations to bypass if a rule was applied.</returns>
        public static int Convert(char? nextLetter, StringBuilder token)
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
}