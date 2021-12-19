using System.Text;

namespace MetaphonePtBr.Extensions
{
    public static class StringBuilderExtension
    {
        public static char? GetLetterAt(this StringBuilder word, int desiredIndex = 0) =>
            desiredIndex >= 0 && word.Length - 1 >= desiredIndex ? word[desiredIndex] : null;
    }
}