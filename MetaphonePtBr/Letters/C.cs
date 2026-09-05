namespace MetaphonePtBr.Letters
{
    internal static class C
    {
        /// Legend:
        /// Letter = Letter.
        /// $ = End of word.
        /// 0 = Bypass.
        /// Rules ordered by priority:
        /// CHR = K.
        /// CH = X.
        /// C[EI] = S.
        /// C[QK] = 0.
        /// C = K. C$ = K.
        /// Ç = S.
        internal static RuleResult Convert(char currentLetter, char? nextLetter, char? firstLetterAfterNext)
        {
            switch (currentLetter)
            {
                case 'C':
                    switch (nextLetter)
                    {
                        case 'H':
                            return firstLetterAfterNext is 'R'
                                ? RuleResult.FromToken("K", 1)
                                : RuleResult.FromToken("X", 1);
                        case 'E':
                        case 'I':
                            return RuleResult.FromToken("S");
                        case 'Q':
                        case 'K':
                            return RuleResult.Empty;
                        default:
                            return RuleResult.FromToken("K");
                    }
                case 'Ç':
                    return RuleResult.FromToken("S");
                default:
                    return RuleResult.Empty;
            }
        }
    }
}
