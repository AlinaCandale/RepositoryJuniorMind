using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;
        private readonly IPattern firstChar;
        private readonly IPattern numberWithDot;
        private readonly IPattern numberWithExponent;

        public Number()
        {   
            firstChar = new Choice(new Character('-'), new Character('0'), new Range('1', '9'));
            numberWithExponent = new List(new Many(new Range('0', '9')), new Choice(new Character('e'), new Character('E'), new Text("e+"), new Text("e-"), new Text("E+"), new Text("E-")));
            numberWithDot = new Sequence(new Character('.'), new Choice(new Many(new Range('0', '9')), numberWithExponent));

            pattern = new Choice(
                firstChar, 
                new Character(' '),
                new Many(new Range('1', '9')),
                numberWithDot,
                numberWithExponent
                    );
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
