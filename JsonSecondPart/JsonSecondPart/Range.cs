using System;
using Xunit;

namespace JsonSecondPart
{
    public class Range
    {
        readonly char start;
        readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public bool Match(string text)
        {
            return text[0] >= start && text[0] <= end;
        }
    }
}
