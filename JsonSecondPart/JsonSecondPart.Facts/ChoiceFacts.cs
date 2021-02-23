using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class ChoiceFacts
    {
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
