using System.Text;

namespace MetaphonePtBr.Letters
{
    internal static class G
    {
        /// Legend:
        /// Letter = Letter.
        /// []     = One occurrence of any.
        /// c      = Any consonant.
        /// Rules ordered by priority:
        /// G[AOU] = G.
        /// G[EI]  = J.
        /// GH[EI] = J.
        /// GH[c]  = G.
        internal static int Convert(char? nextLetter, char? firstLetterAfterNext, StringBuilder token)
        {
            switch (nextLetter)
            {
                case 'A':
                case 'O':
                case 'U':
                    token.Append('G');

                    return 1;
                case 'E':
                case 'I':
                    token.Append('J');

                    return 1;
                case 'H' when firstLetterAfterNext is 'E' || firstLetterAfterNext is 'I':
                    token.Append('J');

                    return 2;
                case 'H' when !(firstLetterAfterNext is 'A' ||
                                firstLetterAfterNext is 'O' ||
                                firstLetterAfterNext is 'U'):
                    token.Append('G');

                    return 2;
                default:
                    token.Append('G');

                    return 0;
            }
        }
    }
}
