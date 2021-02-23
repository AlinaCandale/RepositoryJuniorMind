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
            IMatch patternMatch = new SuccessMatch(text);
            foreach (var pattern in patterns)
            {
                patternMatch = pattern.Match(patternMatch.RemainingText());
                if (!patternMatch.Success())
                {
                    return patternMatch;
                }
            }

            return patternMatch;
        }
    }
}
