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
            nextLetter is 'H' ? RuleResult.FromToken("F", 1) : RuleResult.FromToken("P");
    }
}
