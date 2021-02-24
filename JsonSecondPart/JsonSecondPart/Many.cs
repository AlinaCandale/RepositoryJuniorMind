using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public class Many : IPattern
    {
        IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            IMatch patternMatch = new SuccessMatch(text);

            while (patternMatch.Success())
            {
                patternMatch = pattern.Match(patternMatch.RemainingText());
            }
            
            return new SuccessMatch(patternMatch.RemainingText());
        }
    }
}
