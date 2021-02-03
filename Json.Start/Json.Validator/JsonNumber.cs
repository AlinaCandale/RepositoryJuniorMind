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
                && ContainCertainValue(input, '.');
        }

        static bool ContainLetters(string input)
        {
            if (!ContainCertainValue(input, 'e'))
            {
                return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != 'e' && input[i] != 'E' && char.IsLetter(input[i]))
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

        static bool ContainCertainValue(string input, char value)
        {
            if (!input.Contains(value))
            {
                return true;
            }

            int freq = input.Split(value).Length - 1;
            return freq == 1 && input.IndexOf(value) != input.Length - 1;
        }
    }
}
