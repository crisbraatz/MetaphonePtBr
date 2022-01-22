using System.Text;

namespace MetaphonePtBr.Letters;

public static class R
{
    /// <summary>
    /// Legend:
    /// Letter = Letter.
    /// ˆ      = Begin of the word.
    /// $      = End of the word.
    /// 0      = Bypass.
    /// Rules orderer by priority:
    /// ^R = 0.
    /// R$ = 0.
    /// RR = 0.
    /// </summary>
    /// <param name="previousLetter">The previous letter of the iteration.</param>
    /// <param name="nextLetter">The next letter of the iteration.</param>
    /// <param name="token">The token to append, if applicable by any rule, the new letter.</param>
    /// <returns>Iterations to bypass if a rule was applied.</returns>
    public static int Convert(char? previousLetter, char? nextLetter, StringBuilder token)
    {
        if (previousLetter is null || nextLetter is null)
            return 0;

        if (nextLetter is 'R')
            return 1;

        token.Append('R');

        return 0;
    }
}