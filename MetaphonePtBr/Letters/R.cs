namespace MetaphonePtBr.Letters
{
    internal static class R
    {
        /// Legend:
        /// Letter = Letter.
        /// ^ = Beginning of word.
        /// $ = End of word.
        /// 0 = Bypass.
        /// Rules ordered by priority:
        /// ^R = 0.
        /// R$ = 0.
        /// RR = 0.
        /// vRv = R.
        /// .Rc = R.
        /// cRv = R.
        internal static RuleResult Convert(char? previousLetter, char? nextLetter)
        {
            if (previousLetter is null || nextLetter is null)
                return RuleResult.Empty;

            return nextLetter is 'R' ? RuleResult.Consume(1) : RuleResult.FromToken("R");
        }
    }
}
