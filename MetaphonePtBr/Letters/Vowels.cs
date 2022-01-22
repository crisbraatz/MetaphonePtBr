using System.Text;

namespace MetaphonePtBr.Letters;

public static class Vowels
{
    /// <summary>
    /// Legend:
    /// Letter = Letter.
    /// ˆ      = Begin of the word.
    /// v      = Any vowel.
    /// Rules orderer by priority:
    /// ˆ[v] = v.
    /// </summary>
    /// <param name="currentIndex">The current index of the iteration.</param>
    /// <param name="currentLetter">The current letter of the iteration.</param>
    /// <param name="token">The token to append, if applicable by any rule, the new letter.</param>
    /// <returns>Iterations to bypass if a rule was applied.</returns>
    public static int Convert(int currentIndex, char currentLetter, StringBuilder token)
    {
        if (currentIndex is 0 & currentLetter is 'A' or 'E' or 'I' or 'O' or 'U')
            token.Append(currentLetter);

        return 0;
    }
}