using System;

namespace SuperSonic.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string s, string other)
        {
            return string.Compare(s, other, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
