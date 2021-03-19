using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            var backSlash = new Character('\u005C');
            var quotationMark = new Character('"');
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            
            var hexSeq = new Sequence(new Character('u'), new Sequence(hex, hex, hex, hex));
            var escape = new Sequence(backSlash, new Choice(new Any("\"\\/fbnrt"), hexSeq));
            var character = new Choice(new Range('\u0020', '\u0021'), 
                new Range('\u0023', '\u005B'), 
                new Range('\u005D', char.MaxValue),
                escape);

            pattern = new Sequence(quotationMark, new Optional(new OneOrMore(character)), quotationMark);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
