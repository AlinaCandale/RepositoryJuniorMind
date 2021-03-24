using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class ChoiceFacts
    {
        [Theory]
        [InlineData("{\"abc\":1}", "")]
        [InlineData("0", "")]
        [InlineData("\"abc\"", "")]
        [InlineData("true", "")]
        [InlineData("[]", "")]
        [InlineData("[12]", "")]

        public void AddPattern(string input, string expectedRemainingText)
        {
            var number = new Number();
            var _string = new String();

            var value = new Choice(_string,
                number,
                new Text("true"),
                new Text("false"),
                new Text("null"));

            var array = new Sequence(new Character('['),
                 new Optional(new OneOrMore(value)),
                new Character(']'));

            var _object = new Sequence(new Character('{'),
                 new Optional(new OneOrMore(new Sequence(_string, new Character(':'), value))),
                new Character('}')); ;

            value.Add(array);
            value.Add(_object);

            var result = value.Match(input);
            Assert.Equal(expectedRemainingText, result.RemainingText());
        }

        [Fact]
        public void CheckIfFirstCharInStringIsCorrect()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));

            Assert.Equal("12", digit.Match("012").RemainingText());
            Assert.Equal("2", digit.Match("12").RemainingText());
            Assert.Equal("2", digit.Match("92").RemainingText());
            Assert.Equal("a9", digit.Match("a9").RemainingText());
            Assert.Equal("", digit.Match("").RemainingText());
            Assert.Null(digit.Match(null).RemainingText());

            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));

            Assert.Equal("12", hex.Match("012").RemainingText());
            Assert.Equal("2", hex.Match("12").RemainingText());
            Assert.Equal("2", hex.Match("92").RemainingText());
            Assert.Equal("9", hex.Match("a9").RemainingText());
            Assert.Equal("8", hex.Match("f8").RemainingText());
            Assert.Equal("9", hex.Match("A9").RemainingText());
            Assert.Equal("8", hex.Match("F8").RemainingText());
            Assert.Equal("g8", hex.Match("g8").RemainingText());
            Assert.Equal("G8", hex.Match("G8").RemainingText());
            Assert.Equal("", hex.Match("").RemainingText());
            Assert.Null(hex.Match(null).RemainingText());
        }

        [Fact]
        public void CheckIfSequanceWorks()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var choice = new Choice(ab);

            Assert.Equal("ax", choice.Match("ax").RemainingText()); // false / "ax"
            Assert.Equal("cd", choice.Match("abcd").RemainingText()); // true / "cd"
        }
    }
}
