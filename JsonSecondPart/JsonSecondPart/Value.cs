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
            var number = new Number();
            var @string = new String();
            var ws = new Many(new Any(" \r\n\t"));
            var separator = new Character(',');

            var value = new Choice(@string,
                    number,
                    new Text("true"),
                    new Text("false"),
                    new Text("null"));

            var element = new Sequence(ws, value, ws);
            var elements = new List(element, separator);
            var member = new Sequence(ws, @string, ws, new Character(':'), element);
            var members = new List(member, separator);

            var @object = new Sequence(new Character('{'), members, ws, new Character('}'));
            var array = new Sequence(new Character('['), elements, ws, new Character(']'));

            value.Add(@object);
            value.Add(array);

            pattern = element;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
