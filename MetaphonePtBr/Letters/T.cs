using System.Text;

namespace MetaphonePtBr.Letters
{
    internal static class T
    {
        /// Legend:
        /// Letter = Letter.
        /// Rules ordered by priority:
        /// TH = T.
        internal static int Convert(char? nextLetter, StringBuilder token)
        {
            token.Append('T');

            return nextLetter is 'H' ? 1 : 0;
        }
    }
}
