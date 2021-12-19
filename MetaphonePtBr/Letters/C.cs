using System.Text;

namespace MetaphonePtBr.Letters
{
    public static class C
    {
        /// <summary>
        /// Legend:
        /// Letter = Letter.
        /// $      = End of the word.
        /// []     = One occurence of any.
        /// c      = Any consonant.
        /// Rules orderer by priority:
        /// C[AOUc] = K.
        /// C[EI]   = S.
        /// CHR     = K.
        /// CH      = X.
        /// C$      = K.
        /// Ç       = S.
        /// </summary>
        /// <param name="currentLetter">The current letter of the iteration.</param>
        /// <param name="nextLetter">The next letter of the iteration.</param>
        /// <param name="firstLetterAfterNext">The first letter after the next letter of the iteration.</param>
        /// <param name="token">The token to append, if applicable by any rule, the new letter.</param>
        /// <returns>Iterations to bypass if a rule was applied.</returns>
        public static int Convert(char currentLetter, char? nextLetter, char? firstLetterAfterNext, StringBuilder token)
        {
            switch (currentLetter)
            {
                case 'C':
                    switch (nextLetter)
                    {
                        case 'H' when firstLetterAfterNext is 'R':
                            token.Append('K');
                            return 2;
                        case 'H':
                            token.Append('X');
                            return 1;
                        case 'E' or 'I':
                            token.Append('S');
                            return 1;
                        default:
                            token.Append('K');
                            return nextLetter is null ? 0 : 1;
                    }
                case 'Ç':
                    token.Append('S');
                    return 0;
                default:
                    return 0;
            }
        }
    }
}