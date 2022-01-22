using System.Text;

namespace MetaphonePtBr.Letters;

public static class H
{
    /// <summary>
    /// Legend:
    /// Letter = Letter.
    /// ˆ      = Begin of the word.
    /// v      = Any vowel.
    /// 0      = Bypass.
    /// Rules orderer by priority:
    /// ˆH[v] = v.
    /// H     = 0.
    /// </summary>
    /// <param name="currentIndex">The current index of the iteration.</param>
    /// <param name="nextLetter">The next letter of the iteration.</param>
    /// <param name="token">The token to append, if applicable by any rule, the new letter.</param>
    /// <returns>Iterations to bypass if a rule was applied.</returns>
    public static int Convert(int currentIndex, char? nextLetter, StringBuilder token)
    {
        if (currentIndex is not 0 || nextLetter is not ('A' or 'E' or 'I' or 'O' or 'U'))
            return 0;

        token.Append(nextLetter);

        return 1;
    }
}