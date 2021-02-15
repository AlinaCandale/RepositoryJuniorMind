using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonSecondPart
{
    public class Character
    {
        readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public bool MatchChar(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            return text[0] == pattern;
        }
    }
}
