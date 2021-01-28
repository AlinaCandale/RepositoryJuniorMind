using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return IsNullOrWhiteSpace(input) && IsDoubleQuoted(input);
        }

        static bool IsDoubleQuoted(string input)
        {
            return input.StartsWith('"') && input.EndsWith('"');
        }

        static bool IsNullOrWhiteSpace(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
