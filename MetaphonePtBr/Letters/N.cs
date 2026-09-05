namespace MetaphonePtBr.Letters
{
    internal static class N
    {
        /// Legend:
        /// Letter = Letter.
        /// $ = End of word.
        /// 0 = Bypass.
        /// Rules ordered by priority:
        /// N$ = M.
        /// NH = 0.
        /// NN = 0.
        /// N = N.
        internal static RuleResult Convert(char? previousLetter, char? nextLetter)
        {
            switch (nextLetter)
            {
                case null:
                    return RuleResult.FromToken("M");
                case 'H':
                    return RuleResult.Consume(1);
            }

            return previousLetter != 'N' ? RuleResult.FromToken("N") : RuleResult.Empty;
        }
    }
}
