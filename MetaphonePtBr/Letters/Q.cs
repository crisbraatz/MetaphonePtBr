using System.Text;

namespace MetaphonePtBr.Letters
{
    public static class Q
    {
        /// <summary>
        /// Legend:
        /// Letter = Letter.
        /// Rules orderer by priority:
        /// Q = K.
        /// </summary>
        /// <param name="token">The token to append, if applicable by any rule, the new letter.</param>
        /// <returns>Iterations to bypass if a rule was applied.</returns>
        public static int Convert(StringBuilder token)
        {
            token.Append('K');

            return 0;
        }
    }
}