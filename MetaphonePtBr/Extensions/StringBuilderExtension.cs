using System.Text;

namespace MetaphonePtBr.Extensions;

internal static class StringBuilderExtension
{
    internal static char? GetLetterAt(this StringBuilder word, int index = 0) =>
        index >= 0 && word.Length - 1 >= index ? word[index] : null;
}