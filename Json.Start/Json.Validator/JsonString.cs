using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return IsNullOrWhiteSpace(input)
                && IsDoubleQuoted(input)
                && IsControlCharacter(input);
        }

        static bool IsDoubleQuoted(string input)
        {
            return input.StartsWith('"')
                && input.EndsWith('"')
                && input.Length > 1;
        }

        static bool IsNullOrWhiteSpace(string input)
        {
            if (input == "\"\"")
            {
                return true;
            }

            return !string.IsNullOrEmpty(input);
        }

        static bool IsControlCharacter(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsControl(input, i))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
