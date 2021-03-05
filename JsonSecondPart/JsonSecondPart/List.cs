using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            // aici folosește-te de clasele implementate deja
            // pentru a construi un pattern pe care să îl folosești în Match
            this.pattern = new Many(new Choice(element, new Sequence(separator, element)));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
