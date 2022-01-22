using System.Text;

namespace MetaphonePtBr.Letters;

public static class Z
{
    /// <summary>
    /// Legend:
    /// Letter = Letter.
    /// $      = End of the word.
    /// Rules orderer by priority:
    /// Z$ = S.
    /// </summary>
    /// <param name="nextLetter">The next letter of the iteration.</param>
    /// <param name="token">The token to append, if applicable by any rule, the new letter.</param>
    /// <returns>Iterations to bypass if a rule was applied.</returns>
    public static int Convert(char? nextLetter, StringBuilder token)
    {
        switch (nextLetter)
        {
            case null:
                token.Append('S');
                return 0;
            default:
                token.Append('Z');
                return 0;
        }
    }
}