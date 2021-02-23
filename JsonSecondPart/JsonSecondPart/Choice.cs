using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonSecondPart
{
    public class Choice : IPattern
    {
        IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var item in patterns)
            {
                IMatch itemMatch = item.Match(text);
                if (itemMatch.Success())
                {
                    return itemMatch;
                }
            }

            return new FailedMatch(text);
        }
    }
}
