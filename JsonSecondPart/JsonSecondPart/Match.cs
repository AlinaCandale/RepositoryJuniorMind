using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public class Match : IMatch
    {
        string text;
        string remainingtext;
        string consumedtext = "";
        bool succes = false;

        public Match(string text)
        {
            this.text = text;
            if (text != null && text.Length > 1)
            {
                consumedtext += text[0];
                remainingtext = text.Substring(1);
            }
        }

        public void SetSucces(bool value)
        {
            succes = value;
        }

        public string RemainingText()
        {


            return remainingtext;
        }

        public bool Success()
        {
            return succes;
        }
    }
}
