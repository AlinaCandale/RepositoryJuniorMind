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
            var character = new Choice(new Range('\u0020', '\u0021'), new Range('\u0023', '\u005B'), new Range('\u005D', char.MaxValue));
            var reverseSolidus = new Character('\u0022');
            var quotationMark = new Character('"');
            var escape = new Sequence(reverseSolidus, new Any("\"\\/fbnrt"));
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var hexSeq = new Sequence(reverseSolidus, new Character('u'), new Sequence(hex, hex, hex, hex));

            pattern = new Sequence(quotationMark, new Optional(new Choice(new OneOrMore(escape), new OneOrMore(hexSeq), new OneOrMore(character))), quotationMark);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
