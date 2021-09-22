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
            int myVar = 0;
            return text.Aggregate(myVar = 0, (seed, c) => Char.IsDigit(c) ? myVar = myVar * 10 + (c - '0') : throw new Exception());
        }
    }
}
