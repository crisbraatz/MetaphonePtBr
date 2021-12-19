using System.Text;

namespace MetaphonePtBr.Letters
{
    public static class S
    {
        /// <summary>
        /// Legend:
        /// Letter = Letter.
        /// []     = One occurence of any.
        /// c      = Any consonant.
        /// Rules orderer by priority:
        /// SH      = X.
        /// SC[EI]  = S.
        /// SC[AOU] = SK.
        /// SCH     = X.
        /// S[c]    = S.
        /// </summary>
        /// <param name="nextLetter">The next letter of the iteration.</param>
        /// <param name="firstLetterAfterNext">The first letter after the next letter of the iteration.</param>
        /// <param name="token">The token to append, if applicable by any rule, the new letter.</param>
        /// <returns>Iterations to bypass if a rule was applied.</returns>
        public static int Convert(char? nextLetter, char? firstLetterAfterNext, StringBuilder token)
        {
            switch (nextLetter)
            {
                case 'H':
                    token.Append('X');
                    return 1;
                case 'C':
                    switch (firstLetterAfterNext)
                    {
                        case 'E' or 'I':
                            token.Append('S');
                            return 2;
                        case 'A' or 'O' or 'U':
                            token.Append("SK");
                            return 2;
                        case 'H':
                            token.Append('X');
                            return 2;
                    }

                    break;
            }

            token.Append('S');

            return nextLetter switch
            {
                null => 0,
                not ('A' or 'E' or 'I' or 'O' or 'U') => 1,
                _ => 0
            };
        }
    }
}