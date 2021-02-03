using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsNullOrWhiteSpace(input)
                && ContainLetters(input)
                && StartWithZero(input)
                && ContainDot(input);
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

        static bool StartWithZero(string input)
        {
            if (input.Length <= 1)
            {
                return true;
            }
            else if (input.Length > 1)
            {
                if (input[1] == '.')
                {
                    return true;
                }

                return input[0] != '0';
            }

            return true;
        }

        static bool ContainDot(string input)
        {
            if (!input.Contains('.'))
            {
                return true;
            }

            int freq = input.Split('.').Length - 1;
            return freq == 1 && input.IndexOf('.') != input.Length - 1;
        }
    }
}
