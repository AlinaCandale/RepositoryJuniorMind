using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsNullOrWhiteSpace(input)
                && CheckIfJsonContainValidLetterDotAndZero(input);
        }

        static bool CheckIfJsonContainValidLetterDotAndZero(string input)
        {
            return DoesNotContainLettersExceptExponent(input)
                && CheckIfZeroIsValid(input)
                && ContainCertainValueOnAValidPozition(input, '.')
                && CheckIfExponentIsAfterTheFraction(input);
        }

        static bool DoesNotContainLettersExceptExponent(string input)
        {
            if (!CheckIfExponentIsComplete(input, 'e'))
            {
                return false;
            }

            if (!CheckIfExponentIsComplete(input, 'E'))
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

        static bool CheckIfZeroIsValid(string input)
        {
            return input.Length <= 1 || input[0] != '0' || input[1] == '.';
        }

        static bool ContainCertainValueOnAValidPozition(string input, char value)
        {
            int freq = input.Split(value).Length - 1;
            return freq <= 1 && input.IndexOf(value) != input.Length - 1;
        }

        static bool CheckIfExponentIsComplete(string input, char value)
        {
            if (!ContainCertainValueOnAValidPozition(input, 'e'))
            {
                return false;
            }

            const int mindistance = 2;
            int pozition = input.IndexOf(value);
            if (pozition == input.Length - 1)
            {
                return false;
            }
            else if (input[pozition + 1] == '+' || input[pozition + 1] == '-')
            {
                return input.Length - 1 - pozition >= mindistance;
            }

            return true;
        }

        static bool CheckIfExponentIsAfterTheFraction(string input)
        {
            return !(input.Contains('e') && input.Contains('.')) || input.IndexOf('e') > input.IndexOf('.');
        }
    }
}
