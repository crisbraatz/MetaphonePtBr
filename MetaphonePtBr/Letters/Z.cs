namespace MetaphonePtBr.Letters
{
    internal static class Z
    {
        /// Legend:
        /// Letter = Letter.
        /// $ = End of word.
        /// Rules ordered by priority:
        /// Z$ = S.
        /// Z = Z.
        internal static RuleResult Convert(char? nextLetter) =>
            nextLetter is null ? RuleResult.FromToken("S") : RuleResult.FromToken("Z");
    }
}
