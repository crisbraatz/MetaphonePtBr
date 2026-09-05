namespace MetaphonePtBr.Letters
{
    internal static class T
    {
        /// Legend:
        /// Letter = Letter.
        /// Rules ordered by priority:
        /// TH = T.
        /// T = T.
        internal static RuleResult Convert(char? nextLetter) =>
            nextLetter is 'H' ? RuleResult.FromToken("T", 1) : RuleResult.FromToken("T");
    }
}
