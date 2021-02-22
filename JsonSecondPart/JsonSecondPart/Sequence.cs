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
            string texttocheck = text;

            foreach (var pattern in patterns)
            {
                if (!pattern.Match(texttocheck).Success())
                {
                    return new FailedMatch(text);
                }

                texttocheck = pattern.Match(texttocheck).RemainingText();
            }

            return new SuccessMatch(texttocheck);
        }
    }
}
