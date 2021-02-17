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

        public bool Match(string text)
        {
            foreach (var item in patterns)
            {
                if (item.Match(text))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
