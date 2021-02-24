using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public class Optional : IPattern
    {
        IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return new SuccessMatch(pattern.Match(text).RemainingText());
        }
    }
}
