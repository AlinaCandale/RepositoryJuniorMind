using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public class SuccessMatch : IMatch
    {
        string text;

        public SuccessMatch(string text)
        {
            this.text = text;
        }
                
        public string RemainingText()
        {
            return text;
        }
    }
}
