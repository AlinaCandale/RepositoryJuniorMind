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
            const int unicodeCharacterLength = 4;
            const int pozToJump = 2;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '\\')
                {
                    if (input[i + 1] == 'u' && input.Length - 1 - i >= unicodeCharacterLength)
                    {
                        return CheckIfCharIsHexadecimal(input, i + pozToJump);
                    }

                    return IsValidEscapeCharacter(input[i + 1]);
                }

                if (input[input.Length - 1 - 1] == '\\')
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsValidEscapeCharacter(char character)
        {
            const string values = "\"\\/fbnrt";
            return values.Contains(character);
        }

        static bool CheckIfCharIsHexadecimal(string input, int index)
        {
            const int unicodeCharacterLength = 4;
            int count = 0;
            for (int i = index; i < (index + unicodeCharacterLength); i++)
            {
                if (Uri.IsHexDigit(input[i]))
                {
                    count++;
                }
            }

            return count == unicodeCharacterLength;
        }
    }
}
