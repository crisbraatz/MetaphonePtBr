using System.Text;

namespace MetaphonePtBr.Letters
{
    internal static class P
    {
        /// Legend:
        /// Letter = Letter.
        /// Rules ordered by priority:
        /// PH = F.
        internal static int Convert(char? nextLetter, StringBuilder token)
        {
            if (nextLetter is 'H')
            {
                token.Append('F');

                return 1;
            }

            token.Append('P');

            return 0;
        }
    }
}
