using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonSecondPart
{
    public class Character : IPattern
    {
        readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            Match first = new Match(text);

            if (string.IsNullOrEmpty(text))
            {
                return first;
            }

            if (text[0] == pattern)
            {
                first.SetSucces(true);
            }

            return first;
        }
    }
}
