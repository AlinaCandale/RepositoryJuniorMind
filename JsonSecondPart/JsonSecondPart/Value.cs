using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var choice = new Choice(new String(),
                    new Number(),
                    new Text("true"),
                    new Text("false"),
                    new Text("null"));

            var array2 = new Sequence(new Character('['),
                 new Optional(new OneOrMore(choice)),
                new Character(']'));

            var _object = new Sequence(new Character('{'),
                 new Optional(new OneOrMore(new Sequence(new Character('\u0020'), new String(), new Character('\u0020'), new Character(':'), choice))),
                new Character('}'));

            choice.Add(array2);
            choice.Add(_object);

            pattern = new Sequence(new Character('\u0020'), choice,
                new Character('\u0020'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
