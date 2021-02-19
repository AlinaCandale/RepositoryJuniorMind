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
                if (!string.IsNullOrEmpty(text) && item.Match(text).RemainingText() == text.Substring(1))
                {
                    return new SuccessMatch(text.Substring(1));
                }
            }

            return (IMatch)(new FailedMatch(text));
        }
    }
}
