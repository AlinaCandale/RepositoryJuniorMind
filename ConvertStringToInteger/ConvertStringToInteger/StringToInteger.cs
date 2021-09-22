using System;
using System.Collections.Generic;
using System.Linq;

namespace ConvertStringToInteger
{
    public class StringToInteger
    {
        string text;

        public StringToInteger(string sentence)
        {
            this.text = sentence;
        }

        public int GetIntFromString()
        {
            return text.Aggregate<char,int>(0, (accumulator,c) => Char.IsDigit(c) ? accumulator = accumulator * 10 + (c - '0') : throw new Exception());
        }
    }
}
