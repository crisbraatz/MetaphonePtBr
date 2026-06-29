using System.Text;

namespace MetaphonePtBr.Letters
{
    internal static class N
    {
        /// Legend:
        /// Letter = Letter.
        /// $      = End of the word.
        /// 0      = Bypass.
        /// Rules ordered by priority:
        /// N$ = M.
        /// NH = 0.
        internal static void Convert(char? nextLetter, StringBuilder token)
        {
            if (nextLetter is null)
                token.Append('M');

            if (nextLetter != 'H')
                token.Append('N');
        }
    }
}
