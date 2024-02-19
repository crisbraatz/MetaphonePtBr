using System.Text;

namespace MetaphonePtBr.Extensions;

internal static class StringBuilderExtension
{
    internal static char? GetLetterAt(this StringBuilder word, int desiredIndex = 0) =>
        desiredIndex >= 0 && word.Length - 1 >= desiredIndex ? word[desiredIndex] : null;
}