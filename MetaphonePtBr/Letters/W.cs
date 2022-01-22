using System.Text;

namespace MetaphonePtBr.Letters;

public static class W
{
    /// <summary>
    /// Legend:
    /// Letter = Letter.
    /// []     = One occurence of any.
    /// v      = Any vowel.
    /// c      = Any consonant.
    /// 0      = Bypass.
    /// Rules orderer by priority:
    /// W[LRv] = V.
    /// W[c]   = 0.
    /// </summary>
    /// <param name="nextLetter">The next letter of the iteration.</param>
    /// <param name="token">The token to append, if applicable by any rule, the new letter.</param>
    /// <returns>Iterations to bypass if a rule was applied.</returns>
    public static int Convert(char? nextLetter, StringBuilder token)
    {
        switch (nextLetter)
        {
            case 'A' or 'E' or 'I' or 'L' or 'O' or 'R' or 'U':
                token.Append('V');
                return 1;
            case null:
                token.Append('W');
                return 0;
            default:
                return 1;
        }
    }
}