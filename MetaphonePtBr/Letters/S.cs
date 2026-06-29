using System.Text;

namespace MetaphonePtBr.Letters
{
    internal static class S
    {
        /// Legend:
        /// Letter = Letter.
        /// []     = One occurrence of any.
        /// c      = Any consonant.
        /// Rules ordered by priority:
        /// SH      = X.
        /// SC[EI]  = S.
        /// SC[AOU] = SK.
        /// SCH     = X.
        /// S[c]    = S.
        internal static int Convert(char? nextLetter, char? firstLetterAfterNext, StringBuilder token)
        {
            switch (nextLetter)
            {
                case 'H':
                    token.Append('X');

                    return 1;
                case 'C':
                    switch (firstLetterAfterNext)
                    {
                        case 'E':
                        case 'I':
                            token.Append('S');

                            return 2;
                        case 'A':
                        case 'O':
                        case 'U':
                            token.Append("SK");

                            return 2;
                        case 'H':
                            token.Append('X');

                            return 2;
                    }

                    break;
            }

            token.Append('S');

            if (nextLetter is null)
                return 0;

            if (nextLetter != 'A' &&
                nextLetter != 'E' &&
                nextLetter != 'I' &&
                nextLetter != 'O' &&
                nextLetter != 'U')
                return 1;

            return 0;
        }
    }
}
