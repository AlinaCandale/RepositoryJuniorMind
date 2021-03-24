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

        public void Add(IPattern pattern)
        {
            IPattern[] patternsSum = new IPattern[patterns.Length + 1];
            for (int i = 0; i < patterns.Length; i++)
            {
                patternsSum[i] = patterns[i];
            }
            patternsSum[patternsSum.Length - 1] = pattern;
            patterns = patternsSum;
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
