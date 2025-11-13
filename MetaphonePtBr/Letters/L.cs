using System.Text;

namespace MetaphonePtBr.Letters
{
    internal static class L
    {
        /// Legend:
        /// Letter = Letter.
        /// v      = Any vowel.
        /// 0      = Bypass.
        /// Rules ordered by priority:
        /// L[v] = v.
        /// LH   = 0.
        internal static int Convert(char? nextLetter, StringBuilder token)
        {
            switch (nextLetter)
            {
                case 'A':
                case 'E':
                case 'I':
                case 'O':
                case 'U':
                    token.Append(nextLetter);

                    return 1;
                case 'H':
                    return 1;
                default:
                    token.Append('L');

                    return 0;
            }
        }
    }
}
