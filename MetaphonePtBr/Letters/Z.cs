using System.Text;

namespace MetaphonePtBr.Letters
{
    internal static class Z
    {
        /// Legend:
        /// Letter = Letter.
        /// $      = End of the word.
        /// Rules ordered by priority:
        /// Z$ = S.
        internal static void Convert(char? nextLetter, StringBuilder token) =>
            token.Append(nextLetter is null ? 'S' : 'Z');
    }
}
