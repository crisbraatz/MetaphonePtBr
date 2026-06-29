using System.Text;

namespace MetaphonePtBr.Letters
{
    internal static class W
    {
        /// Legend:
        /// Letter = Letter.
        /// []     = One occurrence of any.
        /// v      = Any vowel.
        /// c      = Any consonant.
        /// 0      = Bypass.
        /// Rules ordered by priority:
        /// W[LRv] = V.
        /// W[c]   = 0.
        internal static int Convert(char? nextLetter, StringBuilder token)
        {
            switch (nextLetter)
            {
                case 'A':
                case 'E':
                case 'I':
                case 'L':
                case 'O':
                case 'R':
                case 'U':
                    token.Append('V');

                    return 1;
                case null:
                    token.Append('W');

                    return 0;
                default:
                    return 1;
            }
        }
    }
}
