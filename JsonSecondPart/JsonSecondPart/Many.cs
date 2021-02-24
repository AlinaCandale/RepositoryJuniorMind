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
                remainingText = remainingText.Substring(1);
            }
            
            return new SuccessMatch(remainingText);
        }
    }
}
