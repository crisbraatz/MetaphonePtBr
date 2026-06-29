using System.Text;

namespace MetaphonePtBr.Letters
{
    internal static class Q
    {
        /// Legend:
        /// Letter = Letter.
        /// Rules ordered by priority:
        /// Q = K.
        internal static void Convert(StringBuilder token) => token.Append('K');
    }
}
