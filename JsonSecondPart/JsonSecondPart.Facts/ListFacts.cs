using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class ListFacts
    {
        [Theory]
        [InlineData("1,2,3", "")]
        [InlineData("1,2,3,", ",")]
        [InlineData("1a", "a")]
        [InlineData("abc", "abc")]
        [InlineData("", "")]
        [InlineData(null, null)]

        public void ListConsumesTheMatchingText(string input, string expectedRemainingText)
        {
            var a = new List(new Range('0', '9'), new Character(','));
            var result = a.Match(input);
            Assert.Equal(expectedRemainingText, result.RemainingText());
        }

        [Fact]
        public void CheckListResults()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal("", a.Match("1,2,3").RemainingText()); // true / ""
            Assert.Equal(",", a.Match("1,2,3,").RemainingText()); // true / ","
            Assert.Equal("a", a.Match("1a").RemainingText()); // true / "a"
            Assert.Equal("abc", a.Match("abc").RemainingText()); // true / "abc"
            Assert.Equal("", a.Match("").RemainingText()); // true  / ""
            Assert.Null(a.Match(null).RemainingText()); // true  / null

            Assert.True(a.Match("1,2,3").Success()); // true / ""
            Assert.True(a.Match("1,2,3,").Success()); // true / ","
            Assert.True(a.Match("1a").Success()); // true / "a"
            Assert.True(a.Match("abc").Success()); // true / "abc"
            Assert.True(a.Match("").Success()); // true  / ""
            Assert.True(a.Match(null).Success()); // true  / null
        }

        [Fact]
        public void CheckListComplexResults()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.Equal("", list.Match("1; 22  ;\n 333 \t; 22").RemainingText()); // true, ""
            Assert.Equal(" \n;", list.Match("1 \n;").RemainingText()); // true, " \n;"
            Assert.Equal("abc", list.Match("abc").RemainingText()); // true, "abc"

            Assert.True(list.Match("1; 22  ;\n 333 \t; 22").Success()); // true, ""
            Assert.True(list.Match("1 \n;").Success()); // true, " \n;"
            Assert.True(list.Match("abc").Success()); // true, "abc"
        }

        [Theory]
        [InlineData("1; 22  ;\n 333 \t; 22", "")]
        [InlineData("1 \n;", " \n;")]
        [InlineData("abc", "abc")]

        public void ListConsumesTheComplexMatchingText(string input, string expectedRemainingText)
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            var result = list.Match(input);
            Assert.Equal(expectedRemainingText, result.RemainingText());
        }
    }
}
