using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace MetaphonePtBr;

public static class Metaphone
{
    /// <summary>
    /// Generates a token by providing a single word.
    /// </summary>
    /// <param name="word">The single word.</param>
    /// <returns>The generated token.</returns>
    public static string GetMetaphoneToken(this string word)
    {
        word = word.ToUpper();

        word.IsNullOrWhiteSpace();
        word.IsSingleWord();

        var wordWithoutAccents = new StringBuilder(word.RemoveAccentsExceptC().TrimAccentLettersExceptC());
        var token = new StringBuilder();

        for (var currentIndex = 0; currentIndex < wordWithoutAccents.Length; currentIndex++)
        {
            var firstLetterBeforePrevious = wordWithoutAccents.GetLetterAt(currentIndex - 2);
            var previousLetter = wordWithoutAccents.GetLetterAt(currentIndex - 1);
            var currentLetter = wordWithoutAccents.GetLetterAt(currentIndex);
            var nextLetter = wordWithoutAccents.GetLetterAt(currentIndex + 1);
            var firstLetterAfterNext = wordWithoutAccents.GetLetterAt(currentIndex + 2);

            switch (currentLetter)
            {
                case 'A' or 'E' or 'I' or 'O' or 'U':
                    currentIndex += Vowels.Convert(currentIndex, currentLetter.Value, token);
                    break;
                case 'B' or 'D' or 'F' or 'J' or 'K' or 'M' or 'V':
                    currentIndex += Immutables.Convert(currentLetter.Value, token);
                    break;
                case 'C' or 'Ç':
                    currentIndex += C.Convert(currentLetter.Value, nextLetter, firstLetterAfterNext, token);
                    break;
                case 'G':
                    currentIndex += G.Convert(nextLetter, firstLetterAfterNext, token);
                    break;
                case 'H':
                    currentIndex += H.Convert(currentIndex, nextLetter, token);
                    break;
                case 'L':
                    currentIndex += L.Convert(nextLetter, token);
                    break;
                case 'N':
                    currentIndex += N.Convert(nextLetter, token);
                    break;
                case 'P':
                    currentIndex += P.Convert(nextLetter, token);
                    break;
                case 'Q':
                    currentIndex += Q.Convert(token);
                    break;
                case 'R':
                    currentIndex += R.Convert(previousLetter, nextLetter, token);
                    break;
                case 'S':
                    currentIndex += S.Convert(nextLetter, firstLetterAfterNext, token);
                    break;
                case 'T':
                    currentIndex += T.Convert(nextLetter, token);
                    break;
                case 'W':
                    currentIndex += W.Convert(nextLetter, token);
                    break;
                case 'X':
                    currentIndex += X.Convert(firstLetterBeforePrevious, previousLetter, nextLetter, token);
                    break;
                case 'Y':
                    currentIndex += Y.Convert(token);
                    break;
                case 'Z':
                    currentIndex += Z.Convert(nextLetter, token);
                    break;
            }
        }

        return token.ToString();
    }
}