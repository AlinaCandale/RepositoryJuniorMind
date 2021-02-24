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
            string remainingText = text;

            while (pattern.Match(remainingText).Success())
            {
                remainingText = pattern.Match(remainingText).RemainingText();
            }
            
            return new SuccessMatch(remainingText);
        }
    }
}
