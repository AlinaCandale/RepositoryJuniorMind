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
            var letters = new OneOrMore(new Choice(new Range('a', 'z'), new Range('A','Z')));
            var digit = new OneOrMore(new Range('0', '9'));
            var character = new Sequence(new Optional(letters), new Optional(digit));
            var reverseSolidus = new Character('\\');
            var quotationMark = new Character('"');
            var codePoint = new Sequence(reverseSolidus, new Any("\"\\/fbnrt"));
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var hexSeq = new Sequence(reverseSolidus, new Character('u'), new Sequence(hex, hex, hex, hex));

            //pattern = new Sequence(quotationMark, hexSeq, quotationMark);
            pattern = new Sequence(quotationMark, new Optional(new Choice(codePoint, hexSeq, character)), quotationMark);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
