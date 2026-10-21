using System;
using System.Text;
using MetaphonePtBr.Extensions;
using MetaphonePtBr.Letters;

namespace MetaphonePtBr
{
    /// <summary>
    /// Provides Brazilian Portuguese phonetic matching for .NET.
    /// </summary>
    public static class Metaphone
    {
        /// <summary>
        /// Converts a single Brazilian Portuguese word into a stable phonetic token.
        /// </summary>
        /// <param name="value">A single word containing only supported Brazilian Portuguese letters.</param>
        /// <returns>
        /// A phonetic token produced from <paramref name="value"/>. The token is intended for phonetic comparison and does not preserve the original word spelling.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="value"/> is empty, consists only of whitespace, or contains multiple words, numbers, symbols, or unsupported characters.
        /// </exception>
        /// <remarks>
        /// Supported accented letters are normalized before the phonetic rules are applied.
        /// </remarks>
        /// <example>
        /// <code>
        /// string token = "EXAMPLE".GetMetaphoneToken();
        /// </code>
        /// </example>
        public static string GetMetaphoneToken(this string value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value), "Value cannot be null.");

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value cannot be empty or whitespace.", nameof(value));

            value = value.ToUpperInvariant();

            if (!value.HasOneOrMoreLettersOnly())
                throw new ArgumentException("Value must have one or more supported PT-BR letters only.", nameof(value));

            string wordWithoutAccents = value.RemoveAccentsExceptC().TrimAccentLettersExceptC();

            StringBuilder stringBuilder = new StringBuilder(wordWithoutAccents.Length);

            int index = 0;

            while (index < wordWithoutAccents.Length)
            {
                char? firstLetterBeforePrevious = wordWithoutAccents.GetCharAt(index - 2);
                char? previousLetter = wordWithoutAccents.GetCharAt(index - 1);
                char? currentLetter = wordWithoutAccents.GetCharAt(index);
                char? nextLetter = wordWithoutAccents.GetCharAt(index + 1);
                char? firstLetterAfterNext = wordWithoutAccents.GetCharAt(index + 2);

                RuleResult ruleResult = RuleResult.Empty;

                switch (currentLetter)
                {
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                        ruleResult = Vowels.Convert(index, currentLetter.Value);

                        break;
                    case 'B':
                    case 'D':
                    case 'F':
                    case 'J':
                    case 'K':
                    case 'M':
                    case 'V':
                        ruleResult = Immutables.Convert(currentLetter.Value);

                        break;
                    case 'C':
                    case 'Ç':
                        ruleResult = C.Convert(currentLetter.Value, nextLetter, firstLetterAfterNext);

                        break;
                    case 'G':
                        ruleResult = G.Convert(nextLetter, firstLetterAfterNext);

                        break;
                    case 'H':
                        ruleResult = H.Convert(index, nextLetter);

                        break;
                    case 'L':
                        ruleResult = L.Convert(previousLetter, nextLetter);

                        break;
                    case 'N':
                        ruleResult = N.Convert(previousLetter, nextLetter);

                        break;
                    case 'P':
                        ruleResult = P.Convert(nextLetter);

                        break;
                    case 'Q':
                        ruleResult = Q.Convert();

                        break;
                    case 'R':
                        ruleResult = R.Convert(previousLetter, nextLetter);

                        break;
                    case 'S':
                        ruleResult = S.Convert(previousLetter, nextLetter, firstLetterAfterNext);

                        break;
                    case 'T':
                        ruleResult = T.Convert(nextLetter);

                        break;
                    case 'W':
                        ruleResult = W.Convert(nextLetter);

                        break;
                    case 'X':
                        ruleResult = X.Convert(firstLetterBeforePrevious, previousLetter, nextLetter);

                        break;
                    case 'Y':
                        ruleResult = Y.Convert();

                        break;
                    case 'Z':
                        ruleResult = Z.Convert(nextLetter);

                        break;
                }

                stringBuilder.Append(ruleResult.Token);

                index += ruleResult.Index + 1;
            }

            return stringBuilder.ToString();
        }
    }
}
