using System.Text;

namespace MetaphonePtBr.Extensions
{
    internal static class StringBuilderExtension
    {
        internal static char? GetCharAt(this StringBuilder value, int index = 0) =>
            index >= 0 && value.Length - 1 >= index ? value[index] : (char?)null;
    }
}
