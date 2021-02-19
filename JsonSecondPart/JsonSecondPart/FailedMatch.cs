using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public class FailedMatch : IMatch
    {
        string text;
        string errortext = "";

        public FailedMatch(string text)
        {
            this.text = text;
        }

        public string RemainingText()
        {
            if (text != null && text.Length > 1)
            {
                errortext += text[0];
            }

            return errortext;
        }

    }
}
