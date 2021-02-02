using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsNullOrWhiteSpace(input)
                && ContainLetters(input);
        }

        static bool ContainLetters(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsNullOrWhiteSpace(string input)
        {
            return !string.IsNullOrEmpty(input);
        }
    }
}
