using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;
        
        public Number()
        {
            var digit = new OneOrMore(new Range('1', '9'));
            var digits = new OneOrMore(new Range('0', '9'));
            var integer = new Sequence(
                new Optional(new Character('-')), new Choice(new Character('0'), digit)); 
            var fraction = new Optional(new Sequence(new Character('.'), digits));
            var exponent = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), digits));
            this.pattern = new Sequence(integer, fraction, exponent);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
