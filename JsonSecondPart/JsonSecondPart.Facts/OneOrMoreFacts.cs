using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class OneOrMoreFacts
    {
        [Theory]
        [InlineData("123", "")]
        [InlineData("1a", "a")]
        [InlineData("bc", "bc")]
        [InlineData("", "")]
        [InlineData(null, null)]

        public void OneOrMoreConsumesTheMatchingText(string input, string expectedRemainingText)
        {
            var subject = new OneOrMore(new Range('0', '9'));
            var result = subject.Match(input);
            Assert.Equal(expectedRemainingText, result.RemainingText());
        }

        [Fact]
        public void CheckRangeResults()
        {
            var a = new OneOrMore(new Range('0', '9'));

            Assert.Equal("", a.Match("123").RemainingText()); // true / ""
            Assert.Equal("a", a.Match("1a").RemainingText()); // true / "a"
            Assert.Equal("bc", a.Match("bc").RemainingText()); // false / "bc"
            Assert.Equal("", a.Match("").RemainingText()); // false / ""
            Assert.Null(a.Match(null).RemainingText()); // false / null

            Assert.True(a.Match("123").Success()); // true / ""
            Assert.True(a.Match("1a").Success()); // true / "a"
            Assert.False(a.Match("bc").Success()); // false / "bc"
            Assert.False(a.Match("").Success()); // false / ""
            Assert.False(a.Match(null).Success()); // false / null
        }
    }
}
