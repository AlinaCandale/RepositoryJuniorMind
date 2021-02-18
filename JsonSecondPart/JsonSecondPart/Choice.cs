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
            Match first = new Match(text);

            foreach (var item in patterns )
            {
               if (item.Match(text).Success())
                {
                    first.SetSucces(true);
                }
            }
            
            return first;
        }
    }
}
