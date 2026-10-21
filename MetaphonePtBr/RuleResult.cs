namespace MetaphonePtBr
{
    internal readonly struct RuleResult
    {
        internal int Index { get; }
        internal string Token { get; }
        internal static RuleResult Empty { get; } = new RuleResult(string.Empty, 0);

        private RuleResult(string token, int index)
        {
            Index = index;
            Token = token;
        }

        internal static RuleResult Increment(int index) => new RuleResult(string.Empty, index);

        internal static RuleResult WithToken(string token) => new RuleResult(token, 0);

        internal static RuleResult WithToken(string token, int index) => new RuleResult(token, index);
    }
}
