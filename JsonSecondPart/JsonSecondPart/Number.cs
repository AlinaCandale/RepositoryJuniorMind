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
            //var firstChar = new Choice(new Character('-'), new Character('0'), new Range('1', '9'));
            //var numberWithExponent = new List(new Many(new Range('0', '9')), new Choice(new Character('e'), new Character('E'), new Text("e+"), new Text("e-"), new Text("E+"), new Text("E-")));
            //var numberWithDot = new Sequence(new Character('.'), new Choice(new Many(new Range('0', '9')), numberWithExponent));

            //pattern = new Choice(
            //    firstChar, 
            //    new Character(' '),
            //    new Many(new Range('1', '9')),
            //    numberWithDot,
            //    numberWithExponent
            //        );

            var digit = new Range('0', '9');
            var digits = new Range('1', '9');
            var integer = new Sequence(new Optional(new Character('-')), 
                new Choice(new Character('0'), new Sequence(digits, new Optional(new Many(digit))))); 
            var fraction = new Optional(new Sequence(new Character('.'), new Optional(new Many(digit))));
            var exponent = new Optional(new Sequence(new Choice(new Text("e+"), new Text("e-"), new Text("E+"), new Text("E-"), new Any("eE")), new Many(digit)));
            this.pattern = new Sequence(integer, fraction, exponent);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
