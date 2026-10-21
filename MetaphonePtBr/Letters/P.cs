namespace MetaphonePtBr.Letters
{
    internal static class P
    {
        /// Legend:
        /// Letter = Letter.
        /// Rules ordered by priority:
        /// PH = F.
        /// P = P.
        internal static RuleResult Convert(char? nextLetter) =>
            nextLetter is 'H' ? RuleResult.WithToken("F", 1) : RuleResult.WithToken("P");
    }
}
