using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return IsNullOrWhiteSpace(input)
                && IsDoubleQuoted(input)
                && IsControlCharacter(input)
                && IncludesOnlyRecognizedCharacters(input);
        }

        static bool IsDoubleQuoted(string input)
        {
            return input.StartsWith('"')
                && input.EndsWith('"')
                && input.Length > 1;
        }

        static bool IsNullOrWhiteSpace(string input)
        {
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

        static bool IncludesOnlyRecognizedCharacters(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '\\')
                {
                    return CheckIfCharIsContainByValues(input[i + 1]);
                }
            }

            return true;
        }

        static bool CheckIfCharIsContainByValues(char character)
        {
            char[] values = { '"', '\\', '/', 'f', 'b', 'n', 'r', 't' };
            for (int j = 0; j < values.Length; j++)
            {
                if (character == values[j])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
