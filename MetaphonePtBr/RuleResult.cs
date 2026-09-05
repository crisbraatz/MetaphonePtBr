namespace MetaphonePtBr
{
    internal readonly struct RuleResult
    {
        internal int Consumed { get; }
        internal string Token { get; }
        internal static RuleResult Empty { get; } = new RuleResult(string.Empty, 0);

        private RuleResult(string token, int consumed)
        {
            Token = token;
            Consumed = consumed;
        }

        internal static RuleResult Consume(int count) => new RuleResult(string.Empty, count);

        internal static RuleResult FromToken(string token) => new RuleResult(token, 0);

        internal static RuleResult FromToken(string token, int consumed) => new RuleResult(token, consumed);
    }
}
