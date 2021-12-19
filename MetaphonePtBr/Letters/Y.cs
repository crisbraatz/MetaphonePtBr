using System.Text;

namespace MetaphonePtBr.Letters
{
    public static class Y
    {
        /// <summary>
        /// Legend:
        /// Letter = Letter.
        /// Rules orderer by priority:
        /// Y = I.
        /// </summary>
        /// <param name="token">The token to append, if applicable by any rule, the new letter.</param>
        /// <returns>Iterations to bypass if a rule was applied.</returns>
        public static int Convert(StringBuilder token)
        {
            token.Append('I');

            return 0;
        }
    }
}