using System.Text;

namespace MetaphonePtBr.Letters;

public static class L
{
    /// <summary>
    /// Legend:
    /// Letter = Letter.
    /// v      = Any vowel.
    /// 0      = Bypass.
    /// Rules orderer by priority:
    /// L[v] = v.
    /// LH   = 0.
    /// </summary>
    /// <param name="nextLetter">The next letter of the iteration.</param>
    /// <param name="token">The token to append, if applicable by any rule, the new letter.</param>
    /// <returns>Iterations to bypass if a rule was applied.</returns>
    public static int Convert(char? nextLetter, StringBuilder token)
    {
        switch (nextLetter)
        {
            case 'A' or 'E' or 'I' or 'O' or 'U':
                token.Append(nextLetter);
                return 1;
            case 'H':
                return 1;
            default:
                token.Append('L');
                return 0;
        }
    }
}