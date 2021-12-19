using System.Text;

namespace MetaphonePtBr.Letters
{
    public static class N
    {
        /// <summary>
        /// Legend:
        /// Letter = Letter.
        /// $      = End of the word.
        /// 0      = Bypass.
        /// Rules orderer by priority:
        /// N$ = M.
        /// NH = 0.
        /// </summary>
        /// <param name="nextLetter">The next letter of the iteration.</param>
        /// <param name="token">The token to append, if applicable by any rule, the new letter.</param>
        /// <returns>Iterations to bypass if a rule was applied.</returns>
        public static int Convert(char? nextLetter, StringBuilder token)
        {
            switch (nextLetter)
            {
                case null:
                    token.Append('M');
                    return 0;
                case not 'H':
                    token.Append('N');
                    return 0;
                default:
                    return 0;
            }
        }
    }
}