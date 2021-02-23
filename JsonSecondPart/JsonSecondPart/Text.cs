using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public class Text : IPattern
    {
        readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && text.StartsWith(prefix)
                ? new SuccessMatch(text.Substring(prefix.Length))
                : (IMatch)(new FailedMatch(text));

        }
    }
}
