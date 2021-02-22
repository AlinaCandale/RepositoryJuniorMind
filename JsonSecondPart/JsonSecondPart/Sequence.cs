using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public class Sequence : IPattern
    {
        IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            string remainingText = text;

            foreach (var pattern in patterns)
            {
                IMatch patternMatch = pattern.Match(remainingText);
                if (!patternMatch.Success())
                {
                    return new FailedMatch(text);
                }

                remainingText = patternMatch.RemainingText();
            }

            return new SuccessMatch(remainingText);
        }
    }
}
