using System;
using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace MetaphonePtBr
{
    /// <summary>
    /// MetaphonePtBr is a text transformation algorithm based on phonetic rules of the Brazilian Portuguese language.
    /// </summary>
    public static class Metaphone
    {
        /// <summary>
        /// Gets the metaphone token from a single PT-BR word.
        /// </summary>
        /// <param name="value">A single PT-BR word.</param>
        /// <returns>The metaphone token.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null or white space.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> does not have one or more letters only.</exception>
        public static string GetMetaphoneToken(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value), "Value can not be null or white space.");

            value = value.ToUpperInvariant();

            if (!value.HasOneOrMoreLettersOnly())
                throw new ArgumentException("Value must have one or more letters only.");

            StringBuilder wordWithoutAccents =
                new StringBuilder(value.RemoveAccentsExceptC().TrimAccentLettersExceptC());
            StringBuilder token = new StringBuilder();

            int currentIndex = 0;
            while (currentIndex < wordWithoutAccents.Length)
            {
                char? firstLetterBeforePrevious = wordWithoutAccents.GetCharAt(currentIndex - 2);
                char? previousLetter = wordWithoutAccents.GetCharAt(currentIndex - 1);
                char? currentLetter = wordWithoutAccents.GetCharAt(currentIndex);
                char? nextLetter = wordWithoutAccents.GetCharAt(currentIndex + 1);
                char? firstLetterAfterNext = wordWithoutAccents.GetCharAt(currentIndex + 2);

                int step = 1;

                switch (currentLetter)
                {
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                        Vowels.Convert(currentIndex, currentLetter.Value, token);

                        break;
                    case 'B':
                    case 'D':
                    case 'F':
                    case 'J':
                    case 'K':
                    case 'M':
                    case 'V':
                        Immutables.Convert(currentLetter.Value, token);

                        break;
                    case 'C':
                    case 'Ç':
                        step += C.Convert(currentLetter.Value, nextLetter, firstLetterAfterNext, token);

                        break;
                    case 'G':
                        step += G.Convert(nextLetter, firstLetterAfterNext, token);

                        break;
                    case 'H':
                        step += H.Convert(currentIndex, nextLetter, token);

                        break;
                    case 'L':
                        step += L.Convert(nextLetter, token);

                        break;
                    case 'N':
                        N.Convert(nextLetter, token);

                        break;
                    case 'P':
                        step += P.Convert(nextLetter, token);

                        break;
                    case 'Q':
                        Q.Convert(token);

                        break;
                    case 'R':
                        step += R.Convert(previousLetter, nextLetter, token);

                        break;
                    case 'S':
                        step += S.Convert(nextLetter, firstLetterAfterNext, token);

                        break;
                    case 'T':
                        step += T.Convert(nextLetter, token);

                        break;
                    case 'W':
                        step += W.Convert(nextLetter, token);

                        break;
                    case 'X':
                        step += X.Convert(firstLetterBeforePrevious, previousLetter, nextLetter, token);

                        break;
                    case 'Y':
                        Y.Convert(token);

                        break;
                    case 'Z':
                        Z.Convert(nextLetter, token);

                        break;
                }

                currentIndex += step;
            }

            return token.ToString();
        }
    }
}
