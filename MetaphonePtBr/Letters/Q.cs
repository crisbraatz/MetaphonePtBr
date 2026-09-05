namespace MetaphonePtBr.Letters
{
    internal static class Q
    {
        /// Legend:
        /// Letter = Letter.
        /// Rules ordered by priority:
        /// Q = K.
        internal static RuleResult Convert() => RuleResult.FromToken("K");
    }
}
