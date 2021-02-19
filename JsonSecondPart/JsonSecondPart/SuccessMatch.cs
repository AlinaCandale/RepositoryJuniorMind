using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public class SuccessMatch : IMatch
    {
        string text;
        string remainingtext;

        public SuccessMatch(string text)
        {
            this.text = text;
        }
                
        public string RemainingText()
        {
            if (text != null && text.Length > 1)
            {
                remainingtext = text.Substring(1);
            }

            return remainingtext;
        }
    }
}
